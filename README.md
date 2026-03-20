# Structural Patterns

Колекція реалізацій структурних паттернів проектування на C#.

Структурні паттерни займаються композицією класів та об'єктів для формування більших структур, забезпечуючи спосіб для цих об'єктів та класів роботи разом.

## Структура проєкту

Проєкт містить реалізації 7 основних структурних паттернів:

- **Adapter** — перетворює інтерфейс класу на інший інтерфейс, який очікують клієнти
- **Bridge** — відокремлює абстракцію від її реалізації так, щоб вони могли змінюватися незалежно
- **Composite** — компонує об'єкти в деревоподібні структури для представлення ієрархій "частина-ціле"
- **Decorator** — динамічно додає нову функціональність до об'єкта
- **Facade** — надає уніфікований інтерфейс до набору інтерфейсів у підсистемі
- **Flyweight** — використовує спільний стан для ефективної підтримки великої кількості дрібних об'єктів
- **Proxy** — надає замісник або посередника для іншого об'єкта для контролю доступу до нього

## Опис паттернів з прикладами

### Adapter

Адаптер дозволяє об'єктам з несумісними інтерфейсами працювати разом. Часто використовується для інтеграції legacy коду з новими системами.

```csharp
// Клієнт очікує цей інтерфейс
public class Logger
{
    public void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[LOG] " + message);
        Console.ResetColor();
    }
    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("[ERROR] " + message);
        Console.ResetColor();
    }

    public void Warn(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("[WARN] " + message);
        Console.ResetColor();
    }
}

// Адаптер перетворює інтерфейси
public class FileLoggerAdapter
{
    private FileWriter _fileWriter;

    public FileLoggerAdapter(FileWriter fileWriter)
    {
        _fileWriter = fileWriter;
    }

    public void Log(string message)
    {
        _fileWriter.WriteLine("[LOG] " + message);
    }

    public void Error(string message)
    {
        _fileWriter.WriteLine("[ERROR] " + message);
    }

    public void Warn(string message)
    {
        _fileWriter.WriteLine("[WARN] " + message);
    }
}

// Використання
Logger consoleLogger = new Logger();
consoleLogger.Log("LOG");

FileWriter fileWriter = new FileWriter("log.txt");
FileLoggerAdapter fileLogger = new FileLoggerAdapter(fileWriter);
fileLogger.Log("file Log");
```

### Bridge

Міст відокремлює абстракцію від реалізації, дозволяючи їм змінюватися незалежно. Корисно, коли у вас є кілька варіантів як абстракцій, так і реалізацій.

```csharp
// Інтерфейс реалізації
public interface IRenderer
{
    void Render(string shapeName);
}

// Конкретна реалізація
public class RasterRenderer : IRenderer
{
    public void Render(string shapeName)
    {
        Console.WriteLine($"Drawing {shapeName} as pixels");
    }
}

// Абстракція
public abstract class Shape
{
    protected IRenderer _renderer;

    protected Shape(IRenderer renderer)
    {
        _renderer = renderer;
    }

    public abstract void Draw();
}

// Конкретна абстракція
public class Circle : Shape
{
    public Circle(IRenderer renderer) : base(renderer)
    {
    }

    public override void Draw()
    {
        _renderer.Render("Circle");
    }
}

// Використання
IRenderer vector = new VectorRenderer();
IRenderer raster = new RasterRenderer();

Shape circle = new Circle(vector);
Shape square = new Square(raster);
circle.Draw();
square.Draw();
```

### Decorator

Декоратор динамічно додає нові обов'язки об'єкту, забезпечуючи гнучку альтернативу субклас створенню.

```csharp
// Інтерфейс
public interface IHero
{
    string GetDescription();
    int GetPower();
}

// Конкретний компонент
public class Warrior : IHero
{
    public string GetDescription() => "Warrior";
    public int GetPower() => 10;
}

// Базовий декоратор
public class HeroDecorator : IHero
{
    protected IHero _hero;
    public HeroDecorator(IHero hero)
    {
        _hero = hero;
    }

    public virtual string GetDescription() => _hero.GetDescription();
    public virtual int GetPower() => _hero.GetPower();
}

// Конкретний декоратор
public class Sword : HeroDecorator
{
    public Sword(IHero hero) : base(hero)
    {
    }

    public override string GetDescription()
    {
        return _hero.GetDescription() + " + Sword";
    }

    public override int GetPower()
    {
        return _hero.GetPower() + 5;
    }
}

public class Armor : HeroDecorator
{
    public Armor(IHero hero) : base(hero)
    {
    }

    public override string GetDescription()
    {
        return _hero.GetDescription() + " + Armor";
    }

    public override int GetPower()
    {
        return _hero.GetPower() + 3;
    }
}

// Використання
IHero hero = new Warrior();
hero = new Sword(hero);
hero = new Armor(hero);
Console.WriteLine(hero.GetDescription());
Console.WriteLine("Power: " + hero.GetPower());
```

### Flyweight

Flyweight використовує спільний стан для ефективної підтримки великої кількості дрібних об'єктів, зменшуючи пам'ять та покращуючи продуктивність.

```csharp
// Flyweight
public class TagFlyweight
{
    public string TagName { get; }
    public string DisplayType { get; }
    public bool SelfClosing { get; }
    public TagFlyweight(string tagName, string displayType, bool selfClosing)
    {
        TagName = tagName;
        DisplayType = displayType;
        SelfClosing = selfClosing;
    }
}

// Фабрика
public class TagFactory
{
    private Dictionary<string, TagFlyweight> _tags = new();

    public TagFlyweight GetTag(string tag, string display, bool selfClosing)
    {
        string key = $"{tag}_{display}_{selfClosing}";

        if (!_tags.ContainsKey(key))
            _tags[key] = new TagFlyweight(tag, display, selfClosing);

        return _tags[key];
    }
    public int Count => _tags.Count;
}

// Використання
var factory = new TagFactory();
var root = new LightElementNode(factory.GetTag("div", "block", false));

string[] lines = File.ReadAllLines("book.txt");
for (int i = 0; i < lines.Length; i++)
{
    string line = lines[i];
    LightElementNode element = new LightElementNode(factory.GetTag("p", "block", false));
    element.AddChild(new LightTextNode(line));
    root.AddChild(element);
}

Console.WriteLine(root.OuterHTML());
Console.WriteLine("Unique tag objects (Flyweight): " + factory.Count);
```

### Proxy

Проксі контролює доступ до іншого об'єкта, дозволяючи виконувати дії перед або після делегування запиту.

```csharp
// Інтерфейс
public interface ITextReader
{
    char[][] Read(string filePath);
}

// Реальний об'єкт
public class SmartTextReader : ITextReader
{
    public char[][] Read(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        return lines.Select(line => line.ToCharArray()).ToArray();
    }
}

// Проксі для перевірки та логування
public class SmartTextChecker : ITextReader
{
    private ITextReader _reader;
    public SmartTextChecker(ITextReader reader)
    {
        _reader = reader;
    }

    public char[][] Read(string filePath)
    {
        Console.WriteLine($"Opening file: {filePath}");
        char[][] content = _reader.Read(filePath);
        Console.WriteLine("File read successfully");

        int lines = content.Length;
        int chars = content.Sum(line => line.Length);
        Console.WriteLine($"Lines: {lines}");
        Console.WriteLine($"Characters: {chars}");
        return content;
    }
}

// Проксі для блокування доступу
public class SmartTextReaderLocker : ITextReader
{
    private ITextReader _reader;
    private Regex _regex;

    public SmartTextReaderLocker(ITextReader reader, string pattern)
    {
        _reader = reader;
        _regex = new Regex(pattern, RegexOptions.IgnoreCase);
    }

    public char[][] Read(string filePath)
    {
        if (_regex.IsMatch(filePath))
        {
            Console.WriteLine("Access denied!");
            return new char[0][];
        }
        return _reader.Read(filePath);
    }
}

// Використання
ITextReader reader = new SmartTextReader();
ITextReader checker = new SmartTextChecker(reader);
ITextReader locker = new SmartTextReaderLocker(checker, "secret");

locker.Read("test.txt");      // Дозволено
locker.Read("secret.txt");    // Заборонено
```

# Structural Patterns

Колекція реалізацій структурних паттернів проектування на C#.

Структурні паттерни займаються композицією класів та об'єктів для формування більших структур, забезпечуючи спосіб для цих об'єктів та класів роботи разом.

## Структура проєкту

Проєкт містить реалізації 7 основних структурних паттернів:

- **Adapter** — перетворює інтерфейс класу на інший інтерфейс, який очікують клієнти
- **Bridge** — відокремлює абстракцію від її реалізації так, щоб вони могли змінюватися незалежно
- **Composer** — компонує об'єкти в деревоподібні структури для представлення ієрархій "частина-ціле"
- **Decorator** — динамічно додає нову функціональність до об'єкта
- **Flyweight** — використовує спільний стан для ефективної підтримки великої кількості дрібних об'єктів
- **Proxy** — надає замісник або посередника для іншого об'єкта для контролю доступу до нього

## Опис паттернів з прикладами

### Adapter

Адаптер дозволяє об'єктам з несумісними інтерфейсами працювати разом. Часто використовується для інтеграції legacy коду з новими системами.

```csharp
public class Logger
{
    public void Log(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[LOG] " + message);
        Console.ResetColor();
    }
}

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
}

Logger consoleLogger = new Logger();
consoleLogger.Log("LOG");

FileWriter fileWriter = new FileWriter("log.txt");
FileLoggerAdapter fileLogger = new FileLoggerAdapter(fileWriter);
fileLogger.Log("file Log");
```

### Bridge

Міст відокремлює абстракцію від реалізації, дозволяючи їм змінюватися незалежно. Корисно, коли у вас є кілька варіантів як абстракцій, так і реалізацій.

```csharp
public interface IRenderer
{
    void Render(string shapeName);
}

public class RasterRenderer : IRenderer
{
    public void Render(string shapeName)
    {
        Console.WriteLine($"Drawing {shapeName} as pixels");
    }
}

public abstract class Shape
{
    protected IRenderer _renderer;

    protected Shape(IRenderer renderer)
    {
        _renderer = renderer;
    }

    public abstract void Draw();
}

public class Circle : Shape
{
    public Circle(IRenderer renderer) : base(renderer) { }

    public override void Draw()
    {
        _renderer.Render("Circle");
    }
}

IRenderer vector = new VectorRenderer();
IRenderer raster = new RasterRenderer();

Shape circle = new Circle(vector);
Shape square = new Square(raster);
circle.Draw();
square.Draw();
```

### Composer

Компонувальник — структурний паттерн, який дозволяє компонувати об'єкти в деревоподібні структури для представлення ієрархій "частина-ціле". Дозволяє клієнтам працювати з окремими об'єктами та композиціями об'єктів однаково.

```csharp
// Базовий інтерфейс
public abstract class LightNode
{
    public abstract string OuterHTML();
    public abstract string InnerHTML();
}

// Листок - просто текст
public class LightTextNode : LightNode
{
    private string _text;
    
    public LightTextNode(string text)
    {
        _text = text;
    }

    public override string OuterHTML() => _text;
    public override string InnerHTML() => _text;
}

// Контейнер - HTML елемент з дітьми
public class LightElementNode : LightNode
{
    private string _tagName;
    private List<LightNode> _children = new List<LightNode>();

    public LightElementNode(string tagName, string displayType, bool selfClosing)
    {
        _tagName = tagName;
    }

    public void AddChild(LightNode node)
    {
        _children.Add(node);
    }

    public override string InnerHTML()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var child in _children)
        {
            sb.Append(child.OuterHTML());
        }
        return sb.ToString();
    }

    public override string OuterHTML()
    {
        return $"<{_tagName}>{InnerHTML()}</{_tagName}>";
    }
}

// Використання
var ul = new LightElementNode("ul", "block", false);

var li1 = new LightElementNode("li", "block", false);
li1.AddChild(new LightTextNode("Item 1"));

var li2 = new LightElementNode("li", "block", false);
li2.AddChild(new LightTextNode("Item 2"));

ul.AddChild(li1);
ul.AddChild(li2);

Console.WriteLine(ul.OuterHTML());
// Виведе: <ul><li>Item 1</li><li>Item 2</li></ul>
```

### Decorator

Декоратор динамічно додає нові обов'язки об'єкту, забезпечуючи гнучку альтернативу субклас створенню.

```csharp
public interface IHero
{
    string GetDescription();
    int GetPower();
}

public class Warrior : IHero
{
    public string GetDescription() => "Warrior";
    public int GetPower() => 10;
}

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

public class Sword : HeroDecorator
{
    public Sword(IHero hero) : base(hero) { }

    public override string GetDescription()
    {
        return _hero.GetDescription() + " + Sword";
    }

    public override int GetPower()
    {
        return _hero.GetPower() + 5;
    }
}

IHero hero = new Warrior();
hero = new Sword(hero);
hero = new Armor(hero);
Console.WriteLine(hero.GetDescription());
Console.WriteLine("Power: " + hero.GetPower());
```

### Flyweight

Flyweight використовує спільний стан для ефективної підтримки великої кількості дрібних об'єктів, зменшуючи пам'ять та покращуючи продуктивність.

```csharp
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
public interface ITextReader
{
    char[][] Read(string filePath);
}

public class SmartTextReader : ITextReader
{
    public char[][] Read(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        return lines.Select(line => line.ToCharArray()).ToArray();
    }
}

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
        return content;
    }
}

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

ITextReader reader = new SmartTextReader();
ITextReader checker = new SmartTextChecker(reader);
ITextReader locker = new SmartTextReaderLocker(checker, "secret");

locker.Read("test.txt");
locker.Read("secret.txt");
```

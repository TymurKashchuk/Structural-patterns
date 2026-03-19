namespace Structural_patterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger consoleLogger = new Logger();
            consoleLogger.Log("LOG");
            consoleLogger.Warn("Warn");
            consoleLogger.Error("Error");

            FileWriter fileWriter = new FileWriter("log.txt");
            FileLoggerAdapter fileLogger = new FileLoggerAdapter(fileWriter);
            fileLogger.Log("file Log");
            fileLogger.Warn("file Warn");
            fileLogger.Error("file Error");
        }
    }
}
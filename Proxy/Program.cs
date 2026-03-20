using Proxy.Proxies;
using Proxy.TextReaders;

namespace Proxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITextReader reader = new SmartTextReader();

            ITextReader checker = new SmartTextChecker(reader);

            ITextReader locker = new SmartTextReaderLocker(checker, "secret");

            Console.WriteLine("Allowed file");
            locker.Read("test.txt");

            Console.WriteLine("\nBlocked file");
            locker.Read("secret.txt");
        }
    }
}

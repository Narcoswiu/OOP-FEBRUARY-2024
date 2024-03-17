using System.Security.Cryptography.X509Certificates;

namespace _02.HighQualityMistakes
{
    public class StartUp
    {
        static void Main()
        {
            Spy spy = new Spy();

            string result = spy.AnalyzeAccessModifiers("Hacker");
            Console.WriteLine(result);

        }
    }
}
using Stealer;

namespace _03.MissionPrivateImpossible
{
    public class StartUp
    {
        static void Main()
        {
            Spy spy = new Spy();

            string result = spy.RevealPrivateMethods("Stealer.Hacker");
            Console.WriteLine(result);

        }
    }
}
using _03.Telephony.Models;
using _03.Telephony.Models.Interfaces;
using System.Linq.Expressions;

namespace _03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] urls = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            ICallable phone;
            foreach (string phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 10)
                {
                    phone = new Smartphone();

                }
                else
                {
                    phone = new StationaryPhone();
                }

                try
                {
                    Console.WriteLine(phone.Call(phoneNumber));
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            IBrowsable browsable = new Smartphone();
            foreach (string url in urls)
            {
                try
                {
                    Console.WriteLine(browsable.Browse(url));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                } 
            }
        }
    }
}
using ShoppingSpree.Models;

namespace ShoppingSpree
{
    internal class StartUp
    {
        static void Main(string[] args)
        {

            try
            {

                Product product = new("Watch", 150);
                Product product2 = new("Phone", 150);

                Person person = new("Dimitrichko", 200);
                Console.WriteLine(person.Add(product));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;

            }
        }
    }
}
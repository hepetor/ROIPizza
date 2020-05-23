using System;
using System.ComponentModel;

namespace ROIPizza
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rovaniemi pizza app\n");
            Console.WriteLine("1. Display all pizzerias");
            Console.WriteLine("2. Display pizzerias you have not visited");
            Console.WriteLine("3. Display pizzerias you have visited");
            Console.WriteLine("4. Edit pizzeria info");
            Console.WriteLine("5. Add new pizzeria");
            Console.WriteLine("6. Remove pizzeria");
            Console.WriteLine("\n--- 0. Exit Rovaniemi pizza app");

            try
            {
            int selection = Int16.Parse(Console.ReadLine());
            Console.WriteLine("You selected " + selection);
            
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Displaying all pizzerias");
                        break;
                    case 2:
                        Console.WriteLine("Displaying all pizzerias you have not visited");
                        break;
                    case 3:
                        Console.WriteLine("Displaying all pizzerias you have visited");
                        break;
                    case 4:
                        Console.WriteLine("Editing pizzeria info");
                        Console.WriteLine("Choose pizzeria which information you want to edit:");
                        // TODO: Make implementation here. Parse from search or display all?
                        // Console.WriteLine("Pizzeria info edited successfully.");
                        break;
                    case 5:
                        Console.WriteLine("Add new pizzeria");
                        // TODO: Make implementation here. Parse from search or display all?
                        // Console.WriteLine("Pizzeria added successfully.");
                        break;
                    case 6:
                        Console.WriteLine("Remove pizzeria");
                        Console.WriteLine("Choose pizzeria that you want to remove:");
                        // TODO: Make implementation here. Parse from search or display all?
                        //Console.WriteLine("Pizzeria removed successfully.");
                        break;
                    case 0:
                        Console.WriteLine("Exiting Rovaniemi pizza app");
                        break;
                    default:
                        Console.WriteLine("~ Unknown input ~");
                        break;
                        // TODO: Make ask again.
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Expection caught");
                Console.WriteLine("Input error");
                // TODO: Make exit clean or make ask again...
            }
        }
    }
}

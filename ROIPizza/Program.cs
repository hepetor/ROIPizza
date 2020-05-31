using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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
            Console.WriteLine("----");
            Console.WriteLine("4. Mark pizzeria as visited");
            Console.WriteLine("5. Remove pizzeria from visited list");
            Console.WriteLine("----");
            Console.WriteLine("6. Edit pizzeria info");
            Console.WriteLine("7. Add new pizzeria");
            Console.WriteLine("8. Remove pizzeria");
            Console.WriteLine("\n--- 0. Exit Rovaniemi pizza app");

            try
            {
            int selection = Int16.Parse(Console.ReadLine());
            Console.WriteLine("You selected " + selection);
            
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Displaying all pizzerias");
                        DisplayEachPizzeria();
                        break;
                    case 2:
                        Console.WriteLine("Displaying all pizzerias you have not visited");
                        break;
                    case 3:
                        Console.WriteLine("Displaying all pizzerias you have visited");
                        break;
                    case 4:
                        Console.WriteLine("Choose pizzeria that you want to add to the list:");
                        Console.WriteLine("Pizzeria marked as visited");
                        // TODO: Make implementation here. Parse from search or display all?
                        break;
                    case 5:
                        Console.WriteLine("Choose pizzeria that you want to remove from the list:");
                        Console.WriteLine("Pizzeria removed from visited list");
                        // TODO: Make implementation here. Parse from search or display all?
                        break;
                    case 6:
                        Console.WriteLine("Editing pizzeria info");
                        Console.WriteLine("Choose pizzeria which information you want to edit:");
                        // TODO: Make implementation here. Parse from search or display all?
                        // Console.WriteLine("Pizzeria info edited successfully.");
                        break;
                    case 7:
                        Console.WriteLine("Add new pizzeria");
                        // TODO: Make implementation here. Parse from search or display all?
                        // Console.WriteLine("Pizzeria added successfully.");
                        break;
                    case 8:
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

        static List<Pizzeria> InitializePizzeriaList()
        {
            Pizzeria memos = new Pizzeria();
            memos.SetName("memo");

            Pizzeria marmaris = new Pizzeria();
            marmaris.SetName("marmaris");

            List<Pizzeria> list = new List<Pizzeria>();
            list.Add(memos);
            list.Add(marmaris);

            return list;

            // Array implementation
            /*
            Pizzeria[] arr = new Pizzeria[2];

            arr[0] = memos;
            arr[1] = marmaris;

            foreach (var itemz in arr)
            {
                Console.WriteLine(itemz.GetName());
            }
            */
        }

        static void DisplayEachPizzeria()
        {
            // Display each pizzeria
            foreach (var item in InitializePizzeriaList())
            {
                Console.WriteLine(item.GetName());
            }
        }

    }
}


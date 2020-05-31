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
            InitializePizzeriaList();

            DisplayMenu();

            try
            {

                bool loop = true;
                while (loop)
                {
                    Console.WriteLine("\nChoose operation: ");
                    int selection = Int16.Parse(Console.ReadLine());
                    switch (selection)
                    {
                        case 1:
                            FixDisplay();
                            Console.WriteLine("Displaying all pizzerias");
                            DisplayEachPizzeria();
                            break;
                        case 2:
                            FixDisplay();
                            Console.WriteLine("Displaying all pizzerias you have not visited");
                            DisplayNotVisitedPizzerias();
                            break;
                        case 3:
                            FixDisplay();
                            Console.WriteLine("Displaying all pizzerias you have visited");
                            DisplayVisitedPizzerias();
                            break;
                        case 4:
                            FixDisplay();
                            //Console.WriteLine("Choose pizzeria that you want to add to the visited pizzeria list:");
                            MarkPizzeriaAsVisited();
                            // Console.WriteLine("Pizzeria marked as visited");
                            // TODO: Make implementation here. Parse from search or display all?

                            break;
                        case 5:
                            FixDisplay();
                            //Console.WriteLine("Choose pizzeria that you want to remove from the visited pizzeria list:");
                            //Console.WriteLine("Pizzeria removed from visited list");
                            RemovePizzeriaFromVisited();
                            // TODO: Make implementation here. Parse from search or display all?
                            break;
                        case 6:
                            FixDisplay();
                            Console.WriteLine("Editing pizzeria info");
                            Console.WriteLine("Choose pizzeria which information you want to edit:");
                            // TODO: Make implementation here. Parse from search or display all?
                            // Console.WriteLine("Pizzeria info edited successfully.");
                            break;
                        case 7:
                            FixDisplay();
                            Console.WriteLine("Add new pizzeria");
                            // TODO: Make implementation here. Parse from search or display all?
                            // Console.WriteLine("Pizzeria added successfully.");
                            break;
                        case 8:
                            FixDisplay();
                            Console.WriteLine("Remove pizzeria");
                            Console.WriteLine("Choose pizzeria that you want to remove:");
                            // TODO: Make implementation here. Parse from search or display all?
                            //Console.WriteLine("Pizzeria removed successfully.");
                            break;
                        case 0:
                            Console.WriteLine("Exiting Rovaniemi pizza app");
                            loop = false;
                            break;
                        default:
                            FixDisplay();
                            Console.WriteLine("~ Unknown input ~");
                            break;
                            // TODO: Make ask again.
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Expection caught");
                Console.WriteLine("Input error");
                // TODO: Make exit clean or make ask again...
            }
        }

        static void DisplayMenu()
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
        }

        static void InitializePizzeriaList()
        {
            Pizzeria memos = new Pizzeria();
            memos.SetName("memo");

            Pizzeria marmaris = new Pizzeria();
            marmaris.SetName("marmaris");

            //List<Pizzeria> list = new List<Pizzeria>();
            m_fullPizzeriaList.Add(memos);
            m_fullPizzeriaList.Add(marmaris);

            m_NonVisitedPizzeriaList = m_fullPizzeriaList;

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
        
        static void FixDisplay()
        {
            Console.Clear();
            DisplayMenu();
        }
        
        static void DisplayEachPizzeria()
        {
            // Display each pizzeria
            foreach (var item in m_fullPizzeriaList)
            {
                Console.WriteLine(item.GetName());
            }
        }

        static void DisplayVisitedPizzerias()
        {
            Console.WriteLine("Displaying all pizzerias you have visited: "); //remove when working
            // Display visited pizzerias
            foreach (var item in m_visitedPizzeriaList)
            {
                Console.WriteLine(item.GetName());
            }
        }

        static void DisplayNotVisitedPizzerias()
        {
            Console.WriteLine("Displaying all pizzerias you have not visited: "); //remove when working
            // Display non visited pizzerias pizzeria
            foreach (var item in m_NonVisitedPizzeriaList)
            {
                Console.WriteLine(item.GetName());
            }
        }

        static void MarkPizzeriaAsVisited()
        {
            Console.WriteLine("Choose pizzeria that you want to add to the visited pizzeria list: ");
            String pizzeriaName = Console.ReadLine();
            foreach (var item in m_NonVisitedPizzeriaList)
            {
                if (item.GetName() == pizzeriaName)
                {
                    Console.WriteLine($">>>> {pizzeriaName} Pizzeria found ");
                    m_visitedPizzeriaList.Add(item);
                    m_NonVisitedPizzeriaList.Remove(item);

                    DisplayNotVisitedPizzerias(); //remove when done...
                    DisplayVisitedPizzerias(); //remove when done...

                    return;
                }
            }
            Console.WriteLine($"Pizzeria {pizzeriaName} not found... ");
        }

        static void RemovePizzeriaFromVisited()
        {
            Console.WriteLine("Choose pizzeria that you want to add to remove from the visited pizzeria list: ");
            String pizzeriaName = Console.ReadLine();
            foreach (var item in m_visitedPizzeriaList)
            {
                if (item.GetName() == pizzeriaName)
                {
                    Console.WriteLine($">>>> {pizzeriaName} Pizzeria found ");
                    m_visitedPizzeriaList.Remove(item);
                    m_NonVisitedPizzeriaList.Add(item);

                    DisplayNotVisitedPizzerias(); //remove when done...
                    DisplayVisitedPizzerias(); //remove when done...

                    return;
                }
            }
            Console.WriteLine($"Pizzeria {pizzeriaName} not found... ");
        }

        static List<Pizzeria> m_fullPizzeriaList = new List<Pizzeria>();
        static List<Pizzeria> m_visitedPizzeriaList = new List<Pizzeria>();
        static List<Pizzeria> m_NonVisitedPizzeriaList = new List<Pizzeria>();
    }
}


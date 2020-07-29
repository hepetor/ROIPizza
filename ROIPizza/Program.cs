using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ROIPizza
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeFullPizzeriaList();
            InitializeVisitedPizzeriaList();
            InitializeNonVisitedPizzeriaList();

            DisplayMenu();

            FileHandler handler = new FileHandler();

            //handler.FileToString();
            //handler.ParseFile();
            //handler.RemoveFromFile();
            //handler.AddToFile();
            // TODO: Clean after no longer needed for debugging.

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
                            Console.WriteLine("Choose pizzeria which information you want to display: ");
                            DisplaySpecificPizzeriaInfo();
                            break;
                        case 5:
                            FixDisplay();
                            MarkPizzeriaAsVisited();
                            break;
                        case 6:
                            FixDisplay();
                            RemovePizzeriaFromVisited();
                            break;
                        case 7:
                            FixDisplay();
                            Console.WriteLine("Editing pizzeria info");
                            Console.WriteLine("Choose pizzeria which information you want to edit:");
                            // TODO: Make implementation here. Parse from search or display all?
                            // Console.WriteLine("Pizzeria info edited successfully.");
                            break;
                        case 8:
                            FixDisplay();
                            AddNewPizzeria();
                            break;
                        case 9:
                            FixDisplay();
                            RemovePizzeria();
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
            Console.WriteLine("4. Display pizzeria info");
            Console.WriteLine("----");
            Console.WriteLine("5. Mark pizzeria as visited");
            Console.WriteLine("6. Remove pizzeria from visited list");
            Console.WriteLine("----");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("7. Edit pizzeria info"); //TODO
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("8. Add new pizzeria");
            Console.WriteLine("9. Remove pizzeria");
            Console.WriteLine("\n--- 0. Exit Rovaniemi pizza app");
        }

        static void InitializeFullPizzeriaList()
        {
            FileHandler handler = new FileHandler();
            handler.ParseFullFile();

            var names = new List<String>();
            var addresses = new List<String>();
            var numbers = new List<String>();
            var kebabs = new List<bool>();
            var burgers = new List<bool>();
            var deliveries = new List<bool>();

            foreach (var name in handler.Name)
            {
                if (!names.Contains(name))
                {
                    names.Add(name);
                }
            }

            foreach (var address in handler.Address)
            {
                if (!addresses.Contains(address))
                {
                    addresses.Add(address);
                }
            }

            foreach (var number in handler.Number)
            {
                if (!numbers.Contains(number))
                {
                    numbers.Add(number);
                }
            }

            foreach (var kebab in handler.KebabAvailability)
            {
                kebabs.Add(kebab);
            }

            foreach (var burger in handler.BurgerAvailability)
            {
                burgers.Add(burger);
            }

            foreach (var delivery in handler.DeliveryAvailability)
            {
                deliveries.Add(delivery);
            }

            var amountOfPizzerias = names.Count();

            Console.WriteLine("Full pizzerias list: " + amountOfPizzerias);
            // TODO: Remove after no longer needed for debugging

            int count = 0;
            while (count < amountOfPizzerias)
            {
                var pizzeria = new Pizzeria(
                    names.ElementAt<string>(count),
                    numbers.ElementAt<string>(count),
                    addresses.ElementAt<string>(count),
                    kebabs.ElementAt<bool>(count),
                    burgers.ElementAt<bool>(count),
                    deliveries.ElementAt<bool>(count));

                m_fullPizzeriaList.Add(pizzeria);
                count++;
            }

        }

        static void InitializeVisitedPizzeriaList()
        {
            FileHandler handler = new FileHandler();
            handler.ParseVisitedFile();

            var names = new List<String>();
            var addresses = new List<String>();
            var numbers = new List<String>();
            var kebabs = new List<bool>();
            var burgers = new List<bool>();
            var deliveries = new List<bool>();

            foreach (var name in handler.VisitedName)
            {
                if (!names.Contains(name))
                {
                    names.Add(name);
                }
            }

            foreach (var address in handler.VisitedAddress)
            {
                if (!addresses.Contains(address))
                {
                    addresses.Add(address);
                }
            }

            foreach (var number in handler.VisitedNumber)
            {
                if (!numbers.Contains(number))
                {
                    numbers.Add(number);
                }
            }

            foreach (var kebab in handler.VisitedKebabAvailability)
            {
                kebabs.Add(kebab);
            }

            foreach (var burger in handler.VisitedBurgerAvailability)
            {
                burgers.Add(burger);
            }

            foreach (var delivery in handler.VisitedDeliveryAvailability)
            {
                deliveries.Add(delivery);
            }

            var amountOfPizzerias = names.Count();

            Console.WriteLine("Visited pizzerias: " + amountOfPizzerias);
            // TODO: Remove after no longer needed for debugging

            int count = 0;
            while (count < amountOfPizzerias)
            {
                var pizzeria = new Pizzeria(
                    names.ElementAt<string>(count),
                    numbers.ElementAt<string>(count),
                    addresses.ElementAt<string>(count),
                    kebabs.ElementAt<bool>(count),
                    burgers.ElementAt<bool>(count),
                    deliveries.ElementAt<bool>(count));

                m_visitedPizzeriaList.Add(pizzeria);
                count++;
            }
        }

        static void InitializeNonVisitedPizzeriaList()
        {
            FileHandler handler = new FileHandler();
            handler.ParseNonVisitedFile();

            var names = new List<String>();
            var addresses = new List<String>();
            var numbers = new List<String>();
            var kebabs = new List<bool>();
            var burgers = new List<bool>();
            var deliveries = new List<bool>();

            foreach (var name in handler.NonVisitedName)
            {
                if (!names.Contains(name))
                {
                    names.Add(name);
                }
            }

            foreach (var address in handler.NonVisitedAddress)
            {
                if (!addresses.Contains(address))
                {
                    addresses.Add(address);
                }
            }

            foreach (var number in handler.NonVisitedNumber)
            {
                if (!numbers.Contains(number))
                {
                    numbers.Add(number);
                }
            }

            foreach (var kebab in handler.NonVisitedKebabAvailability)
            {
                kebabs.Add(kebab);
            }

            foreach (var burger in handler.NonVisitedBurgerAvailability)
            {
                burgers.Add(burger);
            }

            foreach (var delivery in handler.NonVisitedDeliveryAvailability)
            {
                deliveries.Add(delivery);
            }

            var amountOfPizzerias = names.Count();

            Console.WriteLine("Non visited pizzerias: " + amountOfPizzerias);
            // TODO: Remove after no longer needed for debugging

            int count = 0;
            while (count < amountOfPizzerias)
            {
                var pizzeria = new Pizzeria(
                    names.ElementAt<string>(count),
                    numbers.ElementAt<string>(count),
                    addresses.ElementAt<string>(count),
                    kebabs.ElementAt<bool>(count),
                    burgers.ElementAt<bool>(count),
                    deliveries.ElementAt<bool>(count));

                m_nonVisitedPizzeriaList.Add(pizzeria);
                count++;
            }
        }


        static void FixDisplay()
        {
            Console.Clear();
            DisplayMenu();
        }
        static void DisplayEachPizzeria()
        {
            // 1
            // Display each pizzeria
            foreach (var item in m_fullPizzeriaList)
            {
                Console.WriteLine(item.Name);
            }
        }

        static void DisplayNotVisitedPizzerias()
        {
            // 2
            // Display non visited pizzerias pizzeria
            foreach (var item in m_nonVisitedPizzeriaList)
            {
                Console.WriteLine(item.Name);
            }
        }

        static void DisplayVisitedPizzerias()
        {
            //3
            // TODO: Tell the user if its empty
            foreach (var item in m_visitedPizzeriaList)
            {
                Console.WriteLine(item.Name);
            }
        }

        static void DisplaySpecificPizzeriaInfo()
        {
            //4
            String pizzeriaName = Console.ReadLine();
            foreach (var item in m_fullPizzeriaList)
            {
                if (item.Name == pizzeriaName)
                {
                    Console.WriteLine($"Name: {item.Name}");
                    Console.WriteLine($"Address: {item.Address}");
                    Console.WriteLine($"Phone number: {item.Number}");
                    Console.WriteLine($"Kebab: {item.KebabAvailability}");
                    Console.WriteLine($"Burger: {item.BurgerAvailability}");
                    Console.WriteLine($"Delivery: {item.DeliveryAvailability}");
                    return;
                }
            }
            Console.WriteLine($"Pizzeria {pizzeriaName} not found... ");
        }

        static void MarkPizzeriaAsVisited()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" --- ");

            foreach (var item in m_nonVisitedPizzeriaList)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(item.Name);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" --- ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Type the pizzeria that you want to mark as visited pizzeria:");


            // 5
            // TODO: File usage
            String pizzeriaName = Console.ReadLine();
            foreach (var item in m_nonVisitedPizzeriaList)
            {
                if (item.Name == pizzeriaName)
                {
                    m_visitedPizzeriaList.Add(item);
                    m_nonVisitedPizzeriaList.Remove(item);

                    FileHandler handler = new FileHandler();
                    handler.AddToVisitedFile(pizzeriaName);

                    return;
                }
            }
            Console.WriteLine($"Pizzeria {pizzeriaName} not found... ");
        }

        static void RemovePizzeriaFromVisited()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" --- ");

            foreach (var item in m_visitedPizzeriaList)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(item.Name);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" --- ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Type the pizzeria that you want mark as non visited:");

            // 6
            String pizzeriaName = Console.ReadLine();
            foreach (var item in m_visitedPizzeriaList)
            {
                if (item.Name == pizzeriaName)
                {
                    m_visitedPizzeriaList.Remove(item);
                    m_nonVisitedPizzeriaList.Add(item);

                    FileHandler handler = new FileHandler();
                    handler.AddToNonVisitedFile(pizzeriaName);
                    return;
                }
            }
            Console.WriteLine($"Pizzeria {pizzeriaName} not found... ");
        }

        static void AddNewPizzeria()
        {
            Console.WriteLine("Add new pizzeria");

            FileHandler handler = new FileHandler();

            handler.AddToFile();

            Pizzeria newPizzeria = handler.GetNewPizzeria();

            m_fullPizzeriaList.Add(newPizzeria);
            m_nonVisitedPizzeriaList.Add(newPizzeria);

            Console.WriteLine("New pizzeria added successfully.");
        }

        static void RemovePizzeria()
        {
            Console.WriteLine("Choose pizzeria that you want to remove completely:");

            FileHandler handler = new FileHandler();

            string pizzeriaName = Console.ReadLine();

            try
            {
                foreach (var item in m_fullPizzeriaList)
                {
                    if (item.Name == pizzeriaName)
                    {
                        m_fullPizzeriaList.Remove(item);
                        string filePath = handler.GetFullPizzeriaListPath();
                        string text = handler.FullPizzeriaFileToString();
                        handler.RemoveFromFile(pizzeriaName, filePath, text);
                        Console.WriteLine($">>>> {pizzeriaName} Pizzeria deleted successfully. ");
                        break;
                    }
                }

                foreach (var item in m_visitedPizzeriaList)
                {
                    if (item.Name == pizzeriaName)
                    {
                        m_visitedPizzeriaList.Remove(item);

                        string filePath = handler.GetVisitedPizzeriaListPath();
                        string text = handler.VisitedPizzeriaFileToString();
                        handler.RemoveFromFile(pizzeriaName, filePath, text);

                        Console.WriteLine($">>>> {pizzeriaName} Pizzeria deleted successfully. ");
                        break;

                    }
                }

                foreach (var item in m_nonVisitedPizzeriaList)
                {
                    if (item.Name == pizzeriaName)
                    {
                        m_nonVisitedPizzeriaList.Remove(item);

                        string filePath = handler.GetNonVisitedPizzeriaListPath();
                        string text = handler.NonVisitedPizzeriaFileToString();
                        handler.RemoveFromFile(pizzeriaName, filePath, text);

                        Console.WriteLine($">>>> {pizzeriaName} Pizzeria deleted successfully. ");
                        break;

                    }
                }
            }

            catch (Exception)
            {
                Console.WriteLine(">>>>>>>>> EXCEPTION"); //Debug 
            }
            return;
        }

        static List<Pizzeria> m_fullPizzeriaList = new List<Pizzeria>();
        static List<Pizzeria> m_visitedPizzeriaList = new List<Pizzeria>();
        static List<Pizzeria> m_nonVisitedPizzeriaList = new List<Pizzeria>();
    }
}


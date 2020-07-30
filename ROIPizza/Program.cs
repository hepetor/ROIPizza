using System;
using System.Collections.Generic;
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

            //FileHandler handler = new FileHandler();
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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nChoose operation: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    string selection = Console.ReadLine();
                    switch (selection)
                    {
                        case "1":
                            FixDisplay();
                            Console.WriteLine("Displaying all pizzerias");
                            DisplayEachPizzeria();
                            break;
                        case "2":
                            FixDisplay();
                            Console.WriteLine("Displaying all pizzerias you have not visited");
                            DisplayNotVisitedPizzerias();
                            break;
                        case "3":
                            FixDisplay();
                            Console.WriteLine("Displaying all pizzerias you have visited");
                            DisplayVisitedPizzerias();
                            break;
                        case "4":
                            FixDisplay();
                            DisplaySpecificPizzeriaInfo();
                            break;
                        case "5":
                            FixDisplay();
                            MarkPizzeriaAsVisited();
                            break;
                        case "6":
                            FixDisplay();
                            RemovePizzeriaFromVisited();
                            break;
                        case "7":
                            FixDisplay();
                            EditPizzeriaInfo();
                            break;
                        case "8":
                            FixDisplay();
                            AddNewPizzeria();
                            break;
                        case "9":
                            FixDisplay();
                            RemovePizzeria();
                            break;
                        // --- Easter egg for the best pizza toppings all time ---
                        // --- Also known as "Isokorva" ---
                        case "isokorva":
                            FixDisplay();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Kebab, pepperoni, bacon, blue cheese, red onion, jalapeno, mayonnaise, chili sauce");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        // --- End of easter egg ---
                        case "0":
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
            catch (Exception)
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
            Console.WriteLine("7. Edit pizzeria info");
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var item in m_fullPizzeriaList)
            {
                Console.WriteLine(item.Name);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void DisplayNotVisitedPizzerias()
        {
            // 2
            if (m_nonVisitedPizzeriaList.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---");
                Console.ForegroundColor = ConsoleColor.Gray;

                foreach (var item in m_nonVisitedPizzeriaList)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You have already visited all the pizzerias");
            }

        }

        static void DisplayVisitedPizzerias()
        {
            //3
            if (m_visitedPizzeriaList.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---");
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (var item in m_visitedPizzeriaList)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You have not visited any pizzerias");
            }
        }

        static void DisplaySpecificPizzeriaInfo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" --- ");
            foreach (var item in m_fullPizzeriaList)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(" --- ");
            Console.ForegroundColor = ConsoleColor.Gray;

            //4
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Choose pizzeria which information you want to display: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            String pizzeriaName = Console.ReadLine();
            foreach (var item in m_fullPizzeriaList)
            {
                if (item.Name == pizzeriaName)
                {
                    FixDisplay();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(" --- ");
                    Console.WriteLine($"Name: {item.Name}");
                    Console.WriteLine($"Address: {item.Address}");
                    Console.WriteLine($"Phone number: {item.Number}");
                    Console.WriteLine($"Kebab: {item.KebabAvailability}");
                    Console.WriteLine($"Burger: {item.BurgerAvailability}");
                    Console.WriteLine($"Delivery: {item.DeliveryAvailability}");
                    Console.WriteLine(" --- ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }
            }

            FixDisplay();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\nPizzeria {pizzeriaName} not found... ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void MarkPizzeriaAsVisited()
        {
            if (m_nonVisitedPizzeriaList.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" --- ");
                Console.ForegroundColor = ConsoleColor.Gray;

                foreach (var item in m_nonVisitedPizzeriaList)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" --- ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Type the pizzeria that you want to mark as visited pizzeria:");
                Console.ForegroundColor = ConsoleColor.Gray;

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

                        FixDisplay();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nPizzeria {pizzeriaName} marked as visited");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    }
                }

                FixDisplay();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\nPizzeria {pizzeriaName} not found... ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                FixDisplay();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You have already visited all the pizzerias");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        static void RemovePizzeriaFromVisited()
        {
            if (m_visitedPizzeriaList.Count != 0)
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

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Type the pizzeria that you want mark as non visited:");
                Console.ForegroundColor = ConsoleColor.Gray;

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

                        FixDisplay();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nPizzeria {pizzeriaName} removed from the visited list");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Pizzeria {pizzeriaName} not found... ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You have not visited any pizzerias");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        static void AddNewPizzeria()
        {
            Console.WriteLine("Add new pizzeria");

            FileHandler handler = new FileHandler();

            handler.AddToFile();

            Pizzeria newPizzeria = handler.GetNewPizzeria();

            handler.AddToNonVisitedFile(newPizzeria.Name);

            m_fullPizzeriaList.Add(newPizzeria);
            m_nonVisitedPizzeriaList.Add(newPizzeria);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nNew pizzeria '{newPizzeria.Name}' added successfully.");
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        static void RemovePizzeria()
        {
            Console.WriteLine("Choose pizzeria that you want to remove completely:");

            FileHandler handler = new FileHandler();

            string pizzeriaName = Console.ReadLine();
            bool removed = false;

            try
            {
                foreach (var item in m_fullPizzeriaList)
                {
                    if (item.Name == pizzeriaName)
                    {
                        m_fullPizzeriaList.Remove(item);
                        string fullPizzeriaFilePath = handler.GetFullPizzeriaListPath();
                        string text = handler.PizzeriaFileToString(fullPizzeriaFilePath);
                        handler.RemoveFromFile(pizzeriaName, fullPizzeriaFilePath, text);
                        removed = true;
                        break;
                    }
                }

                foreach (var item in m_visitedPizzeriaList)
                {
                    if (item.Name == pizzeriaName)
                    {
                        m_visitedPizzeriaList.Remove(item);

                        string visitedPizzeriaFilePath = handler.GetVisitedPizzeriaListPath();
                        string text = handler.PizzeriaFileToString(visitedPizzeriaFilePath);
                        handler.RemoveFromFile(pizzeriaName, visitedPizzeriaFilePath, text);
                        break;

                    }
                }

                foreach (var item in m_nonVisitedPizzeriaList)
                {
                    if (item.Name == pizzeriaName)
                    {
                        m_nonVisitedPizzeriaList.Remove(item);

                        string NonVisitedPizzeriaFilePath = handler.GetNonVisitedPizzeriaListPath();
                        string text = handler.PizzeriaFileToString(NonVisitedPizzeriaFilePath);

                        handler.RemoveFromFile(pizzeriaName, NonVisitedPizzeriaFilePath, text);
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(">>>>>>>>> EXCEPTION"); //Debug
            }

            if (removed)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Pizzeria '{pizzeriaName}' removed successfully.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Pizzeria '{pizzeriaName}' not found.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            return;
        }

        static void EditPizzeriaInfo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" --- ");
            foreach (var item in m_fullPizzeriaList)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(" --- ");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Choose pizzeria which information you want to edit:");
            Console.ForegroundColor = ConsoleColor.Gray;
            String pizzeriaName = Console.ReadLine();

            //4
            foreach (var item in m_fullPizzeriaList)
            {
                if (item.Name == pizzeriaName)
                {
                    FixDisplay();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Current information of pizzeria {item.Name} :");
                    Console.WriteLine(" --- ");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine($"Name: {item.Name}");
                    Console.WriteLine($"Address: {item.Address}");
                    Console.WriteLine($"Phone number: {item.Number}");
                    Console.WriteLine($"Kebab: {item.KebabAvailability}");
                    Console.WriteLine($"Burger: {item.BurgerAvailability}");
                    Console.WriteLine($"Delivery: {item.DeliveryAvailability}");
                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.WriteLine(" --- ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }
            }

            FileHandler handler = new FileHandler();

            bool exists = false;
            bool visited = false;
            bool nonVisited = false;

            string fullPizzeriaFilePath = handler.GetFullPizzeriaListPath();
            string visitedPizzeriaFilePath = handler.GetVisitedPizzeriaListPath();
            string nonVisitedPizzeriaFilePath = handler.GetNonVisitedPizzeriaListPath();


            try
            {
                foreach (var item in m_fullPizzeriaList)
                {
                    if (item.Name == pizzeriaName)
                    {
                        m_fullPizzeriaList.Remove(item);
                        exists = true;
                        break;
                    }
                }

                foreach (var item in m_visitedPizzeriaList)
                {
                    if (item.Name == pizzeriaName)
                    {
                        m_visitedPizzeriaList.Remove(item);
                        visited = true;
                        break;
                    }
                }

                foreach (var item in m_nonVisitedPizzeriaList)
                {
                    if (item.Name == pizzeriaName)
                    {
                        m_nonVisitedPizzeriaList.Remove(item);
                        nonVisited = true;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(">>>>>>>>> EXCEPTION"); //Debug 
            }

            if (exists)
            {
                handler.AddToFile();
                m_fullPizzeriaList.Add(handler.GetNewPizzeria());
                //string fullPizzeriaFilePath = handler.GetFullPizzeriaListPath();
                string text = handler.PizzeriaFileToString(fullPizzeriaFilePath);
                handler.RemoveFromFile(pizzeriaName, fullPizzeriaFilePath, text);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pizzeria information updated successfully.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pizzeria does not exist!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            if (visited)
            {
                handler.AddToVisitedFile(handler.GetNewPizzeria().Name);
                m_visitedPizzeriaList.Add(handler.GetNewPizzeria());
                string text = handler.PizzeriaFileToString(visitedPizzeriaFilePath);
                handler.RemoveFromFile(pizzeriaName, visitedPizzeriaFilePath, text);

            }
            if (nonVisited)
            {
                handler.AddToNonVisitedFile(handler.GetNewPizzeria().Name);
                m_nonVisitedPizzeriaList.Add(handler.GetNewPizzeria());
                string text = handler.PizzeriaFileToString(nonVisitedPizzeriaFilePath);
                handler.RemoveFromFile(pizzeriaName, nonVisitedPizzeriaFilePath, text);
            }
        }

        static List<Pizzeria> m_fullPizzeriaList = new List<Pizzeria>();
        static List<Pizzeria> m_visitedPizzeriaList = new List<Pizzeria>();
        static List<Pizzeria> m_nonVisitedPizzeriaList = new List<Pizzeria>();
    }
}


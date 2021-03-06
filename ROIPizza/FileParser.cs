﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;


namespace ROIPizza
{
    class FileHandler
    {

        // Path to the location of the full pizzeria list
        public string GetFullPizzeriaListPath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string fileDirectory = Directory.GetParent(projectDirectory).Parent.FullName;
            string filePath = (fileDirectory) + "\\ROIPizza\\fullPizzeriaList.txt";

            return filePath;
        }

        public string GetVisitedPizzeriaListPath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string fileDirectory = Directory.GetParent(projectDirectory).Parent.FullName;
            string filePath = (fileDirectory) + "\\ROIPizza\\visitedPizzerias.txt";

            return filePath;
        }

        public string GetNonVisitedPizzeriaListPath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string fileDirectory = Directory.GetParent(projectDirectory).Parent.FullName;
            string filePath = (fileDirectory) + "\\ROIPizza\\nonVisitedPizzerias.txt";

            return filePath;
        }

        // Get contents of the list of pizzerias file in to a string
        public string PizzeriaFileToString(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("pizzeria file not found! ");// make exit
            }

            string textString = File.ReadAllText(filePath);

            return textString;
        }

        // Parse pizzeria list file
        // Get the properties of each pizzeria
        public void ParseFullFile()
        {
            string text = PizzeriaFileToString(GetFullPizzeriaListPath());

            string[] pizzerias = Regex.Split(text, @"(?<=[}])");
            foreach (string pizzeria in pizzerias)
            {
                string[] properties = Regex.Split(pizzeria, @"(?<=[>])");
                foreach (string property in properties)
                {
                    if (property.Contains("Name"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string name = property.Substring(start, end - start);
                        m_name.Add(name);
                    }

                    if (property.Contains("Address"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string address = property.Substring(start, end - start);
                        m_address.Add(address);
                    }

                    if (property.Contains("Number"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string number = property.Substring(start, end - start);
                        m_number.Add(number);
                    }

                    if (property.Contains("Kebab"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string kebab = property.Substring(start, end - start);
                        if (kebab.Equals("true"))
                        {
                            m_kebab.Add(true);
                        }
                        else if (kebab.Equals("false"))
                        {
                            m_kebab.Add(false);
                        }
                    }

                    if (property.Contains("Burger"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string burger = property.Substring(start, end - start);
                        if (burger.Equals("true"))
                        {
                            m_burger.Add(true);
                        }
                        else if (burger.Equals("false"))
                        {
                            m_burger.Add(false);
                        }
                    }

                    if (property.Contains("Delivery"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string delivery = property.Substring(start, end - start);
                        if (delivery.Equals("true"))
                        {
                            m_delivery.Add(true);
                        }
                        else if (delivery.Equals("false"))
                        {
                            m_delivery.Add(false);
                        }
                    }
                }
            }
        }

        // Add new pizzeria to a file
        public void AddToFile()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Add name: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            m_newPizzeriaName = ("Name:<" + Console.ReadLine() + ">\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Add address: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            m_newPizzeriaAddress = ("Address:<" + Console.ReadLine() + ">\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Add phone number: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            m_newPizzeriaNumber = ("Number:<" + Console.ReadLine() + ">\n");

            bool m_newPizzeriaKebabAvailability = false;
            string validKebab = String.Empty;
            while (!m_newPizzeriaKebabAvailability)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Add kebab availability: (true/false)");
                Console.ForegroundColor = ConsoleColor.Gray;
                string kebabInput = Console.ReadLine();

                if (kebabInput.Equals("true") || kebabInput.Equals("false"))
                {
                    validKebab = ("Kebab:<" + kebabInput + ">\n");
                    m_newPizzeriaKebabAvailability = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input, please type 'true/false'");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
            }

            bool m_newPizzeriaBurgerAvailability = false;
            string validBurger = String.Empty;
            while (!m_newPizzeriaBurgerAvailability)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Add burger availability: (true/false)");
                Console.ForegroundColor = ConsoleColor.Gray;

                string burgerInput = Console.ReadLine();

                if (burgerInput.Equals("true") || burgerInput.Equals("false"))
                {
                    validBurger = ("Burger:<" + burgerInput + ">\n");
                    m_newPizzeriaBurgerAvailability = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input, please type 'true/false'");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
            }

            bool m_newPizzeriaDeliveryAvailability = false;
            string validDelivery = String.Empty;
            while (!m_newPizzeriaDeliveryAvailability)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Add delivery availability: (true/false)");
                Console.ForegroundColor = ConsoleColor.Gray;

                string deliveryInput = Console.ReadLine();

                if (deliveryInput.Equals("true") || deliveryInput.Equals("false"))
                {
                    validDelivery = ("Delivery:<" + deliveryInput + ">\n");
                    m_newPizzeriaDeliveryAvailability = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input, please type 'true/false'");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
            }

            string newPizzeria = "{\n" + m_newPizzeriaName + m_newPizzeriaAddress + m_newPizzeriaNumber + validKebab + validBurger + validDelivery + "}";

            using (StreamWriter sw = File.AppendText(GetFullPizzeriaListPath()))
            {
                sw.WriteLine(newPizzeria);
            }
        }

        // Return the new added pizzeria object
        public Pizzeria GetNewPizzeria()
        {
            int start = m_newPizzeriaName.IndexOf("<") + "<".Length;
            int end = m_newPizzeriaName.LastIndexOf(">");
            string name = m_newPizzeriaName.Substring(start, end - start);

            start = m_newPizzeriaAddress.IndexOf("<") + "<".Length;
            end = m_newPizzeriaAddress.LastIndexOf(">");
            string address = m_newPizzeriaAddress.Substring(start, end - start);

            start = m_newPizzeriaNumber.IndexOf("<") + "<".Length;
            end = m_newPizzeriaNumber.LastIndexOf(">");
            string number = m_newPizzeriaNumber.Substring(start, end - start);

            Pizzeria newPizzeria = new Pizzeria(name, address, number, m_newPizzeriaKebabAvailability, m_newPizzeriaBurgerAvailability, m_newPizzeriaDeliveryAvailability);

            return newPizzeria;
        }

        // Remove pizzeria from the pizzeria file
        public void RemoveFromFile(string pizzeriaName, string filePath, string pizzeriaFileText)
        {
            Collection<string> pizzaCollection = new Collection<string>();
            string[] pizzerias = Regex.Split(pizzeriaFileText, @"(?<=[}])");

            foreach (string pizzeria in pizzerias)
            {
                // Add each pizzeria from the pizzeria list to a collection
                pizzaCollection.Add(pizzeria);

                string[] properties = Regex.Split(pizzeria, @"(?<=[>])");
                foreach (string property in properties)
                {
                    if (property.Contains("Name"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string name = property.Substring(start, end - start);

                        if (name.Equals(pizzeriaName))
                        {
                            // Remove the specific pizzeria from the collection
                            pizzaCollection.Remove(pizzeria);

                            // Clear the pizzeria file
                            File.WriteAllText(filePath, String.Empty);
                        }
                    }
                }
            }

            // Clean empty lines and whitespace, add the collection of pizzerias to a string
            string finalPizzerias = Regex.Replace(string.Join("\n", pizzaCollection), @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
            if (finalPizzerias != String.Empty)
            {
                // Add rest of the pizzerias to the file
                File.WriteAllText(filePath, finalPizzerias);
            }
        }

        public void AddToVisitedFile(string pizzeriaName)
        {
            Collection<string> pizzaCollection = new Collection<string>();
            Collection<string> visitedPizzeriasCollection = new Collection<string>();

            string filePathVisited = GetVisitedPizzeriaListPath();

            if (!File.Exists(filePathVisited))
            {
                Console.WriteLine("pizzeria file not found! ");// make exit
            }

            string text = PizzeriaFileToString(GetFullPizzeriaListPath());

            string[] pizzerias = Regex.Split(text, @"(?<=[}])");

            foreach (string pizzeria in pizzerias)
            {
                // Add each pizzeria from the pizzeria list to a collection
                pizzaCollection.Add(pizzeria);

                string[] properties = Regex.Split(pizzeria, @"(?<=[>])");
                foreach (string property in properties)
                {
                    if (property.Contains("Name"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string name = property.Substring(start, end - start);

                        if (name.Equals(pizzeriaName))
                        {
                            visitedPizzeriasCollection.Add(pizzeria);
                        }
                    }
                }
            }

            string pizzeriaToBeAdded = Regex.Replace(string.Join("\n", visitedPizzeriasCollection), @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);

            RemoveFromFile(pizzeriaName, GetNonVisitedPizzeriaListPath(), PizzeriaFileToString(GetNonVisitedPizzeriaListPath()));

            using (StreamWriter sw = File.AppendText(filePathVisited))
            {
                sw.WriteLine(pizzeriaToBeAdded);
            }
        }


        public void AddToNonVisitedFile(string pizzeriaName)
        {
            Collection<string> pizzaCollection = new Collection<string>();
            Collection<string> nonVisitedPizzeriasCollection = new Collection<string>();

            string filePathNonVisited = GetNonVisitedPizzeriaListPath();

            if (!File.Exists(filePathNonVisited))
            {
                Console.WriteLine("pizzeria file not found! ");// make exit
            }

            string text = PizzeriaFileToString(GetFullPizzeriaListPath());
            string[] pizzerias = Regex.Split(text, @"(?<=[}])");

            foreach (string pizzeria in pizzerias)
            {
                // Add each pizzeria from the pizzeria list to a collection
                pizzaCollection.Add(pizzeria);

                string[] properties = Regex.Split(pizzeria, @"(?<=[>])");
                foreach (string property in properties)
                {
                    if (property.Contains("Name"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string name = property.Substring(start, end - start);

                        if (name.Equals(pizzeriaName))
                        {
                            nonVisitedPizzeriasCollection.Add(pizzeria);
                        }
                    }
                }
            }

            string pizzeriaToBeAdded = Regex.Replace(string.Join("\n", nonVisitedPizzeriasCollection), @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);

            RemoveFromFile(pizzeriaName, GetVisitedPizzeriaListPath(), PizzeriaFileToString(GetVisitedPizzeriaListPath()));

            using (StreamWriter sw = File.AppendText(filePathNonVisited))
            {
                sw.WriteLine(pizzeriaToBeAdded);
            }
        }


        // Parse pizzeria list file
        // Get the properties of each pizzeria
        public void ParseVisitedFile()
        {
            string text = PizzeriaFileToString(GetVisitedPizzeriaListPath());

            string[] pizzerias = Regex.Split(text, @"(?<=[}])");
            foreach (string pizzeria in pizzerias)
            {
                string[] properties = Regex.Split(pizzeria, @"(?<=[>])");
                foreach (string property in properties)
                {
                    if (property.Contains("Name"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string name = property.Substring(start, end - start);
                        m_visitedName.Add(name);
                    }

                    if (property.Contains("Address"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string address = property.Substring(start, end - start);
                        m_visitedAddress.Add(address);
                    }

                    if (property.Contains("Number"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string number = property.Substring(start, end - start);
                        m_visitedNumber.Add(number);
                    }

                    if (property.Contains("Kebab"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string kebab = property.Substring(start, end - start);
                        if (kebab.Equals("true"))
                        {
                            m_visitedKebab.Add(true);
                        }
                        else if (kebab.Equals("false"))
                        {
                            m_visitedKebab.Add(false);
                        }
                    }

                    if (property.Contains("Burger"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string burger = property.Substring(start, end - start);
                        if (burger.Equals("true"))
                        {
                            m_visitedBurger.Add(true);
                        }
                        else if (burger.Equals("false"))
                        {
                            m_visitedBurger.Add(false);
                        }
                    }

                    if (property.Contains("Delivery"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string delivery = property.Substring(start, end - start);
                        if (delivery.Equals("true"))
                        {
                            m_visitedDelivery.Add(true);
                        }
                        else if (delivery.Equals("false"))
                        {
                            m_visitedDelivery.Add(false);
                        }
                    }
                }
            }
        }

        // Parse non visited pizzeria list file
        // Get the properties of each non visited pizzeria
        public void ParseNonVisitedFile()
        {
            string text = PizzeriaFileToString(GetNonVisitedPizzeriaListPath());

            string[] pizzerias = Regex.Split(text, @"(?<=[}])");
            foreach (string pizzeria in pizzerias)
            {
                string[] properties = Regex.Split(pizzeria, @"(?<=[>])");
                foreach (string property in properties)
                {
                    if (property.Contains("Name"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string name = property.Substring(start, end - start);
                        m_NonVisitedName.Add(name);
                    }

                    if (property.Contains("Address"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string address = property.Substring(start, end - start);
                        m_NonVisitedAddress.Add(address);
                    }

                    if (property.Contains("Number"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string number = property.Substring(start, end - start);
                        m_NonVisitedNumber.Add(number);
                    }

                    if (property.Contains("Kebab"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string kebab = property.Substring(start, end - start);
                        if (kebab.Equals("true"))
                        {
                            m_NonVisitedKebab.Add(true);
                        }
                        else if (kebab.Equals("false"))
                        {
                            m_NonVisitedKebab.Add(false);
                        }
                    }

                    if (property.Contains("Burger"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string burger = property.Substring(start, end - start);
                        if (burger.Equals("true"))
                        {
                            m_NonVisitedBurger.Add(true);
                        }
                        else if (burger.Equals("false"))
                        {
                            m_NonVisitedBurger.Add(false);
                        }
                    }

                    if (property.Contains("Delivery"))
                    {
                        int start = property.IndexOf("<") + "<".Length;
                        int end = property.LastIndexOf(">");
                        string delivery = property.Substring(start, end - start);
                        if (delivery.Equals("true"))
                        {
                            m_NonVisitedDelivery.Add(true);
                        }
                        else if (delivery.Equals("false"))
                        {
                            m_NonVisitedDelivery.Add(false);
                        }
                    }
                }
            }
        }

        public List<string> Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public List<string> Number
        {
            get { return m_number; }
            set { m_number = value; }
        }
        public List<string> Address
        {
            get { return m_address; }
            set { m_address = value; }
        }

        public List<bool> KebabAvailability
        {
            get { return m_kebab; }
            set { m_kebab = value; }
        }

        public List<bool> BurgerAvailability
        {
            get { return m_burger; }
            set { m_burger = value; }
        }

        public List<bool> DeliveryAvailability
        {
            get { return m_delivery; }
            set { m_delivery = value; }
        }

        public List<string> VisitedName
        {
            get { return m_visitedName; }
            set { m_visitedName = value; }
        }

        public List<string> VisitedNumber
        {
            get { return m_visitedNumber; }
            set { m_visitedNumber = value; }
        }
        public List<string> VisitedAddress
        {
            get { return m_visitedAddress; }
            set { m_visitedAddress = value; }
        }

        public List<bool> VisitedKebabAvailability
        {
            get { return m_visitedKebab; }
            set { m_visitedKebab = value; }
        }

        public List<bool> VisitedBurgerAvailability
        {
            get { return m_visitedBurger; }
            set { m_visitedBurger = value; }
        }

        public List<bool> VisitedDeliveryAvailability
        {
            get { return m_visitedDelivery; }
            set { m_visitedDelivery = value; }
        }

        public List<string> NonVisitedName
        {
            get { return m_NonVisitedName; }
            set { m_NonVisitedName = value; }
        }

        public List<string> NonVisitedNumber
        {
            get { return m_NonVisitedNumber; }
            set { m_NonVisitedNumber = value; }
        }
        public List<string> NonVisitedAddress
        {
            get { return m_NonVisitedAddress; }
            set { m_NonVisitedAddress = value; }
        }

        public List<bool> NonVisitedKebabAvailability
        {
            get { return m_NonVisitedKebab; }
            set { m_NonVisitedKebab = value; }
        }

        public List<bool> NonVisitedBurgerAvailability
        {
            get { return m_NonVisitedBurger; }
            set { m_NonVisitedBurger = value; }
        }

        public List<bool> NonVisitedDeliveryAvailability
        {
            get { return m_NonVisitedDelivery; }
            set { m_NonVisitedDelivery = value; }
        }

        static List<string> m_name = new List<string>();
        static List<string> m_address = new List<string>();
        static List<string> m_number = new List<string>();
        static List<bool> m_kebab = new List<bool>();
        static List<bool> m_burger = new List<bool>();
        static List<bool> m_delivery = new List<bool>();

        static List<string> m_visitedName = new List<string>();
        static List<string> m_visitedAddress = new List<string>();
        static List<string> m_visitedNumber = new List<string>();
        static List<bool> m_visitedKebab = new List<bool>();
        static List<bool> m_visitedBurger = new List<bool>();
        static List<bool> m_visitedDelivery = new List<bool>();

        static List<string> m_NonVisitedName = new List<string>();
        static List<string> m_NonVisitedAddress = new List<string>();
        static List<string> m_NonVisitedNumber = new List<string>();
        static List<bool> m_NonVisitedKebab = new List<bool>();
        static List<bool> m_NonVisitedBurger = new List<bool>();
        static List<bool> m_NonVisitedDelivery = new List<bool>();

        string m_newPizzeriaName;
        string m_newPizzeriaAddress;
        string m_newPizzeriaNumber;
        bool m_newPizzeriaKebabAvailability;
        bool m_newPizzeriaBurgerAvailability;
        bool m_newPizzeriaDeliveryAvailability;

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


namespace ROIPizza
{
    class FileHandler
    {

        public string GetPath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string fileDirectory = Directory.GetParent(projectDirectory).Parent.FullName;

            string filePath = (fileDirectory) + "\\ROIPizza\\pizzeriaList.txt";

            return filePath;
        }

        public string FileToString()
        {
            string filePath = GetPath();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("pizzeria file not found! ");// make exit
            }
            else
            {
                Console.WriteLine("Pizzeria file FOUND! ");
            }

            string textString = File.ReadAllText(filePath);

            return textString;
        }

        public void ParseFile()
        {
            string text = FileToString();

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

        public void AddToFile()
        {
            string filePath = GetPath();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("pizzeria file not found! ");// make exit
            }
            else
            {
                Console.WriteLine("Pizzeria file FOUND! ");
            }

            Console.WriteLine("Add name: ");
            string newPizzeriaName = ("Name:<" + Console.ReadLine() + ">\n");
            Console.WriteLine("Add address: ");
            string newPizzeriaAddress = ("Address:<" + Console.ReadLine() + ">\n");
            Console.WriteLine("Add phone number: ");
            string newPizzeriaPhoneNumber = ("Number<" + Console.ReadLine() + ">\n");

            bool validKebab = false;
            string newPizzeriaKebabAvailability = String.Empty;
            while (!validKebab)
            {
                Console.WriteLine("Add kebab availability: (true/false)");
                string kebabInput = Console.ReadLine();

                if (kebabInput.Equals("true") || kebabInput.Equals("false"))
                {
                    newPizzeriaKebabAvailability = ("Kebab:<" + kebabInput + ">\n");
                    validKebab = true;
                }
                else
                {
                    Console.WriteLine("Invalid input, please type 'true/false'");
                    continue;
                }
            }

            bool validBurger = false;
            string newPizzeriaBurgerAvailability = String.Empty;
            while (!validBurger)
            {
                Console.WriteLine("Add burger availability: (true/false)");
                string burgerInput = Console.ReadLine();

                if (burgerInput.Equals("true") || burgerInput.Equals("false"))
                {
                    newPizzeriaBurgerAvailability = ("Burger:<" + burgerInput + ">\n");
                    validBurger = true;
                }
                else
                {
                    Console.WriteLine("Invalid input, please type 'true/false'");
                    continue;
                }
            }

            bool validDelivery = false;
            string newPizzeriaDeliveryAvailability = String.Empty;
            while (!validDelivery)
            {
                Console.WriteLine("Add delivery availability: (true/false)");
                string deliveryInput = Console.ReadLine();

                if (deliveryInput.Equals("true") || deliveryInput.Equals("false"))
                {
                    newPizzeriaDeliveryAvailability = ("Delivery:<" + deliveryInput + ">\n");
                    validDelivery = true;
                }
                else
                {
                    Console.WriteLine("Invalid input, please type 'true/false'");
                    continue;
                }
            }

            string newpizzeria = "{\n" + newPizzeriaName + newPizzeriaAddress + newPizzeriaPhoneNumber + newPizzeriaKebabAvailability + newPizzeriaBurgerAvailability + newPizzeriaDeliveryAvailability + "}";

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(newpizzeria);
            }

            Console.WriteLine("New pizzeria added successfully.");
        }

        public void RemoveFromFile()
        {
            string text = FileToString();

            Console.WriteLine("Enter pizzeria to be deleted: ");
            string input = Console.ReadLine();

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
                        if (name.Equals(input))
                        {
                            Console.WriteLine("pizzeria found!! !");

                            // TODO: implement delete here... (time consuming task)
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

        static List<string> m_name = new List<string>();
        static List<string> m_address = new List<string>();
        static List<string> m_number = new List<string>();
        static List<bool> m_kebab = new List<bool>();
        static List<bool> m_burger = new List<bool>();
        static List<bool> m_delivery = new List<bool>();

    }
}

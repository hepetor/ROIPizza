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
            m_newPizzeriaName = ("Name:<" + Console.ReadLine() + ">\n");
            Console.WriteLine("Add address: ");
            m_newPizzeriaAddress = ("Address:<" + Console.ReadLine() + ">\n");
            Console.WriteLine("Add phone number: ");
            m_newPizzeriaNumber = ("Number:<" + Console.ReadLine() + ">\n");

            bool m_newPizzeriaKebabAvailability = false;
            string validKebab = String.Empty;
            while (!m_newPizzeriaKebabAvailability)
            {
                Console.WriteLine("Add kebab availability: (true/false)");
                string kebabInput = Console.ReadLine();

                if (kebabInput.Equals("true") || kebabInput.Equals("false"))
                {
                    validKebab = ("Kebab:<" + kebabInput + ">\n");
                    m_newPizzeriaKebabAvailability = true;
                }
                else
                {
                    Console.WriteLine("Invalid input, please type 'true/false'");
                    continue;
                }
            }

            bool m_newPizzeriaBurgerAvailability = false;
            string validBurger = String.Empty;
            while (!m_newPizzeriaBurgerAvailability)
            {
                Console.WriteLine("Add burger availability: (true/false)");
                string burgerInput = Console.ReadLine();

                if (burgerInput.Equals("true") || burgerInput.Equals("false"))
                {
                    validBurger = ("Burger:<" + burgerInput + ">\n");
                    m_newPizzeriaBurgerAvailability = true;
                }
                else
                {
                    Console.WriteLine("Invalid input, please type 'true/false'");
                    continue;
                }
            }

            bool m_newPizzeriaDeliveryAvailability = false;
            string validDelivery = String.Empty;
            while (!m_newPizzeriaDeliveryAvailability)
            {
                Console.WriteLine("Add delivery availability: (true/false)");
                string deliveryInput = Console.ReadLine();

                if (deliveryInput.Equals("true") || deliveryInput.Equals("false"))
                {
                    validDelivery = ("Delivery:<" + deliveryInput + ">\n");
                    m_newPizzeriaDeliveryAvailability = true;
                }
                else
                {
                    Console.WriteLine("Invalid input, please type 'true/false'");
                    continue;
                }
            }

            string newPizzeria = "{\n" + m_newPizzeriaName + m_newPizzeriaAddress + m_newPizzeriaNumber + validKebab + validBurger + validDelivery + "}";

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(newPizzeria);
            }
        }

        public Pizzeria GetNewPizzeria()
        {
            Console.WriteLine(m_newPizzeriaName);

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

        string m_newPizzeriaName;
        string m_newPizzeriaAddress;
        string m_newPizzeriaNumber;
        bool m_newPizzeriaKebabAvailability;
        bool m_newPizzeriaBurgerAvailability;
        bool m_newPizzeriaDeliveryAvailability;

    }
}

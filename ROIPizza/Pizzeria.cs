using System;

public class Pizzeria
{
    public Pizzeria() { }

    public string Name
    {
        get { return m_name; }
        set { m_name = value; }
    }

    public string Number
    {
        get { return m_number; }
        set { m_number = value; }
    }
    public string Address
    {
        get { return m_address; }
        set { m_address = value; }
    }

    public bool KebabAvailability
    {
        get { return m_kebab; }
        set { m_kebab = value; }
    }

    public bool BurgerAvailability
    {
        get { return m_burger; }
        set { m_burger = value; }
    }

    public bool DeliveryAvailability
    {
        get { return m_delivery; }
        set { m_delivery = value; }
    }

    private String m_name;
    private String m_number;
    private String m_address;
    private bool m_kebab;
    private bool m_burger;
    private bool m_delivery;
}

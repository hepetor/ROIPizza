using System;

public class Pizzeria
{
	public Pizzeria()
	{
		//Name = GetName();
	}

	public string GetName()
    {
		return m_name;
    }

	public void SetName(string name)
	{
		m_name = name;
	}

	public string GetNumber()
	{
		return m_number;
	}

	public void SetNumber(string number)
	{
		m_number = number;
	}
	public string GetAddress()
    {
		return m_address;
    }

	public void SetAddress(string address)
	{
		m_address= address;
	}

	public bool HasKebab()
    {
		return m_kebab;
    }

	public bool HasBurger()
	{
		return m_burger;
	}

	public bool HasDelivery()
	{
		return m_delivery;
	}

	private String m_name;
	private String m_number;
	private String m_address;
	private bool m_kebab;
	private bool m_burger;
	private bool m_delivery;
}

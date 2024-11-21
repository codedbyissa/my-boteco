using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Table : ScriptableObject
{
    public int id;
    public bool occupied => customers.Count > 0;
    public List<Customer> customers = new List<Customer>();

    public void AddCustomer(Customer customer)
    {
        if (customers.Count >= 4) return; 
        customers.Add(customer);
    }

    public void RemoveCustomer(Customer customer)
    {
        customers.Remove(customer);
    }
}
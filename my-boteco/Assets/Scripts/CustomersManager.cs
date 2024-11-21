using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CustomersManager : MonoBehaviour
{
    public GameObject customerPrefab; 
    public List<Customer> allCustomers = new List<Customer>();
    private int customerIdCounter = 1;

    public Customer CreateCustomer(GameObject sprite, Table table)
    {
        Customer newCustomer = new Customer(customerIdCounter, sprite, table);
        customerIdCounter++;
        allCustomers.Add(newCustomer);
        return newCustomer;
    }
}

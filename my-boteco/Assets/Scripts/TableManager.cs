using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TableManager : MonoBehaviour
{
    public Table table;
    public Order order;
    private OrderManager orderManager;
    private CustomersManager customerManager;
    private List<GameObject> availableCustomers;


    void Start()
    {
        customerManager = FindObjectOfType<CustomersManager>();
        orderManager = FindObjectOfType<OrderManager>();
    }

    public void GenerateCustomers()
    {    
        availableCustomers = new List<GameObject>();
        foreach (Transform child in customerManager.customerPrefab.transform)
        {
            availableCustomers.Add(child.gameObject);
        }

        if (table.occupied) return;

        int customerCount = Random.Range(1, 5);
        List<GameObject> usedCustomers = new List<GameObject>();

        for (int i = 0; i < customerCount; i++)
        {
            // int randomIndex = Random.Range(0, availableCustomers.Count);
            // GameObject selectedCustomer = availableCustomers[randomIndex];
            
            GameObject customerClone = Instantiate(customerManager.customerPrefab, transform.position, Quaternion.identity);
            customerClone.transform.SetParent(this.transform);
            
            Customer newCustomer = customerManager.CreateCustomer(sprite: null, table: table);
            table.AddCustomer(newCustomer);

            // availableCustomers.RemoveAt(randomIndex);
        }
    }

}


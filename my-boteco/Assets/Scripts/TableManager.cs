using UnityEngine;

public class TableManager : MonoBehaviour
{
    public Table table;  

    public Order order;
    private OrderManager orderManager;

    public Customer customer;

    void Start()
    {
        orderManager = FindObjectOfType<OrderManager>();
        order = orderManager.NewOrder(table);
    }
}


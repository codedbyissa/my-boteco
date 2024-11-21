using UnityEngine;

public class TakeOrder : MonoBehaviour
{
    public Table table;
    public Order order;
    private OrderManager orderManager;

    void Start()
    {
        orderManager = FindObjectOfType<OrderManager>();
    }

    public void GenerateOrders()
    {
        order = orderManager.NewOrder(table);
    }
}
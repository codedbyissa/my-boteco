using System.Collections.Generic;

public enum OrderStatus { Waiting, Late, Delivered, Undelivered }

public class Order
{
    public List<IOrderItem> Content { get; private set; } = new List<IOrderItem>();
    public OrderStatus Status { get; set; } = OrderStatus.Waiting;
    public Table Table;
    public float TotalTime { get; private set; }
    public float RemainingTime { get; set; }

    public Order(List<IOrderItem> content)
    {
        Content = content;
        TotalTime = CalculateTotalTime();
        RemainingTime = TotalTime;
    }

    private float CalculateTotalTime()
    {
        float total = 60;
        foreach (var item in Content)
        {
            total += item.ItemTime;
        }
        return total;
    }
}

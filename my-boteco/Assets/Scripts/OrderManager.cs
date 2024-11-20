using System.Collections.Generic;
using System.Collections;
using TMPro;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public List<Drink> availableDrinks;
    public List<Meal> availableMeals;

    [Header("UI Elements")]
    public Transform itemsPanel; 
    public GameObject orderItemPrefab;

    public Table tableEX;

    public TextMeshProUGUI OrderCount;

    public List<Order> orders = new List<Order>();


    void Start()
    {
    }

    public Order NewOrder(Table Table)
    {
        List<IOrderItem> orderContent = new List<IOrderItem>();
        int randomItemsNumber = Random.Range(2, 5);

        for (int i = 0; i < randomItemsNumber; i++)
        {
            orderContent.Add(availableDrinks[Random.Range(0, availableDrinks.Count)]); 
        }

        Order newOrder = new Order(orderContent);
        newOrder.Table = Table;
        renderOrder(newOrder);
        orders.Add(newOrder);

        OrderCount.text = "(" + orders.Count + ")";

        return newOrder;
    }

    private void renderOrder(Order order)
    {
        GameObject newItem = Instantiate(orderItemPrefab, itemsPanel);
        TMP_Text itemsText = newItem.GetComponentInChildren<TMP_Text>();
        itemsText.text = "Pedido: ";
        for (int i = 0; i < order.Content.Count; i++)
        {
            var item = order.Content[i];
            itemsText.text += "• " + item.ItemName;
            if (i != order.Content.Count - 1)
            {
                itemsText.text += "\n";
            }
        }

        TMP_Text Table = Instantiate(itemsText, newItem.transform);
        Table.text = "Mesa: 0" + order.Table.id;

        TMP_Text TotalTime = Instantiate(itemsText, newItem.transform);
        TotalTime.text = "Tempo Total: " + order.TotalTime + "s";

        TMP_Text RemainingTime = Instantiate(itemsText, newItem.transform);
        RemainingTime.text = "Tempo Restante: " + order.RemainingTime + "s";
        
        LayoutRebuilder.ForceRebuildLayoutImmediate(newItem.GetComponent<RectTransform>());
        LayoutRebuilder.ForceRebuildLayoutImmediate(itemsPanel.GetComponent<RectTransform>());

        StartCoroutine(UpdateRemainingTime(RemainingTime, order));

    }

    private IEnumerator UpdateRemainingTime(TMP_Text remainingTimeText, Order order)
    {
        float remainingTime = order.RemainingTime;
        while (remainingTime > 0)
        {
            remainingTimeText.text = "Tempo Restante: " + Mathf.CeilToInt(remainingTime) + "s";
        
            remainingTime -= Time.deltaTime;
            yield return null;
        }

        remainingTimeText.text = "Tempo Restante: 0s";
        order.Status = OrderStatus.Late;
    }
}

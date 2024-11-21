using UnityEngine;


public enum CustomerMood {Happy, SlightlyImpatient, Frustrated, Irritated}

public enum CustomerStatus {waiting_for_service, waiting_for_the_order, eating, leaving}

public class Customer
{
    public int id;
    public GameObject sprite;
    public CustomerMood mood = CustomerMood.Happy;
    public CustomerStatus status = CustomerStatus.waiting_for_the_order;
    public int review = 0;
    public Table table;

    public Customer(int id, GameObject sprite, Table table)
    {
        this.id = id;
        this.sprite = sprite;
        this.table = table;
    }
}


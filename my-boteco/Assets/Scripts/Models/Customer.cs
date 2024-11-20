using UnityEngine;

[CreateAssetMenu(menuName = "Menu/Customer")]
public class Customer : ScriptableObject
{
    public int id;
    public Sprite sprite;

    public enum Mood {Happy, SlightlyImpatient, Frustrated, Irritated};

    public enum Status {waiting_for_service, waiting_for_the_order, eating, leaving}

    public int reviews;

    public Table table;

}


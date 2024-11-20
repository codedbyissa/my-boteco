using UnityEngine;
public interface IOrderItem
{
    int Id { get; }
    string ItemName { get; }
    int ItemTime { get; }
    Sprite Sprite { get; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrderPlayer : MonoBehaviour
{
    private SpriteRenderer _spriteRender;
    private int currentOrder;
    private int collisionCount = 0;

    void Awake()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
        currentOrder = _spriteRender.sortingOrder;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionCount++;  // Incrementa o número de colisões ativas
        _spriteRender.sortingOrder = 30;  // Altera o sortingOrder enquanto colide
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCount--;  // Decrementa o número de colisões ativas

        if (collisionCount <= 0)  // Só restaura o sortingOrder original quando não há mais colisões
        {
            _spriteRender.sortingOrder = currentOrder;
        }
    }
}


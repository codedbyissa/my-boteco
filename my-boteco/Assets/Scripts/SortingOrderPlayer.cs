using System;
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
        if (!collision.GetComponent<ShowOnProximity>()){
            collisionCount++;  
            _spriteRender.sortingOrder = 30; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!collision.GetComponent<ShowOnProximity>())
        {
            collisionCount--;  

            if (collisionCount <= 0)  
            {
                _spriteRender.sortingOrder = currentOrder;
            }
        }
    }
}


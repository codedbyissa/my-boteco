using System;
using System.Collections.Generic;
using UnityEngine;

public class InterfacesControl : MonoBehaviour
{
    private Dictionary<int, Action<bool>> interfaces;
    private int currentInteractionId = -1;
    private bool isUIOpen = false;

    public PrepareDrink prepareDrink;

    void Start()
    {
        interfaces = new Dictionary<int, Action<bool>>
        {
            { 1, prepareDrink.OpenUI }
        };
    }

    void Update()
    {
        if (currentInteractionId != -1 && Input.GetKeyDown(KeyCode.X))
        {
            isUIOpen = !isUIOpen;
            interfaces[currentInteractionId]?.Invoke(isUIOpen);
            GetComponent<PlayerController>().enabled = !isUIOpen;
        }
    }

    public void SetCurrentInteraction(int id)
    {
        currentInteractionId = id;
    }

        public void OnUIClose()
    {
        isUIOpen = false;
        GetComponent<PlayerController>().enabled = true;
    }
}



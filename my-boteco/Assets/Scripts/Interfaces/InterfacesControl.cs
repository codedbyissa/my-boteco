using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
 
public class InterfacesControl : MonoBehaviour
{
    private Dictionary<int, Delegate> interfaces;
    private int currentInteractionId = -1;
    private bool isUIOpen = false;
    public PrepareDrink prepareDrink;
    public TableManager[] tableManagers;

    public TakeOrder takeOrder;

    void Start()
    {
        interfaces = new Dictionary<int, Delegate>
        {
            { 1, new Action<bool>(prepareDrink.OpenUI) },
            { 2, new Action(InitTableManagers) },
            { 3, new Action(TakeOrder) }
        };
    }

    void Update()
    {
        if (currentInteractionId != -1 && Input.GetKeyDown(KeyCode.X))
        {

            if(currentInteractionId == 1){
                isUIOpen = !isUIOpen;
                GetComponent<PlayerController>().enabled = !isUIOpen;
            }
            
            if (interfaces.TryGetValue(currentInteractionId, out var action))
            {
                if (action is Action<bool> boolAction)
                {
                    boolAction.Invoke(isUIOpen);
                } else if (action is Action noParamAction)
                {
                    noParamAction.Invoke();
                }
            }
            
            
        }

    }

    public void SetCurrentInteraction(int id)
    {
        currentInteractionId = id;
    }

    public void SetTakeOrder(TakeOrder getTakeOrder)
    {
        takeOrder = getTakeOrder;
    }

        public void OnUIClose()
    {
        isUIOpen = false;
        GetComponent<PlayerController>().enabled = true;
    }

    private void TakeOrder()
    {
        takeOrder.GenerateOrders();
    }

    private void InitTableManagers()
    {
        StartCoroutine(GenerateTableCustomers());
    }

    private IEnumerator GenerateTableCustomers()
    {
        foreach (var tableManager in tableManagers)
        {
            tableManager.GenerateCustomers();
            yield return new WaitForSeconds(1f);
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareDrink : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void OpenUI(bool value)
    {
        gameObject.SetActive(value);

        if(value){
            InstructionManager.Instance.ShowMessage("Use as setas do teclado para passar o item e clique em preparar quando escolher o desejado");
        } else {
            InstructionManager.Instance.HideMessage();
        }
    }
}

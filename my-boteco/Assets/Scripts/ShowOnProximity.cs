using UnityEngine;

public class ShowOnProximity : MonoBehaviour
{
    public GameObject player;
    private Renderer objectRenderer;
    public int id;

    private InterfacesControl interfacesControl;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectRenderer.enabled = false;
        interfacesControl = player.GetComponent<InterfacesControl>();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            objectRenderer.enabled = true;
            InstructionManager.Instance.ShowMessage("Pressione [X] para interagir!");
            interfacesControl.SetCurrentInteraction(id);
        }

        TakeOrder takeOrder = GetComponent<TakeOrder>();
        if (takeOrder != null) {
            interfacesControl.SetTakeOrder(takeOrder);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            objectRenderer.enabled = false;
            InstructionManager.Instance.HideMessage();
            interfacesControl.SetCurrentInteraction(-1);
        }
    }
}


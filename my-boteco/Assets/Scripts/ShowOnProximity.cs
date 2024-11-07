using UnityEngine;

public class ShowOnProximity : MonoBehaviour
{
    public GameObject player;
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectRenderer.enabled = false; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player) 
        {
            objectRenderer.enabled = true; 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player) 
        {
            objectRenderer.enabled = false; 
        }
    }
}

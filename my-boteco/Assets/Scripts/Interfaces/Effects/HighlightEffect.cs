using UnityEngine;

public class HighlightEffect : MonoBehaviour
{
    private float timer = 0f;
    private bool isFading = false;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.5f)
        {
            isFading = !isFading;
            GetComponent<CanvasGroup>().alpha = isFading ? 0.5f : 1f;
            timer = 0f;
        }
    }
} 

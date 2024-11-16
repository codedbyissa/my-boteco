using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    public static InstructionManager Instance;
    public TextMeshProUGUI instructionText;
    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void ShowMessage(string message)
    {
        if (instructionText != null)
        {
            instructionText.text = message; 
            panel.SetActive(true);
        }
    }

    public void HideMessage()
    {
        panel.SetActive(false);
        instructionText.text = ""; 
    }
}

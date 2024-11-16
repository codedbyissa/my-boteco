using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrepareDrink : MonoBehaviour
{
    [SerializeField] Button closeUI;
    [SerializeField] private Button prepareButton;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject highlightPrefab;

    private List<GameObject> items = new List<GameObject>();
    private int currentIndex = 0;
    private bool isItemSelected = false;

    private GameObject currentHighlight;
    private GameObject prepareHighlight;
    
    private InterfacesControl interfacesControl;

    private Color colorSelect;

     private Color colorConfirm;

    private void Awake(){
        closeUI.onClick.AddListener(delegate { OpenUI(false); });
        prepareButton.onClick.AddListener(delegate { ConfirmSelection(); });
    }

    void Start()
    {
        gameObject.SetActive(false);
        interfacesControl = FindObjectOfType<InterfacesControl>();
        ColorUtility.TryParseHtmlString("#F1FF8360", out colorSelect);
        ColorUtility.TryParseHtmlString("#4353a990", out colorConfirm);

        foreach (Transform child in content)
        {
            items.Add(child.gameObject);
        }

        ResetState();
    }

    void Update()
    {
        if (!gameObject.activeSelf) return;

        if (!isItemSelected)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                NavigateToNextItem();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(!isItemSelected){
                SelectItem();
            } else {
                ConfirmSelection();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isItemSelected)
        {
            CancelSelection();
        }
    }

    private void NavigateToNextItem()
    {
        currentIndex = (currentIndex + 1) % items.Count;
        RemoveHighlight(items[currentIndex]);
        AddHighlight(items[currentIndex], colorSelect);

    }

    private void SelectItem()
    {
        isItemSelected = true;

        RemoveHighlight(items[currentIndex]);

        AddHighlight(items[currentIndex], colorConfirm);

        AddPrepareHighlight();
    }

    private void CancelSelection()
    {
        isItemSelected = false;

        RemoveHighlight(items[currentIndex]);

        AddHighlight(items[currentIndex], colorSelect);

        RemovePrepareHighlight();
    }

    private void ConfirmSelection()
    {
        if (isItemSelected)
        {
            OpenUI(false);
        }
    }

    private void AddHighlight(GameObject item, Color color)
    {
        if (currentHighlight == null)
        {
            currentHighlight = Instantiate(highlightPrefab, item.transform);
        }

        currentHighlight.GetComponent<Image>().color = color;
        currentHighlight.SetActive(true);
    }

    private void RemoveHighlight(GameObject item)
    {
        // Remove a borda de highlight se houver
        if (currentHighlight != null)
        {
            Destroy(currentHighlight);
            currentHighlight = null; // Reseta a referência
        }
    }

    private void AddPrepareHighlight()
    {
        if (prepareHighlight == null)
        {
            prepareHighlight = Instantiate(highlightPrefab, prepareButton.transform);
        }
        prepareHighlight.GetComponent<Image>().color = colorConfirm;
        prepareHighlight.SetActive(true);
        RectTransform itemRect = prepareButton.GetComponent<RectTransform>();
        RectTransform highlightRect = prepareHighlight.GetComponent<RectTransform>();
        highlightRect.sizeDelta = new Vector2(itemRect.rect.width, itemRect.rect.height);
        highlightRect.anchoredPosition = Vector2.zero;
    }

    private void RemovePrepareHighlight()
    {
        if (prepareHighlight != null)
        {
            Destroy(prepareHighlight);
            prepareHighlight = null; // Reseta a referência
        }
    }

    private void ResetState()
    {
        currentIndex = 0;
        isItemSelected = false;

        foreach (var item in items)
        {
            RemoveHighlight(item);
        }
        RemovePrepareHighlight();

        AddHighlight(items[currentIndex], colorSelect);
    }

    public void OpenUI(bool value)
    {
        AddHighlight(items[currentIndex], colorSelect);
        gameObject.SetActive(value);

        if(value)
        {
            InstructionManager.Instance.ShowMessage("Use a seta direita do teclado [>] para navegar entre os itens. Pressione [Enter] para selecionar um item ou [ESC] para voltar e escolher outro.\nPressione [Enter] novamente para confirmar e preparar");
        }
        else
        {
            InstructionManager.Instance.HideMessage();
            interfacesControl.OnUIClose();
            ResetState();
        }
    }
}

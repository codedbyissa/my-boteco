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

    [SerializeField] private GameObject progressBarPrefab;
    [SerializeField] private GameObject drinksObj;

    private List<GameObject> items = new List<GameObject>();
    private int currentIndex = 0;
    private bool isItemSelected = false;

    private GameObject currentHighlight;
    private GameObject prepareHighlight;
    
    private InterfacesControl interfacesControl;

    private Color colorSelect;

    private Color colorConfirm;

    private DrinkHolder itemSelected;

    private LoadItem loadItem;

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
                
            } else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                SelectItem();
            }
        } else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ConfirmSelection(); 

        } else if (Input.GetKeyDown(KeyCode.Escape))
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

        itemSelected = items[currentIndex].GetComponent<DrinkHolder>();

        RemoveHighlight(items[currentIndex]);

        AddHighlight(items[currentIndex], colorConfirm);

        AddPrepareHighlight();
    }

    private void CancelSelection()
    {
        isItemSelected = false;
        itemSelected = null;

        RemoveHighlight(items[currentIndex]);

        AddHighlight(items[currentIndex], colorSelect);

        RemovePrepareHighlight();
    }

    private void ConfirmSelection()
    {
        if (isItemSelected)
        {
            loadItem = ScriptableObject.CreateInstance<LoadItem>();
            loadItem.sprite = itemSelected.drink.sprite;
            loadItem.itemName = itemSelected.drink.itemName;
            loadItem.itemTag = SlotTag.Drink;
            loadItem.itemTime = itemSelected.drink.itemTime;
            SpawnProgressBar(drinksObj.transform, loadItem);
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
        
        if (currentHighlight != null)
        {
            Destroy(currentHighlight);
            currentHighlight = null; 
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
            prepareHighlight = null; 
        }
    }

    public void SpawnProgressBar(Transform targetTransform, LoadItem loadItem)
    {
        GameObject newBar = Instantiate(progressBarPrefab, targetTransform.position, Quaternion.identity);
        LoadingItem progressBar = newBar.GetComponent<LoadingItem>();
        if (progressBar != null)
        {
            progressBar.Initialize(targetTransform, loadItem);
        }
    }


    private void ResetState()
    {
        currentIndex = 0;
        isItemSelected = false;
        itemSelected = null;

        foreach (var item in items)
        {
            RemoveHighlight(item);
        }
        RemovePrepareHighlight();

        AddHighlight(items[currentIndex], colorSelect);
    }

    public void OpenUI(bool value)
    {
        gameObject.SetActive(value);

        if(value)
        {
            InstructionManager.Instance.ShowMessage("Use a seta direita do teclado [>] para navegar entre os itens. Pressione [Enter] para selecionar um item e [Enter] novamente para confirmar e\n iniciar o preparo ou [ESC] para voltar e escolher outro. Pressione [X] para cancelar e sair da intereção.");
            ResetState();
        }
        else
        {
            InstructionManager.Instance.HideMessage();
            interfacesControl.OnUIClose();
        }
    }
}

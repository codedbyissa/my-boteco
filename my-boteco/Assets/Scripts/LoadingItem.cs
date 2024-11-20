using UnityEngine;
using TMPro;
using System.Linq;

public class LoadingItem : MonoBehaviour
{
    [SerializeField] private SlotManager[] slotManager;
    private TextMeshPro countdownText; 
    private SpriteRenderer fillBar;
    private SpriteRenderer backgroundBar;
    private Transform target;

    private LoadItem loadItem;
    private float elapsedTime;
    private bool isActive = false;
    private const float startScale = 1.5038f;
    private const float endScale = 0.001385002f;
    private const float startPosition = -0.6612f;
    private const float endPosition = -1.4124f;

    private void Awake()
    {
        fillBar = transform.Find("ProgressBarFill")?.GetComponent<SpriteRenderer>();
        backgroundBar = transform.Find("ProgressBarBackground")?.GetComponent<SpriteRenderer>();
        countdownText = transform.Find("count")?.GetComponent<TextMeshPro>();
        slotManager = FindObjectsOfType<SlotManager>();
    }

    public void Initialize(Transform targetObject, LoadItem item)
    {
        target = targetObject;
        loadItem = item;
        elapsedTime = 0f;
        isActive = true;
        UpdateFill(1f);
        
        Vector3 posicaoOrigem = target.position;
        transform.position = new Vector3(posicaoOrigem.x, -(posicaoOrigem.y - 0.5f), posicaoOrigem.z);

    }

    private void Update()
    {
        if (!isActive || target == null) return;

        elapsedTime += Time.deltaTime;
        float remainingTime = Mathf.Clamp01(1f - elapsedTime / loadItem.itemTime);
        UpdateFill(remainingTime);
        UpdateCountdownText(remainingTime);
        if (remainingTime <= 0f)
        {
            ItemSlot newItemSlot = ScriptableObject.CreateInstance<ItemSlot>();
            newItemSlot.sprite = loadItem.sprite;
            newItemSlot.itemName = loadItem.itemName;
            newItemSlot.itemTag = loadItem.itemTag;
            AssignItemToSlot(newItemSlot);
            Destroy(gameObject);
        }
    }

    private void UpdateFill(float fillAmount)
    {
        if (fillBar != null)
        {
            float scaleValue = Mathf.Lerp(startScale, endScale, 1 - fillAmount);
            fillBar.transform.localScale = new Vector3(scaleValue, fillBar.transform.localScale.y, fillBar.transform.localScale.z);
            float positionValue = Mathf.Lerp(startPosition, endPosition, 1 - fillAmount);
            fillBar.transform.localPosition = new Vector3(positionValue, fillBar.transform.localPosition.y, fillBar.transform.localPosition.z);
        }
    }

    private void UpdateCountdownText(float remainingTime)
    {
        if (countdownText != null)
        {
            int seconds = Mathf.CeilToInt(remainingTime * loadItem.itemTime);
            countdownText.text = $"{seconds}s"; 
        }
    }

    public void AssignItemToSlot(ItemSlot itemSlot)
    {
        SlotManager availableSlot = slotManager.FirstOrDefault(slot => slot.slot == null);

        if (availableSlot != null)
        {

            availableSlot.EquipItem(itemSlot);
        }
        else
        {
            Debug.LogWarning("Nenhum slot disponível para atribuir o item.");
        }
    }
}

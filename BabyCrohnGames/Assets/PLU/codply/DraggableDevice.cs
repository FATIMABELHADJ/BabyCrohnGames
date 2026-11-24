using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableDevice : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform handPosition;                   // موضع اليد
    public float snapThreshold = 50f;                    // المسافة اللي نعتبر فيها أن الجهاز وصل لليد
    public BloodPressure2D bloodPressureScript;          // مرجع للسكربت اللي فيه القياس
    public Image handImage;                              // صورة اليد
    public Sprite handHoldingDeviceSprite;               // صورة اليد وهي تحمل الجهاز
public Transform deviceTransform; 
    private RectTransform rectTransform;
    private Canvas canvas;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            canvas.worldCamera,
            out localPoint))
        {
            rectTransform.anchoredPosition = localPoint;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float distance = Vector2.Distance(rectTransform.anchoredPosition, handPosition.anchoredPosition);
        if (distance <= snapThreshold)
        {
            rectTransform.anchoredPosition = handPosition.anchoredPosition;

            // 🔁 نغير صورة اليد مباشرة
            if (handImage != null && handHoldingDeviceSprite != null)
            {
                handImage.sprite = handHoldingDeviceSprite;
            }

            // ⏱️ نبدأ عملية القياس
            if (bloodPressureScript != null)
            {
                bloodPressureScript.StartMeasurement();
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData) { }
}

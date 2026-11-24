using UnityEngine;

public class DraggableItem : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // للحصول على SpriteRenderer
        originalColor = spriteRenderer.color; // حفظ اللون الأصلي
    }

    void OnMouseDown()
    {
        // تحديد المسافة بين النقطة التي ضغطت فيها والـ Sprite
        offset = gameObject.transform.position - GetMouseWorldPos();
        isDragging = true;
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f); // خفض الشفافية أثناء السحب (شبح)
    }

    void OnMouseUp()
    {
        isDragging = false;
        spriteRenderer.color = originalColor; // استعادة الشفافية الأصلية عند رفع الماوس
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePoint.z = 0; // نحدد Z لأننا نعمل في 2D
        return mousePoint;
    }
}

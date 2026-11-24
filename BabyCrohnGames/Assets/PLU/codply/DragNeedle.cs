using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DragNeedle : MonoBehaviour
{
    private Vector3 offset;
    private bool dragging = false;
    private Vector3 originalPosition;

    void Start()
    {
        // نحفظ الموقع الأصلي للإبرة
        originalPosition = transform.position;
    }

    void OnMouseDown()
    {
        if (BloodDraw.IsDrawing) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // ✅ نثبت Z
        offset = transform.position - mousePos;
        offset.z = 0;
        dragging = true;
    }

    void OnMouseDrag()
    {
        if (!dragging || BloodDraw.IsDrawing) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // ✅ نثبت Z باش ما تروحش بعيد
        transform.position = mousePos + offset;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    // ✅ دالة ترجع الموقع الأصلي
    public Vector3 GetOriginalPosition()
    {
        return originalPosition;
    }

    // 🆕 دالة اختيارية لإرجاع الإبرة لمكانها
    public void ResetNeedlePosition()
    {
        transform.position = originalPosition;
    }
}

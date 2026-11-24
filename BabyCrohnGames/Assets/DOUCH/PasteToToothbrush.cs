using UnityEngine;

public class PasteToToothbrush : MonoBehaviour
{
    public Transform toothbrush;               // مرجع للفرشاة
    public SpriteRenderer pasteSprite;         // Renderer المعجون
    public Sprite pasteOnToothbrushSprite;     // صورة المعجون عند وضعه على الفرشاة
    public SpriteRenderer toothbrushSprite;    // Renderer الفرشاة
    public Sprite toothbrushWithPaste;         // صورة الفرشاة بعد إضافة المعجون
    public float moveSpeed = 2f;               // سرعة تحريك المعجون نحو الفرشاة
    private bool hasTransferred = false;       // لتتبع ما إذا تم وضع المعجون على الفرشاة
    private Vector3 offset;                   // مسافة السحب
    private bool isDragging = false;          // لتتبع حالة السحب

    void Update()
    {
        if (isDragging)
        {
            // السحب يدويًا باستخدام الماوس
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }

        if (!hasTransferred)
        {
            // إذا كان المعجون قريب من الفرشاة
            if (Vector2.Distance(transform.position, toothbrush.position) < 0.3f)
            {
                hasTransferred = true;
                
                // تغيير صورة المعجون عند التلامس مع الفرشاة
                if (pasteSprite != null && pasteOnToothbrushSprite != null)
                {
                    pasteSprite.sprite = pasteOnToothbrushSprite;
                }

                // تغيير صورة الفرشاة بعد 0.3 ثانية
                Invoke("UpdateToothbrushSprite", 0.3f);
            }
        }
    }

    void UpdateToothbrushSprite()
    {
        // تغيير صورة الفرشاة بعد وضع المعجون
        if (toothbrushSprite != null && toothbrushWithPaste != null)
        {
            toothbrushSprite.sprite = toothbrushWithPaste;
        }
    }

    // عندما تبدأ السحب
    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    // عندما يتم إنهاء السحب
    void OnMouseUp()
    {
        isDragging = false;
    }
}

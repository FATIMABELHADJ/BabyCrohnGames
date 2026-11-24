using UnityEngine;

public class PasteCollision : MonoBehaviour
{
    public SpriteRenderer toothbrushSpriteRenderer;
    public Sprite toothbrushWithPaste;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Toothbrush"))
        {
            // نبدل صورة الفرشاة
            if (toothbrushSpriteRenderer != null && toothbrushWithPaste != null)
            {
                toothbrushSpriteRenderer.sprite = toothbrushWithPaste;
            }

            // نقدر نضيف تغيير صورة المعجون هنا إذا حبيت
            // GetComponent<SpriteRenderer>().sprite = newPasteSprite;
        }
    }
}

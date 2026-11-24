using UnityEngine;

public class DraggableToothbrush : MonoBehaviour
{
    public Sprite toothbrushWithPaste; // صورة الفرشاة بالمعجون
    private SpriteRenderer spriteRenderer;
    private bool isDragging = false;
    private Vector3 offset;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (spriteRenderer.sprite == toothbrushWithPaste)
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}

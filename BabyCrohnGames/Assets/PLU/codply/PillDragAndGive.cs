using UnityEngine;

public class PillDragAndGive : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalPosition;

    public bool canGive = true;

    [Header("Mouth")]
    public SpriteRenderer mouthRenderer;
    public Sprite mouthOpen;
    public Sprite mouthClosed;

    [Header("Audio")]
    public AudioClip giveSound;
    private AudioSource audioSource;

    void Start()
    {
        originalPosition = transform.position;
        audioSource = GetComponent<AudioSource>();

        if (mouthRenderer != null && mouthClosed != null)
            mouthRenderer.sprite = mouthClosed;
    }

    void OnMouseDown()
    {
        if (!canGive) return;

        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (canGive && other.CompareTag("Mouth"))
        {
            canGive = false;

            Debug.Log("💊 تم إعطاء الدواء!");

            if (mouthRenderer != null && mouthOpen != null)
                mouthRenderer.sprite = mouthOpen;

            if (audioSource != null && giveSound != null)
                audioSource.PlayOneShot(giveSound);

            Invoke("CloseMouth", 1f);
            Invoke("HidePill", 0.5f);

            // استدعاء دالة TaskCompleted من TaskManager عند إتمام المهمة
            TaskManager.instance.TaskCompleted("pill");  // مرر اسم المهمة المناسبة هنا
        }
    }

    void CloseMouth()
    {
        if (mouthRenderer != null && mouthClosed != null)
            mouthRenderer.sprite = mouthClosed;
    }

    void HidePill()
    {
        gameObject.SetActive(false);
    }
}

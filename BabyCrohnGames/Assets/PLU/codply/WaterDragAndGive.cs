using UnityEngine;

public class WaterDragAndGive : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalPosition;
    private bool isReturning = false;

    public bool canGive = true;

    [Header("Mouth")]
    public SpriteRenderer mouthRenderer;
    public Sprite mouthOpen;
    public Sprite mouthClosed;

    [Header("Audio")]
    public AudioClip giveSound;
    private AudioSource audioSource;

    public float returnSpeed = 2f;

    void Start()
    {
        originalPosition = transform.position;
        audioSource = GetComponent<AudioSource>();

        if (mouthRenderer != null && mouthClosed != null)
            mouthRenderer.sprite = mouthClosed;
    }

    void OnMouseDown()
    {
        if (!canGive || isReturning) return;
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

        if (isReturning)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, returnSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, originalPosition) < 0.01f)
            {
                isReturning = false;
                canGive = true;
                if (mouthRenderer != null && mouthClosed != null)
                    mouthRenderer.sprite = mouthClosed;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (canGive && other.CompareTag("Mouth"))
        {
            canGive = false;

            // تشغيل الصوت
            if (audioSource != null && giveSound != null)
                audioSource.PlayOneShot(giveSound);

            // فتح الفم
            if (mouthRenderer != null && mouthOpen != null)
                mouthRenderer.sprite = mouthOpen;

            // بعد ثانية، نرجع الكأس للطاولة تدريجياً
            Invoke("ReturnToTable", 1f);

            // استدعاء دالة TaskCompleted من TaskManager عند إتمام المهمة
            TaskManager.instance.TaskCompleted("water");  // مرر اسم المهمة المناسبة هنا
        }
    }

    void ReturnToTable()
    {
        isReturning = true;
    }
}

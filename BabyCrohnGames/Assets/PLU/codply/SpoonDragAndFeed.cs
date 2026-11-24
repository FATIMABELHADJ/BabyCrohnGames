using UnityEngine;

public class SpoonDragAndFeed : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 originalPosition;
    private Vector3 originalScale;

    private bool hasFed = false;
    private bool isReadyToFeed = true;

    private int feedCount = 0;
    public int maxFeedCount = 7;

    [Header("Spoon Sprites")]
    public Sprite fullSpoonSprite;
    public Sprite emptySpoonSprite;

    [Header("Mouth Sprites")]
    public SpriteRenderer mouthRenderer;
    public Sprite mouthClosedSprite;
    public Sprite mouthOpenSprite;
    public Sprite mouthFullSprite;

    [Header("Audio Clips")]
    public AudioClip feedSound;
    public AudioClip fullSound;

    private AudioSource audioSource;
    private SpriteRenderer spoonRenderer;

    void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;

        spoonRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        spoonRenderer.sprite = fullSpoonSprite;

        if (mouthRenderer != null)
            mouthRenderer.sprite = mouthClosedSprite;
    }

    void OnMouseDown()
    {
        if (!isReadyToFeed || feedCount >= maxFeedCount) return;

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
        if (isReadyToFeed && other.CompareTag("Mouth") && feedCount < maxFeedCount)
        {
            spoonRenderer.sprite = emptySpoonSprite;
            transform.localScale = originalScale;

            if (mouthRenderer != null && mouthOpenSprite != null)
                mouthRenderer.sprite = mouthOpenSprite;

            feedCount++;
            hasFed = true;
            isReadyToFeed = false;

            Debug.Log("✅ تم الإطعام! عدد مرات الإطعام: " + feedCount);

            // ✅ تشغيل صوت الإطعام
            if (audioSource != null && feedSound != null)
                audioSource.PlayOneShot(feedSound);

            if (feedCount >= maxFeedCount)
            {
                Debug.Log("🍽️ الطفل شبع!");
                if (mouthRenderer != null && mouthFullSprite != null)
                    mouthRenderer.sprite = mouthFullSprite;

                // ✅ تشغيل صوت الشبع
                if (audioSource != null && fullSound != null)
                    audioSource.PlayOneShot(fullSound);
            }

            Invoke("ResetSpoon", 1f);

            // استدعاء دالة TaskCompleted من TaskManager عند إتمام المهمة
            TaskManager.instance.TaskCompleted("food");  // مرر اسم المهمة المناسبة هنا
        }
    }

    public void ResetSpoon()
    {
        if (feedCount >= maxFeedCount) return;

        transform.position = originalPosition;
        transform.localScale = originalScale;
        hasFed = false;
        isReadyToFeed = true;

        spoonRenderer.sprite = fullSpoonSprite;

        if (mouthRenderer != null)
            mouthRenderer.sprite = mouthClosedSprite;
    }
}

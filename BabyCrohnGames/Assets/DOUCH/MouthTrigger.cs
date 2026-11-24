using UnityEngine;

public class MouthTrigger : MonoBehaviour
{
    public SpriteRenderer mouthRenderer;
    public Sprite openMouthSprite;     // صورة الفم المفتوح
    public Sprite closedMouthSprite;   // صورة الفم العادي
    public GameObject bubbleParticles; // نظام الفقاعات
    public BrushingManager brushingManager; // السكربت المسؤول عن السلايدر

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Toothbrush"))
        {
            ToothbrushState state = other.GetComponent<ToothbrushState>();
            if (state != null && state.hasPaste)
            {
                if (mouthRenderer != null)
                    mouthRenderer.sprite = openMouthSprite;

                if (bubbleParticles != null)
                    bubbleParticles.SetActive(true);

                if (brushingManager != null)
                    brushingManager.StartBrushing(); // بدأ التنظيف
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Toothbrush"))
        {
            if (mouthRenderer != null)
                mouthRenderer.sprite = closedMouthSprite;

            if (bubbleParticles != null)
                bubbleParticles.SetActive(false);
        }
    }
}

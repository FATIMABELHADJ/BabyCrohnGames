using UnityEngine;

public class BubbleTrigger : MonoBehaviour
{
    public GameObject bubblesEffect;
    public string toothbrushTag = "Toothbrush";
    public AudioSource bubbleSound;

    void Start()
    {
        if (bubblesEffect != null)
        {
            bubblesEffect.SetActive(false);
        }

        if (bubbleSound != null)
        {
            bubbleSound.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(toothbrushTag))
        {
            bubblesEffect.SetActive(true);

            if (bubbleSound != null && !bubbleSound.isPlaying)
            {
                bubbleSound.Play(); // شغّل الصوت
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(toothbrushTag))
        {
            bubblesEffect.SetActive(false);

            if (bubbleSound != null)
            {
                bubbleSound.Stop(); // أوقف الصوت
            }
        }
    }
}

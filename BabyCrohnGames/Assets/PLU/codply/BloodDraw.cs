using UnityEngine;
using UnityEngine.UI;

public class BloodDraw : MonoBehaviour
{
    public static bool IsDrawing = false;

    public Slider bloodSlider;
    private bool isDrawing = false;
    public float drawSpeed = 0.3f;
    public GameObject needle;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BabyHand"))
        {
            isDrawing = true;
            IsDrawing = true;

            // نثبّت الإبرة في مكانها
            if (needle != null)
            {
                var rb = needle.GetComponent<Rigidbody2D>();
                if (rb != null)
                    rb.bodyType = RigidbodyType2D.Static;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("BabyHand"))
        {
            isDrawing = false;
            IsDrawing = false;

            // نرجّع الإبرة قابلة للحركة
            if (needle != null)
            {
                var rb = needle.GetComponent<Rigidbody2D>();
                if (rb != null)
                    rb.bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }

    void Update()
    {
        if (isDrawing && bloodSlider.value < 1f)
        {
            bloodSlider.value += drawSpeed * Time.deltaTime;
        }

        if (bloodSlider.value >= 1f && isDrawing)
        {
            isDrawing = false;
            IsDrawing = false;
            Debug.Log("✅ تم جمع الدم!");
            // تقدر تظهر UI أو تنتقل لمشهد جديد هنا
        }
    }
}

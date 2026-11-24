using UnityEngine;
using UnityEngine.SceneManagement; // لإضافة ميزة الانتقال بين المشاهد
using UnityEngine.UI; // لإضافة دعم النصوص UI

public class DropZone : MonoBehaviour
{
    public GameObject checkmark; // علامة "تم"
    private SpriteRenderer vegetableSprite;
    private AudioSource audioSource; // للحصول على مكون الصوت
    public AudioClip placeSound; // عند وضع الخضار في الطاجين
    public AudioClip oilSound; // عند التفاعل مع الزيت

    public string nextSceneName; // اسم المشهد التالي
    public Text completionText; // النص الذي يظهر عند اكتمال الطهي

    private void Start()
    {
        checkmark.SetActive(false); // في البداية، العلامة مخفية
        completionText.gameObject.SetActive(false); // إخفاء النص في البداية
        audioSource = GetComponent<AudioSource>(); // الحصول على مكون الصوت
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Vegetable")) // إذا كان الكائن الملقى هو خضار
        {
            // إضافة تأثير الشبح (خفض الشفافية)
            vegetableSprite = other.GetComponent<SpriteRenderer>();
            if (vegetableSprite != null)
            {
                vegetableSprite.color = new Color(vegetableSprite.color.r, vegetableSprite.color.g, vegetableSprite.color.b, 0.5f); // تأثير الشبح
            }

            // وضع الخضار داخل الطاجين
            other.transform.position = transform.position; // يحط الخضار في المكان المحدد للطاجين
            other.transform.SetParent(transform); // يخلي الخضار داخل الطاجين

            // تشغيل صوت الزيت عند وضع الخضار
            if (audioSource != null && oilSound != null)
            {
                audioSource.PlayOneShot(oilSound); // تشغيل الصوت عند التفاعل مع الزيت
            }

            // تشغيل الصوت عند وضع الخضار
            if (audioSource != null && placeSound != null)
            {
                audioSource.PlayOneShot(placeSound); // تشغيل الصوت عند وضع الخضار
            }

            // تفعيل علامة "تم"
            checkmark.SetActive(true); // عندما يتم وضع الخضار في الطاجين

            // عرض النص "تم الانتهاء من الطهي!"
            completionText.gameObject.SetActive(true);

            // الانتقال إلى المشهد التالي بعد فترة قصيرة (مثلًا 2 ثانية)
            Invoke("GoToNextScene", 10f); // هنا يتم الانتظار لمدة 2 ثانية قبل الانتقال
        }
    }

    private void GoToNextScene()
    {
        // الانتقال إلى المشهد المحدد
        SceneManager.LoadScene(nextSceneName);
    }

    // إعادة الشفافية بعد إزالة الخضار
    private void ResetVegetableTransparency(Collider2D other)
    {
        if (vegetableSprite != null)
        {
            vegetableSprite.color = new Color(vegetableSprite.color.r, vegetableSprite.color.g, vegetableSprite.color.b, 1f); // استعادة الشفافية
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // إعادة الشفافية بعد الخروج
        if (other.CompareTag("Vegetable"))
        {
            ResetVegetableTransparency(other); // إعادة الشفافية للخضار
        }
    }
}

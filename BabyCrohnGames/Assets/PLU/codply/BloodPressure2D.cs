using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BloodPressure2D : MonoBehaviour
{
    [Header("UI Elements")]
    public Slider pressureSlider;
    public Text resultText;
    public Image handImage;
    public Sprite handHoldingDeviceSprite;

    [Header("Device Settings")]
    public Transform handTransform;
    public Transform deviceTransform;
    public GameObject deviceObject; // الجهاز كـ GameObject كامل

    [Header("Settings")]
    public float activationDistance = 0.5f;
    public float fillDuration = 3f;
    public float resultDisplayDuration = 2f;

    private bool isMeasuring = false;

    void Update()
    {
        // عندما يكون الجهاز قريب من اليد، يتم البدء بالقياس
        if (!isMeasuring && Vector3.Distance(deviceTransform.position, handTransform.position) < activationDistance)
        {
            StartMeasurement();
        }
    }

    public void StartMeasurement()
    {
        if (isMeasuring) return;
        isMeasuring = true;

        // تغيير صورة اليد عند اقتراب الجهاز
        if (handImage != null && handHoldingDeviceSprite != null)
        {
            handImage.sprite = handHoldingDeviceSprite;
        }

        // إخفاء الجهاز
        if (deviceObject != null)
        {
            deviceObject.SetActive(false);
        }

        StartCoroutine(FillPressureSlider());
    }

    IEnumerator FillPressureSlider()
    {
        float elapsed = 0f;
        pressureSlider.value = 0f;

        // ملء السلايدر مع مرور الوقت
        while (elapsed < fillDuration)
        {
            elapsed += Time.deltaTime;
            pressureSlider.value = Mathf.Lerp(0, pressureSlider.maxValue, elapsed / fillDuration);
            yield return null;
        }

        pressureSlider.value = pressureSlider.maxValue;

        // عرض نتيجة قياس ضغط الدم
        resultText.text = "120/80";  // يمكن تعديل القيمة حسب ما تحب
        resultText.gameObject.SetActive(true);

        // تسجيل إتمام المهمة
        PlayerPrefs.SetInt("BloodPressureScene", 1);
        PlayerPrefs.Save();

        // تحديث المهمة في الـ Checklist
        FindObjectOfType<ChecklistManager>().CompleteTask("BloodPressureMeasure");

        // انتظار قبل الرجوع
        yield return new WaitForSeconds(resultDisplayDuration);
        SceneManager.LoadScene("ChecklistManager");
    }
}

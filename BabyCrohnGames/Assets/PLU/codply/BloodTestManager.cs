using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BloodTestManager : MonoBehaviour
{
    public Slider bloodPressureSlider;
    public Text resultText;
    public Text notificationText;
    public GameObject notificationPanel;

    private bool isTesting = false;

    void Start()
    {
        resultText.gameObject.SetActive(false);
        notificationPanel.SetActive(false);
    }

    public void StartBloodDrawing()
    {
        if (!isTesting)
        {
            StartCoroutine(PerformBloodTest());
        }
    }

    private IEnumerator PerformBloodTest()
    {
        Debug.Log("✅ بدأ اختبار الدم");  // لتتبع بداية الاختبار
        isTesting = true;
        bloodPressureSlider.gameObject.SetActive(true);
        notificationPanel.SetActive(true);
        notificationText.text = "القياس جاري...";

        float currentValue = 0f;
        float targetValue = 120f;

        while (currentValue < targetValue)
        {
            currentValue += Time.deltaTime * 10f;
            bloodPressureSlider.value = currentValue;
            yield return null;
        }

        resultText.gameObject.SetActive(true);
        resultText.text = "تم جمع الدم بنجاح!";
        notificationText.text = "القياس اكتمل!";

        yield return new WaitForSeconds(3f);

        Debug.Log("✅ جاري الرجوع إلى مشهد Checklist...");
        
        // التحقق من إمكانية تحميل المشهد
        if (Application.CanStreamedLevelBeLoaded("checklistManager"))
        {
            Debug.Log("✅ المشهد checklistManager يمكن تحميله!");
            SceneManager.LoadScene("checklistManager"); // ✅ تحميل المشهد بعد إتمام القياس
        }
        else
        {
            Debug.LogError("❌ لا يمكن تحميل المشهد: checklistManager. تحقق من الاسم أو من أنه مضاف إلى Build Settings.");
        }
    }
}

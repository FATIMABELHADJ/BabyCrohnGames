using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScanProgress : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject checkListUI;  // واجهة الـ CheckList
    public GameObject scanCompleteUI;  // واجهة اكتمال المسح
    public GameObject scanButton;  // زر البدء

    private bool scanComplete = false;

    void Update()
    {
        if (scanComplete)
        {
            // بمجرد اكتمال المسح، انتقل إلى واجهة CheckList
            checkListUI.SetActive(true);
            scanCompleteUI.SetActive(false);

            // تفعيل علامة "تم" في واجهة CheckList
            // مثال على تفعيل علامة "تم" لمهمة معينة (يمكنك تحديد المهمة بناءً على متطلباتك)
            MarkTaskAsComplete("ScanTask");

            // تأكد من إيقاف الكاميرا أو أي مؤثرات أخرى
            mainCamera.enabled = false;
        }
    }

    // دالة لتفعيل علامة "تم" في واجهة CheckList
    void MarkTaskAsComplete(string taskName)
    {
        // افرض أنه لديك قائمة من المهام في واجهة CheckList
        // هنا يمكنك تنفيذ الكود اللازم لتفعيل العلامة بجانب المهمة
        Debug.Log(taskName + " تم!");
    }

    public void StartScan()
    {
        // بدء المسح
        scanComplete = false;
        scanButton.SetActive(false);  // إخفاء الزر أثناء المسح
        scanCompleteUI.SetActive(true);  // عرض واجهة اكتمال المسح
    }

    public void CompleteScan()
    {
        // عند اكتمال المسح
        scanComplete = true;
    }
}

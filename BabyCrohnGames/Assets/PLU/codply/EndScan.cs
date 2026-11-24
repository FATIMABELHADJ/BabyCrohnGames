using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScan : MonoBehaviour
{
    public string sceneName = "CheckList"; // اسم المشهد الخاص بـ CheckList
    public GameObject checkListPanel;      // لوحة الـ CheckList
    public GameObject taskPanel;           // لوحة المهمة داخل الـ CheckList
    public string taskName = "ScannerTask"; // اسم المهمة المرتبطة بالفحص

    // عند التفاعل مع الـ Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // تحديث حالة المهمة في الـ CheckList (إضافة ✅)
            UpdateTaskStatus();

            // العودة إلى قائمة التحقق (CheckList)
            SceneManager.LoadScene(sceneName);
        }
    }

    // دالة لتحديث حالة المهمة
    void UpdateTaskStatus()
    {
        // تحديث حالة المهمة داخل الـ CheckList
        if (taskPanel != null)
        {
            taskPanel.GetComponent<UnityEngine.UI.Text>().text = taskName + " ✅";
        }
    }
}

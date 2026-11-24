using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;

    private bool foodTaskDone = false;
    private bool waterTaskDone = false;
    private bool pillTaskDone = false;

    void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // يبقى عند تغيير المشاهد
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // هذه تُستدعى من السكربتات عند إكمال المهمة
    public void TaskCompleted(string taskName)
    {
        if (taskName == "food")
            foodTaskDone = true;
        else if (taskName == "water")
            waterTaskDone = true;
        else if (taskName == "pill")
            pillTaskDone = true;

        Debug.Log("TERMINER" + taskName);

        // تحقق إذا كل المهام تمت
        if (foodTaskDone && waterTaskDone && pillTaskDone)
        {
            Debug.Log("OK");
            Invoke("LoadNextScene", 8f);  // التأخير 2 ثانية قبل تحميل المشهد
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("NV"); // ✏️ بدّل هذا بالاسم الصحيح للمشهد
    }
}

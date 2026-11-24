using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    // هذه الدالة سيتم استدعاؤها عندما يتم الانتهاء من المهمة في مشهد XRayRoom
    public void EndSceneAndReturn()
    {
        // حفظ المهمة التي تم إتمامها
        PlayerPrefs.SetString("LastTask", "XrayTask");
        PlayerPrefs.Save();

        // تحميل مشهد CheckListScene
        SceneManager.LoadScene("ChecklistManager");
    }
}

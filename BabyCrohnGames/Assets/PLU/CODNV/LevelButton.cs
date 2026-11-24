using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public Button[] levelButtons;
    public string[] sceneNames;  // مصفوفة تحتوي على أسماء المشاهد الفعلية

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);

        // تفعيل أو تعطيل الأزرار بناءً على المستوى الذي تم الوصول إليه
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 <= levelReached)
            {
                levelButtons[i].interactable = true;  // تفعيل الزر
            }
            else
            {
                levelButtons[i].interactable = false;  // تعطيل الزر
            }
        }
    }

    // دالة لتحميل المشهد بناءً على الرقم
    public void LoadLevel(int level)
    {
        // تأكد من أن الرقم داخل نطاق المصفوفة
        if (level <= sceneNames.Length && level > 0)
        {
            string sceneName = sceneNames[level - 1];  // استخدام الرقم لتحميل المشهد
            SceneManager.LoadScene(sceneName);  // تحميل المشهد باستخدام اسمه
        }
        else
        {
            Debug.LogError("NV n,exist pas!");
        }
    }
}

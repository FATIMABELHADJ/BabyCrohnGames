using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string levelName;  // اسم المشهد الخاص بهذا الزر
    public int nextLevel;     // رقم المستوى التالي

    public void LoadLevel()
    {
        // تخزين المستوى الذي تم الوصول إليه
        PlayerPrefs.SetInt("LevelReached", nextLevel);
        PlayerPrefs.Save();
        
        // الانتقال للمستوى
        SceneManager.LoadScene(levelName);
    }
}

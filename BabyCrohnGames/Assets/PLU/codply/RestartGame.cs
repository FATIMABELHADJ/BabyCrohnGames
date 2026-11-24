using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // هذه الدالة ستعيد تحميل المستوى الأول وتعيد تعيين جميع المراحل
    public void Restart()
    {
        // إعادة تعيين PlayerPrefs للمستوى الأول فقط
        PlayerPrefs.SetInt("LevelReached", 1);  // إعادة تعيين المستوى الأول
        PlayerPrefs.Save();  // حفظ التغييرات

        // إعادة تحميل المشهد الأول
        SceneManager.LoadScene("NV");  // استبدل "Level1" باسم المشهد الذي ترغب في تحميله
    }
}

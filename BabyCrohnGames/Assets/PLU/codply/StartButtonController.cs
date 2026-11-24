using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    public string targetScene = "TemperatureScene";         // اسم المشهد
    public string taskIdentifier = "TemperatureMeasure";    // اسم المهمة

    // وظيفة الضغط على زر "Start"
    public void OnStartButtonPressed()
    {
        // نحفظ اسم المهمة باش نعرفها كي نرجع
        PlayerPrefs.SetString("LastTask", taskIdentifier);

        // نحمل المشهد
        SceneManager.LoadScene(targetScene);
    }
}

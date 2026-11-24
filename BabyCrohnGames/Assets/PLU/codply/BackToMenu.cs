using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public AudioSource audioSource; // نربط به صوت الزر
    public string mainMenuSceneName = "SampleScene"; // اسم المشهد الرئيسي

    public void LoadMainMenu()
    {
        if (audioSource != null)
            audioSource.Play();

        // نستنى شوية حتى يكمل الصوت، ثم نروح للمشهد
        Invoke(nameof(DelayedLoad), 0.5f);
    }

    private void DelayedLoad()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}

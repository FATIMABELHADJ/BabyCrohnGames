using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePlay : MonoBehaviour
{
    public AudioSource audioSource; // باش نتحكم في الصوت

    public void LoadAmbulanceScene()
    {
        // شغل الصوت
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // استنى شوية حتى يكمل الصوت، ومن بعد روح للمشهد
        Invoke("LoadScene", 0.5f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene("NV"); // ← بدّل الاسم حسب المشهد تاعك
    }
}

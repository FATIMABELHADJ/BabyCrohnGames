using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour
{
    public AudioSource audioSource;

    public void LoadScene(string sceneName)
    {
        if (audioSource != null)
            audioSource.Play();

        // ننتظر شوية حتى يكمل الصوت، ثم نبدل المشهد
        Invoke(nameof(DelayedLoad), 0.5f);
        nextScene = sceneName;
    }

    public void QuitGame()
    {
        if (audioSource != null)
            audioSource.Play();

        Invoke(nameof(DelayedQuit), 0.5f);
    }

    private string nextScene;

    private void DelayedLoad()
    {
        SceneManager.LoadScene(nextScene);
    }

    private void DelayedQuit()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}

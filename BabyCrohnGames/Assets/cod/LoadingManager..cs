using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    public Slider progressBar;
    public TextMeshProUGUI progressText;

    void Start()
    {
        StartCoroutine(LoadNextSceneWithPause());
    }

    IEnumerator LoadNextSceneWithPause()
    {
        string nextScene = "SampleScene";  // أو المشهد اللي بغيتي
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false;

        float progress = 0f;

        // المرحلة الأولى: حتى 50%
        while (progress < 0.5f)
        {
            progress += Time.deltaTime * 0.3f; // يتحرك شويّة بشويّة
            progressBar.value = progress;
            progressText.text = "Chargement... " + Mathf.RoundToInt(progress * 100f) + " %";
            yield return null;
        }

        // وقفة صغيرة
        yield return new WaitForSeconds(2f);

        // المرحلة الثانية: التحميل الحقيقي من Unity (0.9)
        while (operation.progress < 0.9f)
        {
            float target = 0.5f + (operation.progress / 0.9f) * 0.5f;
            progressBar.value = target;
            progressText.text = "Chargement... " + Mathf.RoundToInt(target * 100f) + " %";
            yield return null;
        }

        // وصلنا لـ 100%
        progressBar.value = 1f;
        progressText.text = "Chargement... 100%";

        yield return new WaitForSeconds(1f); // باش المستخدم يشوف 100%
        operation.allowSceneActivation = true;
    }
}

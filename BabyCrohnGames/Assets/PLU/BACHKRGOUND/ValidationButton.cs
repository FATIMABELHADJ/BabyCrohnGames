using UnityEngine;
using UnityEngine.SceneManagement;

public class ValidationButton : MonoBehaviour
{ public void LoadNewScene()
    {
        // استبدل "NV" باسم المشهد الذي تريد تحميله
        SceneManager.LoadScene("NV");
    }
}

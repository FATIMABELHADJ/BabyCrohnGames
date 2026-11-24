using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitApp()
    {
        Debug.Log("Quit Game"); // باش تشوفه في الـ Editor
        Application.Quit();     // يخرج من اللعبة (يخدم فقط في النسخة المبنية)
    }
}

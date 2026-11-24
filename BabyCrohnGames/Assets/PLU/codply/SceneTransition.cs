using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // لتحكم في UI

public class SceneTransition : MonoBehaviour
{
    public Button yourButton; // الزر الذي تريد ربطه

    void Start()
    {
        if (yourButton != null)
        {
            // ربط حدث الضغط على الزر
            yourButton.onClick.AddListener(LoadScene); 
        }
    }

    // دالة لتحميل المشهد
    void LoadScene()
    {
        // تحميل المشهد باسم "اسم_المشهد_الذي_تريد_الانتقال_إليه"
        SceneManager.LoadScene("checklistManager");
}}

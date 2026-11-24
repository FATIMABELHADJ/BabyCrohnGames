using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject tiredPanel; // لو كانت واجهتك عبارة عن Panel
    public Button yourButton; // الزر الخاص بك
    public Text yourText; // النص الذي يظهر

    void Start()
    {
        // إخفاء الـUI عند بداية اللعبة
        tiredPanel.SetActive(false);

        // إضافة التفاعل على الزر
        yourButton.onClick.AddListener(ShowTiredUI);
    }

    void ShowTiredUI()
    {
        // عند الضغط على الزر يظهر النص
        tiredPanel.SetActive(true);
        yourText.text = "أنت متعب! يجب أن ترتاح أو تذهب للمستشفى";
    }
}

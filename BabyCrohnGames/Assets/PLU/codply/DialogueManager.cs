using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject bubbleLeft;
    public GameObject bubbleRight;
    public TextMeshProUGUI textLeft;
    public TextMeshProUGUI textRight;

    [TextArea(2, 5)]
    public string[] dialogueLines; // السطور
    private int currentLine = 0;

    public float delayBeforeNextScene = 3f; // مدة الانتظار قبل تغيير المشهد
    public string nextSceneName = "NV"; // اسم المشهد التالي

    void Start()
    {
        bubbleLeft.SetActive(false);
        bubbleRight.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ShowNextLine();
        }
    }

    void ShowNextLine()
    {
        if (currentLine >= dialogueLines.Length)
        {
            bubbleLeft.SetActive(false);
            bubbleRight.SetActive(false);

            // ✅ انتظار قبل الانتقال للمشهد
            Invoke("GoToNextScene", delayBeforeNextScene);
            return;
        }

        if (currentLine % 2 == 0)
        {
            textLeft.text = dialogueLines[currentLine];
            bubbleLeft.SetActive(true);
            bubbleRight.SetActive(false);
        }
        else
        {
            textRight.text = dialogueLines[currentLine];
            bubbleRight.SetActive(true);
            bubbleLeft.SetActive(false);
        }

        currentLine++;
    }

    void GoToNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}

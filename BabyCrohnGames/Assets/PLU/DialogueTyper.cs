using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueTyper : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI speakerNameText;    // اسم المتحدث
    public TextMeshProUGUI dialogueText;       // نص الحوار
    public Button nextButton;                  // زر التالي
    public Button startButton;                 // زر بدء المشهد

    [Header("Dialogue")]
    [TextArea(3, 10)]
    public string[] dialogueLines;             // كل الجمل، كل وحدة تبدأ بـ: الاسم:الجملة

    public float typingSpeed = 0.05f;

    private int index = 0;

    void Start()
    {
        dialogueText.text = "";
        speakerNameText.text = "";
        nextButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        nextButton.onClick.AddListener(NextLine);
        startButton.onClick.AddListener(StartScene);

        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        nextButton.gameObject.SetActive(false);
        dialogueText.text = "";

        // استخراج الاسم والجملة
        string line = dialogueLines[index];
        string[] parts = line.Split(':');
        string speaker = parts.Length > 1 ? parts[0].Trim() : "";
        string text = parts.Length > 1 ? parts[1].Trim() : line;

        speakerNameText.text = speaker;

        foreach (char c in text.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        if (index < dialogueLines.Length - 1)
            nextButton.gameObject.SetActive(true);
        else
            startButton.gameObject.SetActive(true);
    }

    public void NextLine()
    {
        if (index < dialogueLines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
    }

    void StartScene()
    {
        SceneLoader.Instance.StartNextScene();
    }
}

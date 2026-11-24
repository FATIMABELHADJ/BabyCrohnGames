using UnityEngine;
using UnityEngine.UI;

public class GameStepManager : MonoBehaviour
{
    public Toggle toggleTemp;
    public Button buttonStartTemp;

    void Start()
    {
        // نخليو الـToggle Disabled فالأول
        toggleTemp.interactable = false;

        // لما اللاعب يضغط Start
        buttonStartTemp.onClick.AddListener(OnTempGameStart);
    }

    void OnTempGameStart()
    {
        // هنا دير اللعبة ديالك أو العملية لي بغيتي

        // بعد ما يسالي اللعب، نفعّل الـToggle
        toggleTemp.interactable = true;
        toggleTemp.isOn = true; // اختياري، إلا بغيتيه يتعلم أوتوماتيكيا
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChecklistManager : MonoBehaviour
{
    public Button temperatureButton;
    public GameObject checkmarkTemp;

    public Button bloodPressureButton;
    public GameObject checkmarkBP;

    public Button xrayButton;
    public GameObject checkmarkXray;

    void Awake()
    {
        // إخفاء كل العلامات في البداية
        if (checkmarkTemp != null)
            checkmarkTemp.SetActive(false);

        if (checkmarkBP != null)
            checkmarkBP.SetActive(false);

        if (checkmarkXray != null)
            checkmarkXray.SetActive(false);
    }

    void Start()
    {
        // ربط الأزرار بالمشاهد
        if (temperatureButton != null)
            temperatureButton.onClick.AddListener(() => LoadTemperatureScene());

        if (bloodPressureButton != null)
            bloodPressureButton.onClick.AddListener(() => LoadBloodPressureScene());

        if (xrayButton != null)
            xrayButton.onClick.AddListener(() => LoadXrayScene());
    }

    void OnEnable()
    {
        // استرجاع آخر مهمة مكتملة
        string lastTask = PlayerPrefs.GetString("LastTask", "");

        if (!string.IsNullOrEmpty(lastTask))
        {
            CompleteTask(lastTask);
            PlayerPrefs.DeleteKey("LastTask");
        }
    }

    public void LoadTemperatureScene()
    {
        PlayerPrefs.SetString("LastTask", "TemperatureMeasure");
        SceneManager.LoadScene("TemperatureScene");
    }

    public void LoadBloodPressureScene()
    {
        PlayerPrefs.SetString("LastTask", "BloodPressureMeasure");
        SceneManager.LoadScene("BloodPressureScene");
    }

    public void LoadXrayScene()
    {
        PlayerPrefs.SetString("LastTask", "");
        SceneManager.LoadScene("GUTScanScene");
    }

    public void CompleteTask(string taskName)
    {
        taskName = taskName.Trim();

        if (taskName == "TemperatureMeasure")
        {
            if (checkmarkTemp != null)
                checkmarkTemp.SetActive(true);

            if (temperatureButton != null)
                temperatureButton.interactable = false;
        }

        else if (taskName == "BloodPressureMeasure")
        {
            if (checkmarkBP != null)
                checkmarkBP.SetActive(true);

            if (bloodPressureButton != null)
                bloodPressureButton.interactable = false;
        }

        else if (taskName == "XrayTask")
        {
            if (checkmarkXray != null)
                checkmarkXray.SetActive(true);

            if (xrayButton != null)
                xrayButton.interactable = false;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TemperatureMesure : MonoBehaviour
{
    public GameObject thermometer;
    public GameObject uiPanel;
    public Text temperatureText;
    public SpriteRenderer babyFaceRenderer;
    public Sprite closedMouthSprite;
    public Sprite openMouthSprite;

    public float measurementDuration = 2f;
    public float panelDisplayDuration = 3f;

    private bool isMeasuring = false;
    private Vector3 originalPosition;
    private Vector3 measurementPosition;

    // مرجع لسكربت ChecklistManager
    public ChecklistManager checklistManager;

    void Start()
    {
        if (uiPanel != null)
            uiPanel.SetActive(false);

        if (thermometer != null)
            originalPosition = thermometer.transform.position;

        if (babyFaceRenderer != null && closedMouthSprite != null)
            babyFaceRenderer.sprite = closedMouthSprite;

        if (checklistManager == null)
        {
            checklistManager = FindObjectOfType<ChecklistManager>();

            if (checklistManager == null)
            {
                Debug.LogError("❌ ChecklistManager not found in scene!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null || other.gameObject != thermometer || isMeasuring)
            return;

        if (babyFaceRenderer != null && openMouthSprite != null)
            babyFaceRenderer.sprite = openMouthSprite;

        measurementPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        thermometer.transform.position = measurementPosition;

        StartCoroutine(MeasureTemperature());
    }

    IEnumerator MeasureTemperature()
    {
        isMeasuring = true;

        if (uiPanel != null)
            uiPanel.SetActive(true);

        yield return new WaitForSeconds(measurementDuration);

        float temperature = Random.Range(36.0f, 40.0f);

        if (temperatureText != null)
            temperatureText.text = $"Température : {temperature:F1} °C";

        yield return new WaitForSeconds(panelDisplayDuration);

        if (uiPanel != null)
            uiPanel.SetActive(false);

        if (babyFaceRenderer != null && closedMouthSprite != null)
            babyFaceRenderer.sprite = closedMouthSprite;

        StartCoroutine(ReturnThermometerToOriginalPosition());

        // ✅ تسجيل إتمام المهمة
        PlayerPrefs.SetString("LastTask", "TemperatureMeasure");
        PlayerPrefs.SetInt("TemperateurScene", 1); // تسجيل المهمة كمنجزة
        PlayerPrefs.Save();

        // ✅ الرجوع لمشهد الـ Checklist
        SceneManager.LoadScene("ChecklistManager");

        isMeasuring = false;
    }

    IEnumerator ReturnThermometerToOriginalPosition()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = thermometer.transform.position;

        while (elapsedTime < 1f)
        {
            thermometer.transform.position = Vector3.Lerp(startPosition, originalPosition, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        thermometer.transform.position = originalPosition;
    }
}

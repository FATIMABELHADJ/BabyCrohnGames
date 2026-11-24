using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MeasureManager : MonoBehaviour
{
    public GameObject baby;
    public GameObject uiPanel;
    public Text measureText;

    public float measurementDuration = 2f;
    public float panelDisplayDuration = 3f;

    private bool isMeasuring = false;

    void Start()
    {
        if (uiPanel != null)
            uiPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WeightScale") && !isMeasuring)
        {
            StartCoroutine(MeasureWeight());
        }
    }

    IEnumerator MeasureWeight()
    {
        isMeasuring = true;

        if (uiPanel != null)
            uiPanel.SetActive(true);

        yield return new WaitForSeconds(measurementDuration);

        float weight = Random.Range(10f, 20f); // وزن عشوائي

        if (measureText != null)
            measureText.text = $"Poids : {weight:F1} kg";

        yield return new WaitForSeconds(panelDisplayDuration);

        if (uiPanel != null)
            uiPanel.SetActive(false);

        isMeasuring = false;
    }
}

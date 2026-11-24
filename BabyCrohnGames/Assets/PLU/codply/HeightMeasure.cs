using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeightMeasure : MonoBehaviour
{
    public GameObject baby;
    public GameObject panelResult;
    public Text heightText;
    public float duration = 2f;

    private bool isMeasuring = false;

    void Start()
    {
        panelResult.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == baby && !isMeasuring)
        {
            StartCoroutine(MeasureHeight());
        }
    }

    IEnumerator MeasureHeight()
    {
        isMeasuring = true;

        panelResult.SetActive(true);
        yield return new WaitForSeconds(duration);

        float height = Random.Range(80f, 110f);
        heightText.text = "الطول: " + height.ToString("F1") + " سم";

        isMeasuring = false;
    }
}

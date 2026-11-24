using UnityEngine;

public class POIInfo : MonoBehaviour
{
    public GameObject effectPrefab; // التأثير الذي يظهر عند التفاعل
    public GameObject infoPanel;    // لوحة المعلومات أو الرسالة
    public string infoText;         // النص الذي سيظهر في المعلومات

    private void OnTriggerEnter2D(Collider2D other)
    {
        // تحقق إذا كان اللاعب قد وصل إلى النقطة
        if (other.CompareTag("Player"))
        {
            // إذا كان هناك تأثير، يظهر عند التفاعل
            if (effectPrefab != null)
            {
                Instantiate(effectPrefab, transform.position, Quaternion.identity);
            }

            // عرض لوحة المعلومات
            if (infoPanel != null)
            {
                infoPanel.SetActive(true);
                infoPanel.GetComponent<UnityEngine.UI.Text>().text = infoText; // إذا كانت النصوص في UI Text
            }
        }
    }
}

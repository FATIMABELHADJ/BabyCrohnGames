using UnityEngine;
using UnityEngine.SceneManagement;

public class RadiologyZoneEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RadiologyMachine"))
        {
            Debug.Log("الدخول لمشهد الأشعة");
            SceneManager.LoadScene("GutScanScene"); // اسم المشهد التالي
        }
    }
}

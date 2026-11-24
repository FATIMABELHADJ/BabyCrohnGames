using UnityEngine;
using UnityEngine.SceneManagement;

public class StartRadiologyRide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Tag تاع الطفل
        {
            SceneManager.LoadScene("XRayRoom2D"); // ← بدلها باسم المشهد الثاني تاعك
        }
    }
}

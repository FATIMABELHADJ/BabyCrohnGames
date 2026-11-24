using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PathTarget"))
        {
            SceneManager.LoadScene("GutScanScene");
        }
    }
}

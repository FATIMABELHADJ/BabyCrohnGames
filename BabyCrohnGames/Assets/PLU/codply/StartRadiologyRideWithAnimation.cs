using UnityEngine;
using UnityEngine.SceneManagement;

public class StartRadiologyRideWithAnimation : MonoBehaviour
{
    public Transform baby; // الطفل
    public Transform enterPoint; // النقطة اللي يدخللها داخل الجهاز
    public float enterSpeed = 2f;
    public float waitBeforeLoad = 2f;

    private bool startEntering = false;
    private bool hasEntered = false;
    private float timer = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !startEntering)
        {
            startEntering = true;

            // تعطيل تحكم اللاعب في الحركة
            if (baby.GetComponent<BabyMovement>() != null)
            {
                baby.GetComponent<BabyMovement>().enabled = false;
            }
        }
    }

    void Update()
    {
        if (startEntering && !hasEntered)
        {
            baby.position = Vector2.MoveTowards(baby.position, enterPoint.position, enterSpeed * Time.deltaTime);

            if (Vector2.Distance(baby.position, enterPoint.position) < 0.05f)
            {
                hasEntered = true;
            }
        }

        if (hasEntered)
        {
            timer += Time.deltaTime;

            if (timer >= waitBeforeLoad)
            {
                SceneManager.LoadScene(" GutScanScene");
            }
        }
    }
}

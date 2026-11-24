using UnityEngine;
using System.Collections;

public class BabyBallInteraction : MonoBehaviour
{
    public float kickForce = 50f;
    public GameObject pg0; // GameObject ديال البنت
    private bool isKicking = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball") && !isKicking)
        {
            isKicking = true;

            // شغل الأنيميشن ديال البنت
            pg0.GetComponent<Animator>().SetTrigger("Kick");

            // استنى 0.7 ثانية ثم أضرب الكرة
            StartCoroutine(KickBallAfterDelay(other.GetComponent<Rigidbody2D>()));
        }
    }

    IEnumerator KickBallAfterDelay(Rigidbody2D ballRb)
    {
        yield return new WaitForSeconds(0.7f); // استنى مدة الأنيميشن

        if (ballRb != null)
        {
            // نحسب الاتجاه انطلاقًا من موقع البنت، ماشي من transform ديال هاد الكائن
            Vector2 dir = (ballRb.transform.position - pg0.transform.position).normalized;
            ballRb.AddForce(dir * kickForce, ForceMode2D.Impulse);
        }

        yield return new WaitForSeconds(1f);
        isKicking = false;
    }
}

using UnityEngine;

public class NurseTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // تأكد من أن "Player" هو العلامة الخاصة بالطفل
        {
            Debug.Log("الطفل دخل منطقة التفاعل مع الممرضة");
            // إضافة الأكشن المطلوب عند التفاعل مع الممرضة هنا
        }
    }
}

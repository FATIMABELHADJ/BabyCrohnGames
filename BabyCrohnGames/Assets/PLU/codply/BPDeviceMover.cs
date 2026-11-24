using UnityEngine;

public class BPDeviceMover : MonoBehaviour
{
    public Transform deviceTransform; // جهاز قياس الضغط
    public Transform targetHand;      // يد الطفل
    public Vector3 offsetFromHand;    // الإزاحة اللي تحب الجهاز يكون فيها بالنسبة لليد
    public float moveSpeed = 2f;      // سرعة الحركة

    private bool shouldMove = false;

    void Update()
    {
        if (shouldMove)
        {
            // تحريك الجهاز تدريجيا نحو اليد
            Vector3 targetPosition = targetHand.position + offsetFromHand;
            deviceTransform.position = Vector3.MoveTowards(deviceTransform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // أو استبدل بـ Tag تاع الطفل
        {
            shouldMove = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldMove = false;
        }
    }
}

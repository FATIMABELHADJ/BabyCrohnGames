using UnityEngine;

public class JumpFatigueManager : MonoBehaviour
{
    public float maxFatigue = 100f;  // الحد الأقصى للتعب
    public float currentFatigue = 0f;  // مستوى التعب الحالي

    public float fatigueIncreaseRate = 10f;  // سرعة زيادة التعب

    // دالة لزيادة التعب
    public void AddFatigue()
    {
        currentFatigue += fatigueIncreaseRate;
        if (currentFatigue > maxFatigue)
        {
            currentFatigue = maxFatigue;  // تأكد من أن التعب لا يتجاوز الحد الأقصى
        }
    }

    // دالة للتحقق إذا كان اللاعب متعبًا
    public bool IsTired()
    {
        return currentFatigue >= maxFatigue;  // إذا وصل التعب إلى الحد الأقصى، اللاعب متعب
    }

    // دالة لتقليل التعب (اختياري)
    public void ReduceFatigue(float amount)
    {
        currentFatigue -= amount;
        if (currentFatigue < 0)
        {
            currentFatigue = 0;  // تأكد من أن التعب لا يقل عن صفر
        }
    }
}

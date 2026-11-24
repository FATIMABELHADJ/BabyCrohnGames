using UnityEngine;

public class SickUIManager : MonoBehaviour
{
    public PlayerMovement playerMovement; // مرجع لسكربت PlayerMovement

    void Start()
    {
        // الوصول إلى facingRight عبر سكربت PlayerMovement
        bool isFacingRight = playerMovement.facingRight;

        // استخدمه هنا حسب الحاجة
        Debug.Log("الطفل يواجه اليمين: " + isFacingRight);
    }

    public void ShowSickMessage(string message)
    {
        // عرض رسالة المرض على واجهة المستخدم
        Debug.Log(message);
    }
}

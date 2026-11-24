using UnityEngine;
using UnityEngine.UI;

public class CookingStarter : MonoBehaviour
{
    public Transform tajineZone;
    public int requiredItems = 3;
    public GameObject resultImage;

    void Update()
    {
        if (tajineZone.childCount >= requiredItems)
        {
            Debug.Log("كلشي واجد! نبدأ الطبخ.");
            resultImage.SetActive(true);
            this.enabled = false; // نوقف الفحص
        }
    }
}

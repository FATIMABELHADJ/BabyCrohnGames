using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBabyToDevice : MonoBehaviour
{ public Transform baby;  // الطفل
    public Transform device; // الجهاز
    public float moveSpeed = 2f; // سرعة الحركة

    private bool isMoving = false; // حالة الحركة

    void Start()
    {
        // تبدأ الحركة تلقائيًا عند الضغط على "Play"
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            // تحرك الطفل نحو الجهاز
            baby.position = Vector2.MoveTowards(baby.position, device.position, moveSpeed * Time.deltaTime);

            // إذا وصل الطفل إلى الجهاز، أوقف الحركة وابدأ تحميل المشهد الثاني
            if (Vector2.Distance(baby.position, device.position) < 2f)
            {
                isMoving = false;
                LoadNextScene(); // تحميل المشهد الثاني مباشرة بعد الوصول للجهاز
            }
        }
    }

    void LoadNextScene()
    {
        // هنا ننتقل إلى المشهد الثاني بعد وصول الطفل
        SceneManager.LoadScene("XRayRoom2D"); // تأكد أن اسم المشهد هنا هو الصحيح
    }
}
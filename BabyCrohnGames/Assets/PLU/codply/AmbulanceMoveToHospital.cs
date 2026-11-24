using UnityEngine;
using UnityEngine.SceneManagement;

public class AmbulanceMoveToHospital : MonoBehaviour
{
    public Transform stopPoint;
    public float speed = 2f;
    private bool moving = true;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            // تأكد من أن الصوت لا يبدأ مباشرة
            audioSource.Stop();
        }
    }

    void Update()
    {
        if (moving)
        {
            if (audioSource != null && !audioSource.isPlaying) 
            {
                audioSource.Play(); // يبدأ الصوت فقط إذا لم يكن يعمل بعد
            }

            transform.position = Vector3.MoveTowards(
                transform.position,
                stopPoint.position,
                speed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, stopPoint.position) < 0.05f)
            {
                moving = false;

                if (audioSource != null)
                {
                    audioSource.Stop(); // يوقف الصوت بعد التوقف
                }

                Invoke("LoadNextScene", 1.5f);
            }
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("LEV3.1PLAY"); // اسم المشهد التالي
    }
}

using UnityEngine;
using UnityEngine.SceneManagement; // ضروري باش نبدل المشاهد
using System.Collections;

public class JumpRope : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public float jumpHeight = 2f;
    public float jumpSpeed = 4f;
    public LineRenderer rope;
    private bool isJumping = false;
    public GameObject tiredPanel;


    public JumpFatigueManager fatigueManager;
    public Sprite tiredFace;  // وجه التعب
    public Sprite normalFace;  // وجه طبيعي
    private SpriteRenderer player3Renderer;
    public AudioClip jumpSound;
    private AudioSource audioSource;
 
    private bool hasChangedFace = false;

    void Start()
    {
        if (rope == null)
            rope = GetComponent<LineRenderer>();

        rope.startWidth = 0.1f;
        rope.endWidth = 0.1f;
        rope.positionCount = 3;

        player3Renderer = player3.GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        tiredPanel.SetActive(false); // نخبي البانيل التعب
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !fatigueManager.IsTired())
        {
            StartCoroutine(Jump());
        }
    }

    private IEnumerator Jump()
    {
        isJumping = true;

        if (jumpSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }

        Vector3 startPos3 = player3.transform.position;
        float timeElapsed = 0f;

        // الطلوع
        while (timeElapsed < jumpSpeed / 2)
        {
            player3.transform.position = Vector3.Lerp(startPos3, startPos3 + Vector3.up * jumpHeight, timeElapsed / (jumpSpeed / 2));
            UpdateRope();
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        timeElapsed = 0f;

        // النزول
        while (timeElapsed < jumpSpeed / 2)
        {
            player3.transform.position = Vector3.Lerp(startPos3 + Vector3.up * jumpHeight, startPos3, timeElapsed / (jumpSpeed / 2));
            UpdateRope();
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        fatigueManager.AddFatigue();

        // عندما يتعب الطفل ويصل إلى مرحلة التعب
        if (fatigueManager.IsTired() && !hasChangedFace)
        {
            player3Renderer.sprite = tiredFace;  // تغيير الوجه إلى تعب
            hasChangedFace = true;
            tiredPanel.SetActive(true);  // إظهار بانيل التعب

            // الانتقال إلى مشهد جديد بعد فترة قصيرة
            yield return new WaitForSeconds(2f);  // الانتظار قليلاً قبل الانتقال
            GoToNextScene();  // استدعاء الدالة التي تغير المشهد
        }

        isJumping = false;
    }

    private void UpdateRope()
    {
        rope.SetPosition(0, player1.transform.position);
        rope.SetPosition(1, player3.transform.position);
        rope.SetPosition(2, player2.transform.position);
    }

    // دالة للانتقال إلى المشهد الجديد
    public void GoToNextScene()
    {
        SceneManager.LoadScene("NV");  // اسم المشهد الذي ترغب في الانتقال إليه
    }
}

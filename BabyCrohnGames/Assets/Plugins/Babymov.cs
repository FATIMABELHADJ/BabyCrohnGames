using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Babymov : MonoBehaviour
{
     public float moveSpeed = 2f;        // سرعة الحركة
    public Animator animator;           // رابط مع Animator
    public bool isSick = false;          // حالة المرض

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // إذا ما ربطتش Animator من Inspector، يحاول يجيبو أوتوماتيكياً
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isSick)
        {
            // تحرك الطفل على محور X (يمين)
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

            // شغل أنيميشن الجري
            if (animator != null)
            {
                animator.SetBool("isRunning", true);
            }
        }
        else
        {
            // أوقف الطفل إذا كان مريض
            rb.velocity = new Vector2(0, rb.velocity.y);

            // أوقف أنيميشن الجري
            if (animator != null)
            {
                animator.SetBool("isRunning", false);
            }
        }
    }

    // دالة تقد تنديرها من سكربت آخر مثلا لما يمرض
    public void SetSickState(bool sick)
    {
        isSick = sick;
    }
}

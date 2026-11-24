using UnityEngine;

public class BabyMovement : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        float move = Input.GetAxis("Horizontal"); // ← → أو A D
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);
    }
}

using UnityEngine;

public class PathMover : MonoBehaviour
{
    [Header("Points to follow")]
    public Transform[] points;

    [Header("Speed of movement")]
    public float speed = 2f;

    private int index = 0;

    void Update()
    {
        if (points.Length == 0 || index >= points.Length) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            points[index].position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, points[index].position) < 0.05f)
        {
            index++;
        }
    }
}

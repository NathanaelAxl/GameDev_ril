using UnityEngine;

public class MovingPlatformMultiple : MonoBehaviour
{
    [Tooltip("Masukkan titik-titik tujuan (minimal 2)")]
    public Transform[] waypoints;
    public float speed = 2f;
    private int currentIndex = 0;

    void Update()
    {
        if (waypoints.Length == 0) return;
        Vector3 target = waypoints[currentIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            currentIndex++;
            if (currentIndex >= waypoints.Length)
                currentIndex = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}

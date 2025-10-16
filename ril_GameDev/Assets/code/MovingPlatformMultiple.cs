using UnityEngine;

public class MovingPlatformMultiple : MonoBehaviour
{
    [Tooltip("Masukkan titik-titik tujuan (minimal 2)")]
    public Transform[] waypoints; // Array titik tujuan
    public float speed = 2f;      // Kecepatan konstan

    private int currentIndex = 0; // Titik yang sedang dituju

    void Update()
    {
        if (waypoints.Length == 0) return;

        // Posisi target waypoint
        Vector3 target = waypoints[currentIndex].position;

        // Gerakkan platform menuju target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Jika sudah hampir sampai, pindah ke waypoint berikutnya
        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            currentIndex++;
            if (currentIndex >= waypoints.Length)
                currentIndex = 0; // Kembali ke titik pertama
        }
    }

    // Biar player ikut bergerak di atas platform
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

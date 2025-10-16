using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;  // Titik awal
    public Transform pointB;  // Titik tujuan
    public float speed = 2f;  // Kecepatan konstan

    private Vector3 target;   // Titik target yang sedang dituju

    void Start()
    {
        target = pointB.position; // Mulai bergerak ke pointB
    }

    void Update()
    {
        // Gerakkan platform menuju target dengan kecepatan konstan
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Jika sudah sampai target, ubah arah
        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }
    }

    // Supaya player ikut bergerak saat berada di atas platform
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

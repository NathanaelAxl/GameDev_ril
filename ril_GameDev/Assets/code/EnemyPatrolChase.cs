using UnityEngine;

public class EnemyPatrolChase : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform[] patrolPoints;
    public float patrolSpeed = 2f;

    [Header("Chase Settings")]
    public Transform hero;
    public float chaseSpeed = 3.5f;
    public float chaseRange = 5f;
    public float stopDistance = 1.5f;

    private int currentPoint = 0;
    private bool chasing = false;

    // Komponen tambahan
    private Animator anim;
    private SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        if (patrolPoints.Length > 0)
            transform.position = patrolPoints[0].position; // mulai dari titik pertama
    }

    void Update()
    {
        if (patrolPoints.Length == 0 || hero == null) return;

        float distanceToHero = Vector2.Distance(transform.position, hero.position);

        // Tentukan mode: kejar atau patroli
        if (distanceToHero <= chaseRange && distanceToHero > stopDistance)
        {
            chasing = true;
        }
        else if (distanceToHero <= stopDistance)
        {
            chasing = false; // berhenti di dekat hero
        }
        else if (distanceToHero > chaseRange)
        {
            chasing = false; // kembali patroli
        }

        // Aksi
        if (chasing)
            ChaseHero();
        else
            Patrol();
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform target = patrolPoints[currentPoint];
        transform.position = Vector2.MoveTowards(transform.position, target.position, patrolSpeed * Time.deltaTime);

        // Flip arah sesuai target
        Flip(target.position.x - transform.position.x);

        // Aktifkan animasi jalan
        anim.SetBool("isWalking", true);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            currentPoint++;
            if (currentPoint >= patrolPoints.Length)
                currentPoint = 0;
        }
    }

    void ChaseHero()
    {
        transform.position = Vector2.MoveTowards(transform.position, hero.position, chaseSpeed * Time.deltaTime);
        Flip(hero.position.x - transform.position.x);
        anim.SetBool("isWalking", true);
    }

    void Flip(float direction)
    {
        if (direction > 0)
            sr.flipX = false; // kanan
        else if (direction < 0)
            sr.flipX = true;  // kiri
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}

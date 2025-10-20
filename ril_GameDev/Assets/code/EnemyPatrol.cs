using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 2f;
    public float waitTime = 1f;

    private int currentPointIndex = 0;
    private bool isWaiting = false;
    private float waitCounter;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        waitCounter = waitTime;
    }

    void Update()
    {
        if (patrolPoints.Length < 2) return;

        if (isWaiting)
        {
            waitCounter -= Time.deltaTime;
            animator.SetBool("isWalking", false);

            if (waitCounter <= 0f)
            {
                isWaiting = false;
                GoToNextPoint();
            }
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        Transform targetPoint = patrolPoints[currentPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = targetPoint.position.x < transform.position.x;
        }

        animator.SetBool("isWalking", true);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.05f)
        {
            isWaiting = true;
            waitCounter = waitTime;
            Debug.Log("Reached point: " + currentPointIndex);
        }
    }

    void GoToNextPoint()
    {
        currentPointIndex++;
        if (currentPointIndex >= patrolPoints.Length)
        {
            currentPointIndex = 0;
        }

        Debug.Log("Moving to point: " + currentPointIndex);
    }
}

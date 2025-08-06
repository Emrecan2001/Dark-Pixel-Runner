using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public LayerMask obstacleLayer;

    private Vector2 moveDirection;
    private bool isMoving = false;

    private void Update()
    {
        if (!isMoving)
        {
            // Input al
            if (Input.GetKeyDown(KeyCode.W)) TryMove(Vector2.up);
            else if (Input.GetKeyDown(KeyCode.S)) TryMove(Vector2.down);
            else if (Input.GetKeyDown(KeyCode.A)) TryMove(Vector2.left);
            else if (Input.GetKeyDown(KeyCode.D)) TryMove(Vector2.right);
        }
    }

    void TryMove(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, obstacleLayer);

        if (hit.collider != null)
        {
            Vector2 targetPosition = hit.point - direction * 0.5f; // Biraz boþluk býrak
            StartCoroutine(MoveToPosition(targetPosition));
        }
    }

    System.Collections.IEnumerator MoveToPosition(Vector2 target)
    {
        isMoving = true;

        while ((Vector2)transform.position != target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }
}

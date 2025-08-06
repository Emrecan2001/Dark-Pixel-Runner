using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float slideSpeed = 5f;

    Vector2 direction;
    bool hitWall = false;

    void Start()
    {

    }

    void Update()
    {
        MoveToDirection();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Çarpýþma");
    }

    void MoveToDirection()
    {
        float movementX;
        float movementY;

        if (!hitWall)
        {
            movementX = Input.GetAxis("Horizontal");
            movementY = Input.GetAxis("Vertical");
            direction = new Vector2(movementX, movementY) * Time.deltaTime;
        }

        transform.Translate(direction * slideSpeed);
    }
}

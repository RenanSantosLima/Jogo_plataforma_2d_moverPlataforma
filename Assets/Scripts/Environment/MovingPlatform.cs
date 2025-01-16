using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Parametros")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    //velocidade da plataforma
    private float moveSpeed = 2;
    private bool moveRight = true;

    private void Update()
    {
        if (transform.position.x < pointA.position.x) {
            moveRight = true;
        } else if (transform.position.x > pointB.position.x) {
            moveRight = false;
        }

        if (moveRight) {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        } else {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            print("Entrou na plataforma!");
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            print("Saiu da plataforma!");
            collision.gameObject.transform.parent = null;
        }
    }
}

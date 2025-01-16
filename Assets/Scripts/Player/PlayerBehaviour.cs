using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private IsGroundedChecker isGroundedChecker;

    //velocidade movimento e força do jump
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float jumpForce = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isGroundedChecker = GetComponent<IsGroundedChecker>();
    }

    private void Start()
    {
        GameManager.Instance.inputManager.OnJump += HandleJump;
    }
    

    private void Update()
    {
        //recebe o valor de InputMananger
        float moveDirection = GameManager.Instance.inputManager.Movement;
        //movimento
        Vector2 directionToMove = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        rb.velocity = directionToMove; 
    }

    //jump
    private void HandleJump()
    {
        if (isGroundedChecker.IsGrounded() == false) return;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}

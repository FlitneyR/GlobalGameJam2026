using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    InputAction moveAction;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");

        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        bool sideMovement = Mathf.Abs(moveInput.x) >= Mathf.Abs(moveInput.y);
        animator.SetBool("Side", sideMovement);
        animator.SetBool("Up", moveInput.y > 0.0 && !sideMovement);
        animator.SetBool("Down", moveInput.y < -0.0 && !sideMovement);

        if (moveInput.x < 0.0)
            spriteRenderer.flipX = true;

        if (moveInput.x > 0.0)
            spriteRenderer.flipX = false;

        animator.SetBool("Moving", moveInput.magnitude > 0.0);

        Vector2 moveValue = moveInput * Time.deltaTime * moveSpeed;
        rigidbody2d.MovePosition(new Vector2(transform.position.x, transform.position.y) + moveValue);
    }
}

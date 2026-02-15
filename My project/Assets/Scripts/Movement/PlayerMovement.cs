
using UnityEngine;
using UnityEngine.InputSystem;   // <-- New Input System

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;      // top-down
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // WASD + Arrow keys (New Input System)
        Vector2 input = Vector2.zero;

        var k = Keyboard.current;
        if (k == null) return;

        if (k.aKey.isPressed || k.leftArrowKey.isPressed) input.x -= 1f;
        if (k.dKey.isPressed || k.rightArrowKey.isPressed) input.x += 1f;
        if (k.sKey.isPressed || k.downArrowKey.isPressed) input.y -= 1f;
        if (k.wKey.isPressed || k.upArrowKey.isPressed) input.y += 1f;

        moveInput = input.normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }
}

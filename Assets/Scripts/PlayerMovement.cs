using UnityEngine;
using UnityEngine.InputSystem; // Necesario para detectar las acciones

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private Vector2 moveInput;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>(); 
    }

    public void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump() {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void Update() {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        if (move != Vector3.zero) {
            transform.forward = move;
        }
    }
}
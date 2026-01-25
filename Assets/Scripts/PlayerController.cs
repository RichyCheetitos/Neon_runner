using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f; 
    private Vector2 _moveInput;
    private Rigidbody _rb;

    [Header("Ground Detection")]
    public Transform groundDetector; 
    public float detectionRadius = 0.2f;
    public LayerMask groundLayer; 
    private bool _isGrounded;

    void Start() => _rb = GetComponent<Rigidbody>();

    private void OnMove(InputValue value) 
    {
        _moveInput = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (_isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(groundDetector.position, detectionRadius, groundLayer);
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(_moveInput.x, 0, _moveInput.y) * moveSpeed;
        _rb.linearVelocity = new Vector3(move.x, _rb.linearVelocity.y, move.z);
    }
}
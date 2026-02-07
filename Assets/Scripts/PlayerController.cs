using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events; // IMPORTANTE: Necesario para los eventos

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

    [Header("Activity 2 - Stats")]
    public int health = 100;
    public int score = 10000;
    public int sprintCount = 0;

    [Header("Activity 2 - Events")]
    // Estos aparecerán en el Inspector para que arrastres la UI y el Sonido
    public UnityEvent onStatsChanged; // Se activa al recibir daño o curarse
    public UnityEvent onSpacePressed; // Se activa al presionar espacio

    void Start() => _rb = GetComponent<Rigidbody>();

    // MÉTODO PARA EL BOTÓN DAMAGE
    public void TakeDamage(int amount)
    {
        health -= amount;
        score -= amount * 10;
        onStatsChanged.Invoke(); // "Avisa" a todos los que estén escuchando
    }

    // MÉTODO PARA EL BOTÓN HEALING
    public void Heal(int amount)
    {
        health += amount;
        score += amount * 10;
        onStatsChanged.Invoke(); // "Avisa" a todos los que estén escuchando
    }

    // MÉTODO PARA LA TECLA ESPACIO (Se llama desde OnJump)
    private void OnJump()
    {
        if (_isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
        // Lógica de la actividad
        moveSpeed += 1f;
        sprintCount++;
        onSpacePressed.Invoke(); // "Avisa" que presionaste espacio
    }

    private void OnMove(InputValue value) => _moveInput = value.Get<Vector2>();

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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float gravity = -9.81f; // Standard gravity constant in meters/s^2
    [SerializeField] private float jumpHeight;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    private Vector3 velocity;
    
    private bool isGrounded;

    // Reference to the main camera
    private Camera mainCamera;

    [SerializeField] private Transform playerMesh;
    [SerializeField] private Animator anim;
    
    private Vector3 previousPosition;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main;
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() 
    {
        Vector3 realVelocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;
        anim.SetFloat("Velocity", realVelocity.magnitude);
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Get camera's forward and right vectors
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        // Flatten the forward vector on the y-axis
        cameraForward.y = 0;
        cameraForward.Normalize();
        cameraRight.y = 0;
        cameraRight.Normalize();

        // Calculate movement direction relative to the camera
        Vector3 move = (cameraRight * x) + (cameraForward * z);

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (move.magnitude > 0)
        {
            // Calculate the target rotation based on the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(move);
            playerMesh.rotation = Quaternion.Slerp(playerMesh.rotation, targetRotation, Time.deltaTime * 10f); // Adjust speed as needed
        }

        // Gravity Implementation
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); 
    }
}

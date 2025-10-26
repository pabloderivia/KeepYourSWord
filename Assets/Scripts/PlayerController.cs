using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 moveInput;
    Vector3 moveDirection;
    CharacterController characterController;
    [SerializeField] private float rotationSpeed=150f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();  
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void HandleMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
    }

    public void Movement()
    {
        //mueve
        characterController.Move(moveDirection * Time.deltaTime * moveSpeed);
        //rota al pj
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                targetRotation,
                Time.deltaTime * rotationSpeed
            );
        }

    }
}

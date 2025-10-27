using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 moveInput;
    Vector3 moveDirection;
    CharacterController characterController;

    [SerializeField] private float rotationSpeed = 150f;

    AnimationController animationController;
    public bool isBusy = false; 

    void Awake()
    {
        characterController = GetComponent<CharacterController>();  
        animationController = GetComponentInChildren<AnimationController>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateIsBusy();

        if(!isBusy)
            Movement();
    }

    public void HandleMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
    }

    public void HandleIsAttacking(InputAction.CallbackContext context)
    {
        Debug.Log("Trying to attack");

        if(context.phase == InputActionPhase.Started)
        {
            Debug.Log("Trying to attack");
            animationController.SetTriggerAttack();
                        
        }
    }


    public void Movement()
    {
        //mueve
        characterController.Move(moveDirection * Time.deltaTime * moveSpeed);

        LookAtAimDirection();

        //Acualiza la anim de movimiento
        animationController.SetMoveSpeed(GetMoveMagnitud());


    }

    private float GetMoveMagnitud()
    {
        float absMagnitud = Mathf.Abs(moveInput.x) + Mathf.Abs(moveInput.y);
        absMagnitud = Mathf.Clamp(absMagnitud, 0, 1);
        return absMagnitud;
    }

    private void LookAtAimDirection()
    {
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

    private void UpdateIsBusy()
    {
        if (animationController.IsAttacking)
            isBusy = true;


        else
            isBusy = false;
    }
    

}

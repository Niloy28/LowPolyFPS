using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FPS.Input;

namespace FPS.Player
{
    public class FirstPersonController : MonoBehaviour
    {
        private CharacterController characterController;
        private PlayerInputs inputs;
        private Animator animator;
        private Rigidbody rb;
        private Vector3 moveData;
        private bool isGrounded;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            inputs = new PlayerInputs();
            animator = GetComponentInChildren<Animator>();
            rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            SetupInputs();
        }

        private void Update()
        {
            characterController.Move(moveData);
        }

        private void SetupInputs()
        {
            inputs.Movement.Move.performed += ProcessMovementData;
            inputs.Movement.Move.canceled += _ => moveData = Vector2.zero;
            
            inputs.Movement.Jump.performed += Jump;
        }

        private void ProcessMovementData(InputAction.CallbackContext obj)
        {
            var rawData = obj.ReadValue<Vector2>();
            moveData = new Vector3(rawData.x, 0f, rawData.y);
        }

        private void Jump(InputAction.CallbackContext ctx)
        {
            rb.AddForce(new Vector3(0, 100f, 0));
        }

        private void OnEnable()
        {
            inputs.Enable();
        }

        private void OnDisable()
        {
            inputs.Disable();
        }
    }
}
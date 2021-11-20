using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FPS.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Range(0f, 10f)] [SerializeField] private float playerWalkSpeed = 6f;
        [Range(5f, 20f)] [SerializeField] private float playerRunSpeed = 12f;
        [Range(0f, 10f)] [SerializeField] private float jumpHeight = 6f;
        [Header("Handle Player Physics")]
        [SerializeField] private float gravity = -9.81f;

        private CharacterController characterController;
        private Animator animator;
        private Vector3 rawData;
        private Vector3 velocity;
        private bool isRunning;

        private void Awake() => CacheReferences();

        private void CacheReferences()
        {
            characterController = GetComponent<CharacterController>();
            animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            if (characterController.isGrounded)
            {
                MovePlayer();
            }
            AnimatePlayer();
        }

        private void AnimatePlayer()
        {
            animator.SetBool("Walk", characterController.velocity.magnitude > 0.01f && !isRunning);
            animator.SetBool("Run", characterController.velocity.magnitude > 0.01f && isRunning);
        }

        private void LateUpdate()
        {
            if (characterController.isGrounded)
            {
                ResetVelocity();
            }
            else
            {
                ApplyGravity();
            }
        }

        private void ResetVelocity() => velocity = Vector3.zero;

        private void MovePlayer()
        {
            var moveData = rawData.x * transform.right + rawData.y * transform.forward;
            var moveSpeed = isRunning ? playerRunSpeed : playerWalkSpeed;
            moveData.Normalize();
            characterController.Move(moveData * moveSpeed * Time.deltaTime);
        }

        private void ApplyGravity()
        {
            velocity.y += gravity * Mathf.Pow(Time.fixedDeltaTime, 1);
            characterController.Move(velocity);
        }

        internal void ReadRawMovementData(InputAction.CallbackContext ctx) => rawData = ctx.ReadValue<Vector2>();

        internal void SetPlayerToRun(InputAction.CallbackContext _) => isRunning = true;

        internal void SetPlayerToWalk(InputAction.CallbackContext _) => isRunning = false;

        internal void StopPlayerMovement(InputAction.CallbackContext _) => rawData = Vector3.zero;

        internal void PlayerJump(InputAction.CallbackContext _)
        {
            if (characterController.isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                characterController.Move(velocity);
                Invoke("ResetVelocity", 0.1f);
            }
        }
    }
}
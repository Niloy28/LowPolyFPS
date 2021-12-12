using UnityEngine;
using FPS.Input;

namespace FPS.Player
{
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerLook))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerInputs inputs;
        private PlayerMovement playerMovement;
        private PlayerAction playerAction;
        private PlayerLook playerLook;

        private void Awake()
        {
            CacheReferences();
            SetupInputs();
        }

        private void CacheReferences()
        {
            playerMovement = GetComponent<PlayerMovement>();
            playerAction = GetComponentInChildren<PlayerAction>();
            playerLook = GetComponent<PlayerLook>();
        }

        private void SetupInputs()
        {
            inputs = new PlayerInputs();

            inputs.Movement.Move.performed += playerMovement.ReadRawMovementData;
            inputs.Movement.Move.canceled += playerMovement.StopPlayerMovement;
            inputs.Movement.Run.performed += playerMovement.SetPlayerToRun;
            // disable shooting while running
            inputs.Movement.Run.performed += ctx => inputs.Action.Shoot.performed -= playerAction.Shoot;
            inputs.Movement.Run.canceled += playerMovement.SetPlayerToWalk;
            // enable shooting when walking
            inputs.Movement.Run.canceled += ctx => inputs.Action.Shoot.performed += playerAction.Shoot;
            inputs.Movement.Jump.performed += playerMovement.PlayerJump;

            inputs.Camera.Look.performed += playerLook.Look;

            inputs.Action.Shoot.performed += playerAction.Shoot;
            inputs.Action.Reload.performed += playerAction.Reload;
        }

        public void DisableInputs()
        {
            inputs.Disable();
        }

        private void OnEnable() => inputs.Enable();

        private void OnDisable() => inputs.Disable();
    }
}
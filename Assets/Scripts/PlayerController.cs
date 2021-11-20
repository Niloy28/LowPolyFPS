using UnityEngine;
using FPS.Input;

namespace FPS.Player
{
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerAction), typeof(PlayerLook))]
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
            playerAction = GetComponent<PlayerAction>();
            playerLook = GetComponent<PlayerLook>();
        }

        private void SetupInputs()
        {
            inputs = new PlayerInputs();
            inputs.Movement.Move.performed += playerMovement.ReadRawMovementData;
            inputs.Movement.Move.canceled += playerMovement.StopPlayerMovement;
            inputs.Movement.Run.performed += playerMovement.SetPlayerToRun;
            inputs.Movement.Run.canceled += playerMovement.SetPlayerToWalk;
            inputs.Movement.Jump.performed += playerMovement.PlayerJump;

            inputs.Camera.Look.performed += playerLook.Look;
        }

        private void OnEnable() => inputs.Enable();

        private void OnDisable() => inputs.Disable();
    }
}
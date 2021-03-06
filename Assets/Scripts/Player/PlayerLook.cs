using UnityEngine;
using UnityEngine.InputSystem;

namespace FPS.Player
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] private Transform gunCamera;
        [SerializeField] private float mouseSensitivity = 10f;
        [SerializeField] private float upwardRotationLimit = 25f;

        private float rotationAroundX;

        internal void Look(InputAction.CallbackContext ctx)
        {
            var lookData = ctx.ReadValue<Vector2>();
            transform.Rotate(Vector3.up * lookData.x * mouseSensitivity * Time.deltaTime);

            rotationAroundX += lookData.y * mouseSensitivity * Time.deltaTime;
            rotationAroundX = Mathf.Clamp(rotationAroundX, -upwardRotationLimit, upwardRotationLimit);
            gunCamera.localRotation = Quaternion.Euler(rotationAroundX, 0f, 0f);
        }
    }
}
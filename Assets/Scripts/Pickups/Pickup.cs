using UnityEngine;

namespace FPS
{
    public abstract class Pickup : MonoBehaviour
    {
        [SerializeField] protected float rotationSpeed = 50f;

        protected abstract void PickupAction(Collider collider);

        private void Update()
        {
            var rotation = rotationSpeed * Time.deltaTime;
            transform.Rotate(new Vector3(0f, 0f, rotation));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PickupAction(other);
            }
        }
    }
}
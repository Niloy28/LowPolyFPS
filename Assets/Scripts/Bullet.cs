using UnityEngine;

namespace FPS.Weapon
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float shootVelocity = 10f;
        [SerializeField] private float bulletLifetime = 2f;

        private Rigidbody rigidBody;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            Destroy(gameObject, bulletLifetime);
        }

        public void ApplyVelocity(Vector3 velocityDir)
        {
            rigidBody.velocity = velocityDir * shootVelocity;
        }

        private void OnCollisionEnter(Collision other)
        {
            GameEvents.FireBulletHitEvent();
            Destroy(gameObject);
        }
    }
}
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterMovement : MonoBehaviour
    {
        private Rigidbody _rb;

        [SerializeField] private float _speed;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            if (!_rb)
            {
                Debug.LogWarning("No rigidbody attached!");
                return;
            }

            _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ |
                              RigidbodyConstraints.FreezeRotationY;
        }

        private void Update()
        {
            if (!_rb) return;

            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            Vector3 move = transform.right * horizontal + transform.forward * vertical;
            Vector3 newVelocity = new Vector3(move.x * _speed, _rb.linearVelocity.y, move.z * _speed);
            _rb.linearVelocity = newVelocity;
        }
    }
}
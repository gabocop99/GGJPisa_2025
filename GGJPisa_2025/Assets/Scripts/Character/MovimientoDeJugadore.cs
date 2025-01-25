using Spanish;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovimientoDeJugadore : SoltieroComportamiento
    {
        private Rigidbody _elRb;

        [SerializeField] private float _velocidad;

        protected override void Magnana()
        {
            _elRb = GetComponent<Rigidbody>();
            if (!_elRb)
            {
                Debug.LogWarning("Atencion!! Nesun elRigidbody trovado!");
                return;
            }

            _elRb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ |
                                RigidbodyConstraints.FreezeRotationY;
        }

        protected override void Ajornamiendo()
        {
            if (!_elRb) return;

            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            Vector3 move = transform.right * horizontal + transform.forward * vertical;
            Vector3 newVelocity = new Vector3(move.x * _velocidad, _elRb.linearVelocity.y, move.z * _velocidad);
            _elRb.linearVelocity = newVelocity;
        }
    }
}
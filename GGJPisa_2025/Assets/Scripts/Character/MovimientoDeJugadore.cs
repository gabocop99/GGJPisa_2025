using Spanish;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovimientoDeJugadore : SoltieroComportamiento
    {
        private Rigidbody _elCuerpoRijido;

        [SerializeField] private Animator _animator;
        [SerializeField] private float _velocidad;

        protected override void Magnana()
        {
            _elCuerpoRijido = GetComponent<Rigidbody>();
            if (!_elCuerpoRijido)
            {
                Debug.LogWarning("Atencion!! Nesun elRigidbody trovado!");
                return;
            }

            _elCuerpoRijido.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ |
                                          RigidbodyConstraints.FreezeRotationY;
        }

        protected override void Ajornamiendo()
        {
            if (!_elCuerpoRijido) return;

            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            Vector3 move = transform.right * horizontal + transform.forward * vertical;
            Vector3 newVelocity =
                new Vector3(move.x * _velocidad, _elCuerpoRijido.linearVelocity.y, move.z * _velocidad);
            _elCuerpoRijido.linearVelocity = newVelocity;

            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            if (_elCuerpoRijido.linearVelocity != Vector3.zero)
            {
                _animator.SetFloat("velocidad", 1);
                return;
            }

            _animator.SetFloat("velocidad", 0);
        }
    }
}
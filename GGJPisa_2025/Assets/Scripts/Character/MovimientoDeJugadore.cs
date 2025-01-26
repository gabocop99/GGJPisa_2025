using System;
using System.Collections;
using Nemigos;
using Spanish;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovimientoDeJugadore : SoltieroComportamiento
    {
        public event Action JugadorColpido;

        public Rigidbody ElCuerpoRigido => _elCuerpoRijido;

        private Rigidbody _elCuerpoRijido;
        private bool _puedeMover = true;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _velocidad;
        [SerializeField] private float _stunStatoTiempo;

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
            if (_puedeMover)
            {
                _elCuerpoRijido.linearVelocity = newVelocity;
            }

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

        private IEnumerator ColpoIndietroCoroutine()
        {
            _puedeMover = false;
            yield return new WaitForSeconds(_stunStatoTiempo);
            _puedeMover = true;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.TryGetComponent<ColpoContrario>(out var knockback))
            {
                return;
            }

            JugadorColpido?.Invoke();

            var contact = other.contacts[0];
            var direction = transform.position - contact.point;
            var newDireccion = new Vector3(direction.x, 0, direction.z);
            newDireccion.Normalize();
            var force = newDireccion * knockback.ParaLaFuerza;

            _elCuerpoRijido.AddForce(force, ForceMode.Impulse);
            if (_puedeMover)
            {
                StartCoroutine(ColpoIndietroCoroutine());
            }
        }
    }
}
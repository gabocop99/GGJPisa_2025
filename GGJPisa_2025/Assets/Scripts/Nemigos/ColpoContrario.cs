using Character;
using Spanish;
using UnityEngine;

namespace Nemigos
{
    [RequireComponent(typeof(Collider))]
    public class ColpoContrario : SoltieroComportamiento
    {
        [SerializeField] private float _paraLaFuerza;
        public float ParaLaFuerza  => _paraLaFuerza;

        private Collider _collider;

        protected override void Magnana()
        {
            _collider = GetComponent<Collider>();
            if (!_collider)
            {
                return;
            }

            _collider.enabled = true;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<MovimientoDeJugadore>(out var movimiento))
            {
                var contact = other.contacts[0];
                
            }
        }

    }
}
using Spanish;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Nemigos
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class ComportamientoDeLiberdad : SoltieroComportamiento
    {
        [SerializeField] private float _liberdadRadius = 5;

        private NavMeshAgent _navMeshAgent;

        private void OnEnable()
        {
            if (_navMeshAgent == null)
            {
                _navMeshAgent = GetComponent<NavMeshAgent>();
            }

            _navMeshAgent.SetDestination(TruevaDestinaccion());
        }

        protected override void Ajornamiendo()
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _navMeshAgent.SetDestination(TruevaDestinaccion());
            }
        }

        private Vector3 TruevaDestinaccion()
        {
            var randomX = Random.Range(-_liberdadRadius, _liberdadRadius);
            var randomZ = Random.Range(-_liberdadRadius, _liberdadRadius);

            var nuevaDestinaccion = transform.position + new Vector3(randomX, 0, randomZ);
            return nuevaDestinaccion;
        }
    }
}
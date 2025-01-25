using System.Collections.Generic;
using Spanish;
using UnityEngine;
using UnityEngine.AI;

namespace Nemigos
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class ComportamientoDePatrulla : SoltieroComportamiento
    {
        private NavMeshAgent _agente;
        private int _currentPointIndex = 0;
        private bool _isWaiting = false;
        private bool _goingForward = true;
        public float _waitTimeAtPoint = 0;

        [SerializeField] private Transform[] _puntosDePatrulla;

        protected override void Magnana()
        {
            _agente = GetComponent<NavMeshAgent>();
        }

        protected override void Empieza()
        {
            if (_puntosDePatrulla.Length == 0)
            {
                Debug.LogWarning($"{name}: no punto de patrullas");
                return;
            }

            _agente.SetDestination(_puntosDePatrulla[0].position);
        }

        protected override void Ajornamiendo()
        {
            if (_puntosDePatrulla.Length == 0)
            {
                return;
            }

            if (_agente.remainingDistance <= _agente.stoppingDistance && !_isWaiting)
            {
                StartCoroutine(WaitAtPoint());
            }
        }

        private IEnumerator<WaitForSeconds> WaitAtPoint()
        {
            _isWaiting = true;
            yield return new WaitForSeconds(_waitTimeAtPoint);

            if (_goingForward)
            {
                if (_currentPointIndex < _puntosDePatrulla.Length - 1)
                {
                    _currentPointIndex++;
                }
                else
                {
                    _goingForward = false;
                    _currentPointIndex--;
                }
            }
            else
            {
                if (_currentPointIndex > 0)
                {
                    _currentPointIndex--;
                }
                else
                {
                    _goingForward = true;
                    _currentPointIndex++;
                }
            }

            _agente.SetDestination(_puntosDePatrulla[_currentPointIndex].position);
            _isWaiting = false;
        }
    }
}
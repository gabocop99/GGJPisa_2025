using System.Collections.Generic;
using Spanish;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Nemigos
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class ComportamientoDePatrulla : SoltieroComportamiento
    {
        private NavMeshAgent _agente;
        private int _currentPointIndex = 0;
        private bool _estaAspetando = false;
        private bool _seMueveAvanti = true;
        public float _tiempoDeAspetarAlaDestinacion = 0;

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

            if (_agente.remainingDistance <= _agente.stoppingDistance && !_estaAspetando)
            {
                StartCoroutine(WaitAtPoint());
            }
        }

        private IEnumerator<WaitForSeconds> WaitAtPoint()
        {
            _estaAspetando = true;
            yield return new WaitForSeconds(_tiempoDeAspetarAlaDestinacion);

            if (_seMueveAvanti)
            {
                if (_currentPointIndex < _puntosDePatrulla.Length - 1)
                {
                    _currentPointIndex++;
                }
                else
                {
                    _seMueveAvanti = false;
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
                    _seMueveAvanti = true;
                    _currentPointIndex++;
                }
            }

            _agente.SetDestination(_puntosDePatrulla[_currentPointIndex].position);
            _estaAspetando = false;
        }
    }
}
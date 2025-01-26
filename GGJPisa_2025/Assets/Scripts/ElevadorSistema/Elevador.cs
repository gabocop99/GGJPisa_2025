using System;
using ManajerDenemigos;
using Spanish;
using UnityEngine.Events;

namespace ElevadorSistema
{
    public class Elevador : SoltieroComportamiento
    {
        public event Action OnElevadorChiamado;

        public UnityEvent AnimacionTerminada;

        private void Start()
        {
            var manajero = FindFirstObjectByType<ManajerDeNemigos>();

            if (manajero != null)
            {
                ManajerDeNemigos.Istanzia.OnTodosNemigosLiberado += ChiamaElevador;
            }
        }

        private void ChiamaElevador()
        {
            OnElevadorChiamado?.Invoke();
        }
    }
}
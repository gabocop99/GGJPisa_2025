using System;
using ManajerDenemigos;
using Spanish;

namespace ElevadorSistema
{
    public class Elevador : SoltieroComportamiento
    {
        public event Action OnElevadorChiamado;

        private void Start()
        {
            ManajerDeNemigos.Istanzia.OnTodosNemigosLiberado += ChiamaElevador;
        }

        private void ChiamaElevador()
        {
            OnElevadorChiamado?.Invoke();
        }
    }
}
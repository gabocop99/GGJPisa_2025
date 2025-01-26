using System;
using Spanish;
using UnityEngine;

namespace Nemigos
{
    [RequireComponent(typeof(GestorDeBersallos), typeof(ComportamientoDePatrulla), typeof(ComportamientoDeLiberdad))]
    public class GestorDeStadoDeNemigo : SoltieroComportamiento
    {
        private GestorDeBersallos _gestorDeBersallos;
        private ComportamientoDePatrulla _comportamientoDePatrulla;
        private ComportamientoDeLiberdad _comportamientoDeLiberdad;

        public event Action OnValueChanged;

        public bool IsHappy
        {
            get => IsHappy;
            set { OnValueChanged?.Invoke(); }
        }

        protected override void Magnana()
        {
            _gestorDeBersallos = GetComponent<GestorDeBersallos>();
            _comportamientoDePatrulla = GetComponent<ComportamientoDePatrulla>();
            _comportamientoDeLiberdad = GetComponent<ComportamientoDeLiberdad>();
            _gestorDeBersallos.BersallosDestruidos += SuBersallosDestruidos;
        }

        private void SuBersallosDestruidos()
        {
            //change state
            _comportamientoDePatrulla.enabled = false;
            _comportamientoDeLiberdad.enabled = true;
            IsHappy = true;
        }
    }
}
using System;
using Patterns;
using UnityEngine;

namespace Juego
{
    public class GestorDeJuego : Solidario<GestorDeJuego>
    {
        public event Action SulTerminarDeJuego;
        [SerializeField] private float _timerDeJuego = 240;

        private void Update()
        {
            _timerDeJuego -= Time.deltaTime;

            if (_timerDeJuego <= 0)
            {
                SulTerminarDeJuego?.Invoke();
            }
        }
    }
}
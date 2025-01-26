using UnityEngine;
using UnityEngine.UI;

namespace Character
{
    public class GestorDeHUD : MonoBehaviour
    {
        private MovimientoDeJugadore _movimientoDeJugador;
        public RawImage Image;
        
        
        private void Start()
        {
            _movimientoDeJugador = FindFirstObjectByType<MovimientoDeJugadore>();
            _movimientoDeJugador.JugadorColpido += SulJugadorColpido;
            _movimientoDeJugador.JugadorRinsavido += SulJugadorRinsavido;
        }

        private void SulJugadorColpido()
        {
            Image.enabled = true;
        }

        private void SulJugadorRinsavido()
        {
            Image.enabled = false;
        }
    }
}

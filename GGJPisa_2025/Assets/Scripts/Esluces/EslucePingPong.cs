using Spanish;
using UnityEngine;

namespace Esluces
{
    public class PingPongFloat : SoltieroComportamiento
    {
        [SerializeField] private Light _esluce;

        // Define the minimum and maximum values
        public float ValorMinor = 0f;
        public float ValorMasimo = 1f;

        // Speed of oscillation
        public float Velocidad = 1f;
        public float Tiempo;

        // The float variable that will oscillate
        private float _valorCorente;

        protected override void Magnana()
        {
            _esluce = GetComponent<Light>();

            _valorCorente = _esluce.intensity;
        }

        protected override void Ajornamiendo()
        {
            // Calculate the current value using Mathf.PingPong
            _valorCorente = Mathf.Lerp(ValorMinor, ValorMasimo, Mathf.PingPong(Time.time * Velocidad, Tiempo));

            _esluce.intensity = _valorCorente;
        }
    }
}
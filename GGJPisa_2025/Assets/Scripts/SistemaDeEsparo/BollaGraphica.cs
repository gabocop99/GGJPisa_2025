using Spanish;
using UnityEngine;

namespace SistemaDeEsparo
{
    public class BollaGraphica : SoltieroComportamiento
    {
        [SerializeField] private float _rimbalzoPeriodo;
        [SerializeField] private float _rimbalzoAmplitude;

        private float _timer;

        private int _random;

        private Vector3 _startPositiones;

        protected override void Magnana()
        {
            _startPositiones = transform.localPosition;

            _random = Random.Range(0, 2);
        }

        protected override void Ajornamiendo()
        {
            _timer += Time.deltaTime;

            if (_random == 0)
            {
                var newY = _startPositiones.y +
                           Mathf.Sin(_timer * _rimbalzoPeriodo) * _rimbalzoAmplitude;

                transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
            }
            else
            {
                var nuevaY = _startPositiones.y -
                             Mathf.Sin(_timer * _rimbalzoPeriodo) * _rimbalzoAmplitude;

                transform.localPosition = new Vector3(transform.localPosition.x, nuevaY, transform.localPosition.z);
            }
        }
    }
}
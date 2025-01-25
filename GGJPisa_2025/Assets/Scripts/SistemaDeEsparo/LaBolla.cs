using System;
using Character;
using Patterns;
using Spanish;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SistemaDeEsparo
{
    public class LaBolla : SoltieroComportamiento
    {
        [SerializeField] private BollaDatas _datas;

        [SerializeField] private float _rimbalzoAmplitude;
        [SerializeField] private float _rimbalzoPeriodo;

        private float _timer = 0f;

        private Vector3 _startPositiones;

        private int _random;

        protected override void Magnana()
        {
            _startPositiones = transform.position;

            _timer = 0f;

            _random = Random.Range(0, 2);
        }

        protected override void Ajornamiendo()
        {
            _timer += Time.deltaTime;

            transform.Translate(Vector3.forward * (_datas.Velocidad * Time.deltaTime), Space.Self);

            if (_timer >= _datas.TiempoDeVida)
            {
                Destroy(gameObject);
            }


            if (_random == 0)
            {
                var newY = _startPositiones.y +
                           Mathf.Sin(_timer * _rimbalzoPeriodo) * _rimbalzoAmplitude;

                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
            else
            {
                var nuevaY = _startPositiones.y -
                             Mathf.Sin(_timer * _rimbalzoPeriodo) * _rimbalzoAmplitude;

                transform.position = new Vector3(transform.position.x, nuevaY, transform.position.z);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<MovimientoDeJugadore>(out var movimientoDeJugador))
            {
                Destroy(gameObject);
            }
        }
    }
}

public class AudiosManajer : Solidario<AudiosManajer>
{
    public void ReproducirSuenoEnLoco()
    {
    }
}
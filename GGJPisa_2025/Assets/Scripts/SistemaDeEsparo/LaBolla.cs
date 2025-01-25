using Spanish;
using Unity.Mathematics;
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
        private float _offsetRandomico;

        private Vector3 _startPositiones;

        private int _random;

        protected override void Magnana()
        {
            _startPositiones = transform.position;

            _offsetRandomico = Random.Range(0f, 2f) * Mathf.PI;

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
    }
}
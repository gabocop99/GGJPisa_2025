using System;
using System.Collections;
using Character;
using Spanish;
using Suenos;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace SistemaDeEsparo
{
    public class LaBolla : SoltieroComportamiento
    {
        [SerializeField] private BollaDatas _datas;

        [SerializeField] private float _rimbalzoAmplitude;
        [SerializeField] private float _rimbalzoPeriodo;

        [SerializeField] private string _estringaPorSuono = "bolla";

        public UnityEvent Eviento;

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
            var jugador = other.GetComponent<MovimientoDeJugadore>();

            if (jugador == null)
            {
                var mesh = GetComponentInChildren<MeshRenderer>();

                if (mesh != null)
                {
                    mesh.enabled = false;
                    StartCoroutine(MataloCoroutine());
                }
            }
        }

        private IEnumerator MataloCoroutine()
        {
            Eviento?.Invoke();
            AudiosManajer.Istanzia.ReproducirSuenoEnLugar(_estringaPorSuono, transform);
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}
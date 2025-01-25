using System.Collections;
using Character;
using Spanish;
using Suenos;
using UnityEngine;
using UnityEngine.Events;

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

        private int _random;

        protected override void Magnana()
        {
            _timer = 0f;
        }

        protected override void Ajornamiendo()
        {
            _timer += Time.deltaTime;

            transform.Translate(Vector3.forward * (_datas.Velocidad * Time.deltaTime));

            if (_timer >= _datas.TiempoDeVida)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var jugador = other.GetComponent<MovimientoDeJugadore>();

            if (jugador == null)
            {
                var mesh = GetComponentInChildren<MeshRenderer>();

                var elColidero = GetComponent<Collider>();

                if (elColidero != null)
                {
                    elColidero.enabled = false;
                }

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
using System.Collections;
using Spanish;
using UnityEngine;

namespace SistemaDeEsparo
{
    public class Pistolas : SoltieroComportamiento
    {
        [SerializeField] private LaBolla _bolla;

        [Header("Los Datos De Lo Esparo")] [SerializeField]
        private int _maxMuniciones;

        [SerializeField] private float _tiempoDeRecarga;
        [SerializeField] private float _ritardoDeUnColpoElAltro;

        private Transform _puntoDeEsparo;

        private int _municionesActual;

        private Coroutine _recargarCoroutine;
        private Coroutine _esparoCoroutine;

        protected override void Magnana()
        {
            var puntoDeEsparo = GetComponentInChildren<PuntoDeEsparo>();

            if (puntoDeEsparo == null)
            {
                Debug.Log("Atencion!! Manca el punto de Esparo!!!");
                return;
            }

            _puntoDeEsparo = puntoDeEsparo.transform;

            _municionesActual = _maxMuniciones;
        }

        protected override void Ajornamiendo()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _recargarCoroutine ??= StartCoroutine(RecargarCoroutine());
            }

            if (Input.GetMouseButton(0) && _recargarCoroutine == null && _municionesActual > 0)
            {
                _esparoCoroutine ??= StartCoroutine(EspararCoroutine());
            }
        }

        private IEnumerator EspararCoroutine()
        {
            var nuevabolla = Instantiate(_bolla, _puntoDeEsparo.position, _puntoDeEsparo.rotation);
            _municionesActual--;
            yield return new WaitForSeconds(_ritardoDeUnColpoElAltro);
            _esparoCoroutine = null;
        }

        private IEnumerator RecargarCoroutine()
        {
            Debug.Log("Recargando");
            yield return new WaitForSeconds(_tiempoDeRecarga);
            Debug.Log("RecargaCompletada");
            _municionesActual = _maxMuniciones;
            _recargarCoroutine = null;
        }
    }
}
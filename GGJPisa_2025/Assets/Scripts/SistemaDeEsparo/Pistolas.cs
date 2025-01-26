using System.Collections;
using Spanish;
using UnityEngine;

namespace SistemaDeEsparo
{
    public class Pistolas : SoltieroComportamiento
    {
        [SerializeField] private LaBolla _bolla;

        [SerializeField] private ElGestorDeLeMunicionas _elMunicionasBoss;

        [Header("Los Datos De Lo Esparo")] [SerializeField]
        private float _tiempoDeRecarga;

        [SerializeField] private float _ritardoDeUnColpoElAltro;

        private Transform _puntoDeEsparo;

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

            var municionasBoos = GetComponent<ElGestorDeLeMunicionas>();

            if (municionasBoos == null)
            {
                Debug.Log("Atencion!! Manca el municionas boss!!!");
            }
        }

        protected override void Ajornamiendo()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _recargarCoroutine ??= StartCoroutine(RecargarCoroutine());
            }

            if (Input.GetMouseButton(0) && _recargarCoroutine == null &&
                _elMunicionasBoss.MunicionasCorenteNelCarigador > 0)
            {
                _esparoCoroutine ??= StartCoroutine(EspararCoroutine());
            }
        }

        private IEnumerator EspararCoroutine()
        {
            Instantiate(_bolla, _puntoDeEsparo.position, _puntoDeEsparo.rotation);
            _elMunicionasBoss.MunicionasCorenteNelCarigador--;
            yield return new WaitForSeconds(_ritardoDeUnColpoElAltro);
            _esparoCoroutine = null;
        }

        private IEnumerator RecargarCoroutine()
        {
            Debug.Log("Recargando");
            yield return new WaitForSeconds(_tiempoDeRecarga);
            _elMunicionasBoss.Recargar();
            _recargarCoroutine = null;
        }
    }
}
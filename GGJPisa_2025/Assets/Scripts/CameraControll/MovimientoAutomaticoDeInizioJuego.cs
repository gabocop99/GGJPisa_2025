using System.Collections;
using Sirenix.OdinInspector;
using Spanish;
using UnityEngine;

namespace CameraControll
{
    public class MovimientoAutomaticoDeInizioJuego : SoltieroComportamiento
    {
        public float Velocidad;
        public Transform Destinationes;

        private Coroutine movimiento;

        [Button]
        public void PruevaAChiamarMovimiento()
        {
            movimiento ??= StartCoroutine(MovimientoEnAvanti());
        }

        private IEnumerator MovimientoEnAvanti()
        {
            while (Vector3.Distance(transform.position, Destinationes.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, Destinationes.position,
                    Velocidad * Time.deltaTime);
                yield return null;
            }
            
            movimiento = null;
        }
    }
}
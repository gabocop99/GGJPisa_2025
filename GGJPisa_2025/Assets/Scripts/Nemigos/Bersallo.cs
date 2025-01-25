using System;
using SistemaDeEsparo;
using Spanish;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Nemigos
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class Bersallo : SoltieroComportamiento
    {
        public event Action SulBersalloColpipdo;
        public event Action BersalloDestruido;


        private Rigidbody _rb;
        private Collider _col;

        [SerializeField] private float _puntosVida;


        // nemico variabii: hp (numero di punti deboli), velocità, knockback force
        // moltiplicatore velocità per cambiamento stato

        //Stati: patrol (lista di punti), hp = 0 -> liberato (radius 5m punto randomico all'infinito)ù
        //tati Inserviente: patrol, pulizia () 


        protected override void Magnana()
        {
            base.Magnana();

            _rb = GetComponent<Rigidbody>();
            _col = GetComponent<Collider>();

            if (!_rb || !_col) return;

            _rb.isKinematic = true;
            _rb.useGravity = false;
            _col.enabled = true;
            _col.isTrigger = true;
        }

        private void TomaDanno(int danno = 1)
        {
            var nuevaVida = _puntosVida - danno;
            if (nuevaVida > 0)
            {
                _puntosVida -= danno;
                return;
            }

            BersalloDestruido?.Invoke();
            DestrujeElBersallo();
            
        }

        private void DestrujeElBersallo()
        {
            gameObject.SetActive(false);
            Debug.Log("Disactiva el trigger");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.GetComponent<LaBolla>())
            {
                return;
            }
            
            SulBersalloColpipdo?.Invoke();
            TomaDanno();

            Debug.Log("SulBersallo Colpipdo");

        }
    }
}
using System;
using Spanish;
using UnityEngine;

namespace Nemigos
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class Bersallo : SoltieroComportamiento
    {
        public event Action SulBersalloColpipdo;
        public event Action SulBersalloDestructo;


        private Rigidbody _rb;
        private Collider _col;

        [SerializeField] private float _puntosVida;


        //private 

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

            SulBersalloDestructo?.Invoke();
            DisactivaElTrigger();
        }

        private void DisactivaElTrigger()
        {
            _col.enabled = false;
            Debug.Log("Disactiva el trigger");
        }

        private void OnTriggerEnter(Collider other)
        {
            SulBersalloColpipdo?.Invoke();

            TomaDanno();

            Debug.Log("SulBersallo Colpipdo");
        }
    }
}
using System;
using System.Collections.Generic;
using Spanish;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Nemigos
{
    public class GestorDeBersallos : SoltieroComportamiento
    {
        public event Action BersallosDestruidos;
        
        [SerializeField] private Transform[] _bersallosTransform;
        [SerializeField] private int _cuantosBersallos;

        private int _puntosVida;


        public GameObject Prefab;

        protected override void Magnana()
        {
            if (_cuantosBersallos == 0)
            {
                Debug.LogWarning("Conta has que ser major de zero");
                return;
            }

            InitCavidades();

            _puntosVida = _cuantosBersallos;
        }

        void InitCavidades()
        {
            var numeroDeCavidad = _bersallosTransform.Length;

            if (numeroDeCavidad < _cuantosBersallos)
            {
                Debug.LogWarning("_bersallosTransform.Length < _cuantosBersallos");
                return;
            }

            int min = 0;

            int count = _cuantosBersallos;

            HashSet<int> uniqueNumbers = new HashSet<int>();

            while (uniqueNumbers.Count < count)
            {
                uniqueNumbers.Add(Random.Range(min, numeroDeCavidad));
            }


            foreach (var number in uniqueNumbers)
            {
                var transformaBersallo = _bersallosTransform[number];
                var bersallo = Instantiate(Prefab, transformaBersallo.position, transformaBersallo.rotation);
                bersallo.transform.SetParent(this.transform);
                bersallo.GetComponent<Bersallo>().BersalloDestruido += SulBersalloDestruido;
            }
        }

        private void SulBersalloDestruido()
        {
            int nuevaVida = _puntosVida - 1;
            if (nuevaVida <= 0)
            {
                BersallosDestruidos?.Invoke();
                Debug.Log("Bersallos destruido");
                return;
            }

            _puntosVida = nuevaVida;
        }
    }
}
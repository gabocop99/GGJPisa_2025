using System;
using System.Collections.Generic;
using System.Linq;
using Nemigos;
using Patterns;
using UnityEngine;

namespace ManajerDenemigos
{
    public class ManajerDeNemigos : Solidario<ManajerDeNemigos>
    {
        [SerializeField] private List<GestorDeStadoDeNemigo> _nemigos = new List<GestorDeStadoDeNemigo>();

        public event Action OnTodosNemigosLiberado;

        private int _contador = 0;

        private void Start()
        {
            var nemigos = FindObjectsByType<GestorDeStadoDeNemigo>(default);

            _nemigos = nemigos.ToList();

            foreach (var nemigo in _nemigos)
            {
                nemigo.OnValueChanged += ContollaNemigosLiberados;
            }
        }

        private void ContollaNemigosLiberados()
        {
            _contador++;

            if (_contador >= _nemigos.Count)
            {
                OnTodosNemigosLiberado?.Invoke();
                Debug.Log("NemigosLiberados");
            }
        }
    }
}
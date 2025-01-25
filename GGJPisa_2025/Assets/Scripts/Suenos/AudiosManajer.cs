using System;
using System.Collections.Generic;
using UnityEngine;

namespace Suenos
{
    public class AudiosManajer : SolidarioSerializado<AudiosManajer>
    {
        [SerializeField] private Dictionary<String, AudioClip> _suenos = new Dictionary<String, AudioClip>();

        [SerializeField] private AudioSource[] _fontiDeAudio;

        public void ReproducirSuenoEnLugar(String nome, Transform lugar)
        {
            if (_suenos.TryGetValue(nome.ToLower(), out var sueno))
            {
                transform.position = lugar.position;

                _fontiDeAudio[0].PlayOneShot(sueno);
            }
        }
    }
}
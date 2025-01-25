using System.Collections.Generic;
using Spanish;
using UnityEngine;

namespace Nemigos
{
    public class GestorDeBersallos : SoltieroComportamiento
    {
        public List<Bersallo> Bersallos;
        [SerializeField] private Transform[] _bersallosTransform;

        protected override void Empieza()
        {
            //Inizializza le cavidad, 
        }
    }
}

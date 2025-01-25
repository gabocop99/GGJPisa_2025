using System;
using Spanish;
using UnityEngine;

namespace Nemigos
{
    public class Bersallo : SoltieroComportamiento
    {
        public event Action SulBersalloColpipdo;
        
        private void Update()
        {
            throw new NotImplementedException();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            SulBersalloColpipdo?.Invoke();
        }
    }
}

using Spanish;
using UnityEngine;

namespace Nemigos
{
    [RequireComponent(typeof(GestorDeBersallos))]
    public class GestorDeStadoDeNemigo : SoltieroComportamiento
    {
        private GestorDeBersallos _gestorDeBersallos;
        

        protected override void Magnana()
        {
            _gestorDeBersallos = GetComponent<GestorDeBersallos>();
            _gestorDeBersallos.BersallosDestruidos += SuBersallosDestruidos;

        }

        private void SuBersallosDestruidos()
        {
            //change state
        }
    }
}

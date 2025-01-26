using System;
using System.Collections.Generic;
using Nemigos;
using Patterns;
using Spanish;
using UnityEngine;

namespace ElevadorSistema
{
    public class Elevador : SoltieroComportamiento
    {
        [SerializeField] private ManajerDeNemigos _manajerDeNemigos;


        public event Action OnElevadorChiamado;
    }
}

public class ManajerDeNemigos : Solidario<ManajerDeNemigos>
{
    [SerializeField] private List<GestorDeStadoDeNemigo> _nemigos = new List<GestorDeStadoDeNemigo>();
}
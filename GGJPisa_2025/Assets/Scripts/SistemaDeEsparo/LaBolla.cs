using Spanish;
using UnityEngine;

namespace SistemaDeEsparo
{
    public class LaBolla : SoltieroComportamiento
    {
    }
}

public class BollaDatas : ScriptableObject
{
    [SerializeField] private int _velocidad;

    public int Velocidad
    {
        get { return _velocidad; }
    }
}
using UnityEngine;

namespace SistemaDeEsparo
{
    [CreateAssetMenu(fileName = "LaBolla", menuName = "Bolles/NuevaBolla")]
    public class BollaDatas : ScriptableObject
    {
        [SerializeField] private float _velocidad;
        [SerializeField] private float _tiempoDeVida;

        public float Velocidad
        {
            get { return _velocidad; }
        }

        public float TiempoDeVida
        {
            get { return _tiempoDeVida; }
        }
    }
}
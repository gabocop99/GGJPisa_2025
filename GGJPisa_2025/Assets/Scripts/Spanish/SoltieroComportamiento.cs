using UnityEngine;

namespace Spanish
{
    public abstract class SoltieroComportamiento : MonoBehaviour
    {
        private void Awake()
        {
            Magnana();
        }

        private void Start()
        {
            Empieza();
        }

        private void Update()
        {
            Ajornamiendo();
        }

        protected virtual void Ajornamiendo()
        {
        }

        protected virtual void Magnana()
        {
        }

        protected virtual void Empieza()
        {
        }
    }
}
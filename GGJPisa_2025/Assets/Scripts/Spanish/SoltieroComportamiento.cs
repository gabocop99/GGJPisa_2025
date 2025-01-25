using System.Collections;
using UnityEngine;

namespace Spanish
{
    public class SoltieroComportamiento : MonoBehaviour
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

        protected void IniziaProceso(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
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
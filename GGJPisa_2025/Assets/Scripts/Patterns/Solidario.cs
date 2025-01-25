using Sirenix.OdinInspector;
using UnityEngine;

namespace Patterns
{
    public class Solidario<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Istanzia;

        private void Awake()
        {
            if (!Istanzia)
            {
                Istanzia = this as T;
                return;
            }

            Destroy(gameObject);
        }
    }
}

public class SolidarioSerializado<T> : SerializedMonoBehaviour where T : SerializedMonoBehaviour
{
    public static T Istanzia;

    private void Awake()
    {
        if (!Istanzia)
        {
            Istanzia = this as T;
            return;
        }

        Destroy(gameObject);
    }
}
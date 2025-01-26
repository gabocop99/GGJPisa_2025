using Character;
using SistemaDeEsparo;
using UnityEngine;

public class Secchio : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<MovimientoDeJugadore>();
        var pistola = player.GetComponentInChildren<ElGestorDeLeMunicionas>();
        if(pistola != null)
        {
            pistola.MunicionasCorenteNeloZaino = pistola.MaxReservaDeMunicionas;
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void QuitarAplicacion()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void IniciaPartida()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void AbrirOpciones()
    {
        Debug.Log("menu is clicked");
    }
}

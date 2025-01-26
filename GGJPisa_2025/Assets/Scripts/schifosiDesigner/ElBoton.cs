using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ElBoton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void IniciaPartida()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    public void QuitarAplicacion()
    {
        Application.Quit();
    }

    public void AbrirOpciones()
    {
        Debug.Log("menu is clicked");
    }
}

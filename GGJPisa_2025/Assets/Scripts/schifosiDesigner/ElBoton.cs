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


    public void AlMenu()
    {
        Time.timeScale = 1;  // Unpause the game
        Debug.Log("load main menu");
        SceneManager.LoadScene(0);
    }

    public void AlProximoLivel()
    {
        Time.timeScale = 1;  // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}

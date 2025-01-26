using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gameOverMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void RestartLevel()
    {
        
        Time.timeScale = 1;  // Unpause the game
        Cursor.lockState = CursorLockMode.Locked; // Blocca il cursore
        Cursor.visible = false; // Nascondi il cursore
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    public void ToMenu()
    {
        Time.timeScale = 1;  // Unpause the game
        Debug.Log("load main menu");
        SceneManager.LoadScene(0);
    }

}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

  public class El_Reloj : MonoBehaviour
{
    public float currentHour;
    public float startingHour;
    public TextMeshProUGUI timeText;
    public float endHour;
    public GameObject GameOverMenu;
    
    void Start()
    {
        Time.timeScale = 1;
        currentHour = startingHour;
    }

    void Update()
    {
        currentHour += Time.deltaTime;
        
        timeText.text = string.Format("{0:00}:{1:00}", Mathf.Floor(currentHour / 60), currentHour % 60);

        if(currentHour >= endHour) 
        {

            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None; // Sblocca il cursore
            Cursor.visible = true; // Mostra il cursore
            Debug.Log("open lose menu");
        }
    }
}

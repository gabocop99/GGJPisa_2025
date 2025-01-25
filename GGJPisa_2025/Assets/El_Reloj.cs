using UnityEngine;
using UnityEngine.UI;
using TMPro;

  public class El_Reloj : MonoBehaviour
{
    public float currentHour;
    public float startingHour;
    public TextMeshProUGUI timeText;
    public float endHour;
    
    void Start()
    {
        currentHour = startingHour;
    }

    void Update()
    {
        currentHour += Time.deltaTime;

        timeText.text = currentHour.ToString("F00");

        if(currentHour >= endHour) 
        {
            Debug.Log("lose");
        }
    }
}

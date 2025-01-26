using Character;
using Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ElevadorSistema
{
    public class CargadorDeLaYscena : Solidario<CargadorDeLaYscena>
    {
        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<MovimientoDeJugadore>();

            if (other != null)
            {
                LoadNextScene();
            }
        }
        
        public void LoadNextScene()
        {
            // Ottieni l'indice della scena attuale
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Calcola l'indice della prossima scena
            int nextSceneIndex = currentSceneIndex + 1;

            // Se supera l'ultimo indice, ricomincia da zero
            if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0; // Torna alla prima scena
            }

            // Carica la scena successiva
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
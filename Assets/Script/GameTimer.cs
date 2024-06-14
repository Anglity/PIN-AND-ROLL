using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60; // 60 segundos de tiempo total
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText; // Cambia a TextMeshProUGUI
    public TextMeshProUGUI loseText; // Añade un campo para el texto de "Perdiste"

    private void Start()
    {
        // Inicia el temporizador al comenzar el juego
        timerIsRunning = true;
        if (loseText != null)
        {
            loseText.gameObject.SetActive(false); // Asegúrate de que el texto de "Perdiste" esté oculto al inicio
        }
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;

                // Maneja lo que sucede cuando el tiempo se acaba
                TimeHasRunOut(); // Llama a un método que maneje lo que pasa cuando se acaba el tiempo
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // Asegura que el tiempo se muestra correctamente

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimeHasRunOut()
    {
        if (loseText != null)
        {
            loseText.gameObject.SetActive(true); // Muestra el texto de "Perdiste"
            loseText.text = "¡Perdiste!";
        }

        // Espera unos segundos antes de recargar la escena actual
        Invoke("ReloadCurrentScene", 3f);
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena actual
    }
}

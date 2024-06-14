using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseGameController : MonoBehaviour
{
    public float timeRemaining = 60; // 60 segundos de tiempo total
    public bool timerIsRunning = false;
    public bool hasWon = false; // Agregar una bandera para determinar si el jugador ha ganado
    public TextMeshProUGUI timeText; // Componente TextMeshProUGUI para mostrar el tiempo
    public TextMeshProUGUI loseText; // Componente TextMeshProUGUI para mostrar el mensaje de "Perdiste"

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

                if (!hasWon)
                {
                    TimeHasRunOut(); // Llama a un método que maneje lo que pasa cuando se acaba el tiempo
                }
            }
        }

        // Verificar si el jugador ha ganado
        if (hasWon)
        {
            WinGame();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimeHasRunOut()
    {
        if (loseText != null)
        {
            loseText.gameObject.SetActive(true);
            loseText.text = "¡Perdiste!";
        }

        // Recargar la escena actual
        Invoke("ReloadScene", 3f);
    }

    void WinGame()
    {
        Debug.Log("Player has won!");
        // Avanzar a la siguiente escena
        Invoke("LoadNextLevel", 3f);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

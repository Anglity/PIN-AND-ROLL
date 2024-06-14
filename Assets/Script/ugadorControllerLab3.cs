using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class JugadorControllerLab3 : MonoBehaviour
{
    private Rigidbody rb;
    private int contador;
    public TextMeshProUGUI textoContador, textoGanar;
    public float velocidad;

    private GameTimer gameTimer; // Referencia al script del temporizador

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        gameTimer = FindObjectOfType<GameTimer>(); // Encuentra el temporizador en la escena
        setTextoContador();
        if (textoGanar != null)
        {
            textoGanar.text = "";
            textoGanar.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);
        rb.AddForce(movimiento * velocidad);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            contador++;
            setTextoContador();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            contador--;
            setTextoContador();
        }
    }

    void setTextoContador()
    {
        if (textoContador != null) textoContador.text = "Contador: " + contador.ToString();
        if (contador >= 6) // Asumiendo que 6 es el n�mero total de coleccionables necesarios para ganar
        {
            GanarJuego();
        }
    }

    void GanarJuego()
    {
        if (textoGanar != null)
        {
            textoGanar.text = "�Ganaste!";
            textoGanar.gameObject.SetActive(true);
        }

        if (gameTimer != null)
        {
            gameTimer.timerIsRunning = false; // Detener el temporizador
        }

        Invoke("LoadNextLevelOrMainMenu", 5f); // Llamar a LoadNextLevelOrMainMenu despu�s de 5 segundos
    }

    void LoadNextLevelOrMainMenu()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "level6" || currentSceneName == "juego")
        {
            BackToMainMenu(); // Volver al men� principal si es "level6" o "juego"
        }
        else
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1); // Cargar la siguiente escena en el �ndice de build
        }
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Aseg�rate de que "MainMenu" es el nombre de tu escena de men� principal
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recargar la escena actual
    }

    void PerderJuego()
    {
        if (textoGanar != null)
        {
            textoGanar.text = "�Perdiste!";
            textoGanar.gameObject.SetActive(true);
        }

        if (gameTimer != null)
        {
            gameTimer.timerIsRunning = false; // Detener el temporizador
        }

        Invoke("ReloadScene", 5f); // Llamar a ReloadScene despu�s de 5 segundos
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class JugadorController : MonoBehaviour
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
        if (contador >= 12) // Asumiendo que 12 es el número total de coleccionables necesarios para ganar
        {
            GanarJuego();
        }
    }

    void GanarJuego()
    {
        if (textoGanar != null)
        {
            textoGanar.text = "¡Ganaste!";
            textoGanar.gameObject.SetActive(true);
        }

        if (gameTimer != null)
        {
            gameTimer.timerIsRunning = false; // Detener el temporizador
        }

        Invoke("LoadNextLevel", 5f); // Llamar a LoadNextLevel después de 5 segundos
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene("MainMenu"); // Volver al menú principal si es la última escena
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1); // Cargar la siguiente escena en el índice de build
        }
    }

    void PerderJuego()
    {
        if (textoGanar != null)
        {
            textoGanar.text = "¡Perdiste!";
            textoGanar.gameObject.SetActive(true);
        }

        if (gameTimer != null)
        {
            gameTimer.timerIsRunning = false; // Detener el temporizador
        }

        Invoke("ReloadScene", 5f); // Llamar a ReloadScene después de 5 segundos
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recargar la escena actual
    }
}

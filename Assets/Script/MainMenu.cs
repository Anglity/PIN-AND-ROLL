using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Iniciar la música
        audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StartGame()
    {
        // Detener la música al empezar el juego
        audioSource.Stop();

        SceneManager.LoadScene("juego"); // Asegúrate de que "juego" es el nombre de tu primer nivel
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

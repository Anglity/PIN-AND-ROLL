using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Iniciar la m�sica
        audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StartGame()
    {
        // Detener la m�sica al empezar el juego
        audioSource.Stop();

        SceneManager.LoadScene("juego"); // Aseg�rate de que "juego" es el nombre de tu primer nivel
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

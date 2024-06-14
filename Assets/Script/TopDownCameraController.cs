using UnityEngine;

public class TopDownCameraController : MonoBehaviour
{
    // Referencia a nuestro jugador
    public GameObject jugador;
    // Para registrar la diferencia entre la posición de la cámara y la del jugador
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        // diferencia entre la posición de la cámara y la del jugador
        offset = new Vector3(0, 10, 0); // Ajusta la posición para estar encima del jugador
    }

    // Se ejecuta cada frame, pero después de haber procesado todo. Es más exacto para la cámara
    void LateUpdate()
    {
        // Actualizo la posición de la cámara para estar encima del jugador
        transform.position = jugador.transform.position + offset;
        // Rotar la cámara para mirar hacia abajo
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}

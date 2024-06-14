using UnityEngine;

public class TopDownCameraController : MonoBehaviour
{
    // Referencia a nuestro jugador
    public GameObject jugador;
    // Para registrar la diferencia entre la posici�n de la c�mara y la del jugador
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        // diferencia entre la posici�n de la c�mara y la del jugador
        offset = new Vector3(0, 10, 0); // Ajusta la posici�n para estar encima del jugador
    }

    // Se ejecuta cada frame, pero despu�s de haber procesado todo. Es m�s exacto para la c�mara
    void LateUpdate()
    {
        // Actualizo la posici�n de la c�mara para estar encima del jugador
        transform.position = jugador.transform.position + offset;
        // Rotar la c�mara para mirar hacia abajo
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}

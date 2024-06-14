using UnityEngine;

public class TrapController : MonoBehaviour
{
    public float activeTime = 2.0f;  // Tiempo que la trampa est� activa
    public float inactiveTime = 2.0f;  // Tiempo que la trampa est� inactiva

    private bool isActive = false;
    private float timer;

    void Start()
    {
        timer = inactiveTime;  // Inicia con la trampa inactiva
        SetTrapState(false);  // Aseg�rate de que la trampa est� inactiva al inicio
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            isActive = !isActive;
            SetTrapState(isActive);

            if (isActive)
            {
                timer = activeTime;
            }
            else
            {
                timer = inactiveTime;
            }
        }
    }

    void SetTrapState(bool state)
    {
        // Habilitar o deshabilitar el collider
        GetComponent<Collider>().enabled = state;

        // Habilitar o deshabilitar el renderer para hacer la trampa visible o invisible
        GetComponent<Renderer>().enabled = state;
    }
}

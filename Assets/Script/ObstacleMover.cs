using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public Vector3 puntoA;
    public Vector3 puntoB;
    public float velocidad = 1.0f;

    private Vector3 objetivo;

    void Start()
    {
        objetivo = puntoB;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);

        if (transform.position == puntoB)
        {
            objetivo = puntoA;
        }
        else if (transform.position == puntoA)
        {
            objetivo = puntoB;
        }
    }
}

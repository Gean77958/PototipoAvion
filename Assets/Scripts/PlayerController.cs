using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Cambiamos a 'public' para poder ajustar la velocidad desde el Inspector de Unity
    public float speed = 20.0f;
    public float turnSpeed = 45.0f; // <--- Asignamos una velocidad de giro inicial

    private float horizontalInput;
    private float forwardInput;

    void Start()
    {

    }

    void Update()
    {
        // Capturar los ejes de entrada (WASD / Flechas)
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Avanzar/retroceder
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Girar (solo cuando el auto se esté moviendo o se presione A/D)
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
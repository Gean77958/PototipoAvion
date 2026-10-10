using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControllerX : MonoBehaviour
{
    [Header("Ajustes de Vuelo")]
    public float speed = 15.0f;
    public float turboSpeed = 35.0f;
    public float rotationSpeed = 45.0f;

    [Header("Interfaz UI")]
    public TextMeshProUGUI textoVelocidad;
    public TextMeshProUGUI textoPuntos;
    public GameObject textoGanador;

    [Header("Puntuación")]
    public int puntos = 0;
    private int totalAnillos;
    private int anillosRecolectados = 0;

    private float currentSpeed;
    private float verticalInput;
    private bool turboActivo = false;

    void Start()
    {
        currentSpeed = speed;

        // Cuenta cuántos objetos con el Tag 'Checkpoint' existen al iniciar
        totalAnillos = GameObject.FindGameObjectsWithTag("Checkpoint").Length;
        Debug.Log("Total de anillos detectados en la escena: " + totalAnillos);

        if (textoGanador != null)
        {
            textoGanador.SetActive(false);
        }
    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space) || turboActivo)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, turboSpeed, Time.deltaTime * 4f);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, speed, Time.deltaTime * 4f);
        }

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * rotationSpeed * verticalInput * Time.deltaTime);

        if (textoVelocidad != null)
        {
            textoVelocidad.text = "Velocidad: " + Mathf.RoundToInt(currentSpeed * 10) + " km/h";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detecta solo si el objeto chocado tiene la etiqueta Checkpoint
        if (other.CompareTag("Checkpoint"))
        {
            puntos += 100;
            anillosRecolectados++;

            if (textoPuntos != null)
            {
                textoPuntos.text = "Puntos: " + puntos;
            }

            // Destruye ÚNICAMENTE el objeto del anillo que tocó la colisión
            Destroy(other.gameObject);

            // Verifica si ya cruzó todos los anillos
            if (anillosRecolectados >= totalAnillos)
            {
                GanarJuego();
            }
        }
    }

    void GanarJuego()
    {
        if (textoGanador != null)
        {
            textoGanador.SetActive(true);
        }
        Debug.Log("¡JUEGO GANADO!");
    }

    public void PresionarTurbo() { turboActivo = true; }
    public void SoltarTurbo() { turboActivo = false; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
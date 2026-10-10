using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    // Velocidad alta para simular el efecto de giro de la hélice
    [SerializeField] private float propellorSpeed = 1000.0f;

    void Update()
    {
        // Gira continuamente sobre el eje Z (hacia adelante)
        transform.Rotate(Vector3.forward * propellorSpeed * Time.deltaTime);
    }
}

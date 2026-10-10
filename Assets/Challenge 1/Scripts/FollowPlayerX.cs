using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    // Offset detrás y ligeramente arriba del avión
    public Vector3 offset = new Vector3(0, 4, -12);
    public float smoothSpeed = 6.0f;

    void LateUpdate()
    {
        if (plane == null) return;

        // Calcula la posición deseada en el espacio local del avión
        Vector3 desiredPosition = plane.transform.TransformPoint(offset);

        // Aplica un movimiento suave a la cámara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Orienta la cámara siempre hacia la nariz del avión
        transform.LookAt(plane.transform.position + plane.transform.forward * 5f);
    }
}
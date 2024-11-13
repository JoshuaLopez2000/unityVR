using UnityEngine;

public class FollowPlayerLight : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public Vector3 offset = new Vector3(0, 5, -5); // Offset de la luz respecto al jugador

    void Update()
    {
        if (player != null)
        {
            // Actualiza la posici�n de la luz seg�n la posici�n del jugador y el offset
            transform.position = player.position + player.rotation * offset;

            // Copia la rotaci�n del jugador
            transform.rotation = player.rotation;
        }
    }
}

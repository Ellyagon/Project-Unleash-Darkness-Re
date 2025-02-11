using UnityEngine;

public class BanderaCollision : MonoBehaviour
{
    // Ajusta esto en Unity si tu "jugador" tiene otra etiqueta
    public string tagJugador = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagJugador))
        {
            // Cuando el jugador toca la bandera, la desactiva
            gameObject.SetActive(false);
        }
    }
}

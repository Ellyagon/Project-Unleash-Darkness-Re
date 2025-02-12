using System.Collections;
using UnityEngine;

public class Piece : MonoBehaviour
{
    // Ajusta esto en Unity si tu "jugador" tiene otra etiqueta
    public string tagJugador = "Player";
    public GameObject piecePlaced;
    private PiecesManager piecesManager;

    private void Start()
    {
        piecesManager = FindAnyObjectByType<PiecesManager>();
        piecePlaced = GameObject.Find("Placed" + gameObject.name);
        piecePlaced.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagJugador))
        {
            transform.GetChild(0).gameObject.SetActive(false);
            piecesManager.CollectPiece(this);
            piecesManager.PiecesNumberChangedEvent();
        }
    }

    public void PlacePiece(int order, float waitTime)
    {
        StartCoroutine(PlaceInOrder(order, waitTime));
    }

    private IEnumerator PlaceInOrder(int order, float waitTime)
    {
        yield return new WaitForSeconds(order * waitTime);
        piecePlaced.transform.GetChild(0).gameObject.SetActive(true);
        piecesManager.PiecesNumberChangedEvent();
    }
}

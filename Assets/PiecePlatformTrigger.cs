using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlatformTrigger : MonoBehaviour
{
    [SerializeField] private GameObject billboard;
    private PiecesManager piecesManager;
    private bool triggered = false;

    private void Start()
    {
        piecesManager = FindAnyObjectByType<PiecesManager>();
    }

    private void Update()
    {
        if (piecesManager.CollectedPieces == 0)
            billboard.SetActive(false);
        if (!triggered) return;
        if (!Input.GetKeyDown(KeyCode.F)) return;

        piecesManager.PlacePiece();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (piecesManager.CollectedPieces > 0) billboard.SetActive(true);
        triggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        billboard.SetActive(false);
        triggered = false;
    }
}

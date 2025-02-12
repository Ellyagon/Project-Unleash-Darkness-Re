using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlatformTrigger : MonoBehaviour
{
    private PiecesManager piecesManager;
    private bool triggered = false;

    private void Start()
    {
        piecesManager = FindAnyObjectByType<PiecesManager>();
    }

    private void Update()
    {
        if (!triggered) return;
        if (!Input.GetMouseButtonDown(0)) return;

        piecesManager.PlacePiece();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        triggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        triggered = false;
    }
}

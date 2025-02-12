using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class PiecesManager : MonoBehaviour
{
    [SerializeField] private int totalPieces = 3;
    private List<Piece> collectedPieces = new();
    private int placedPieces = 0;
    public static event Action OnAllPiecesPlaced;
    public static event Action<int, string> OnPiecesNumberChanged;

    public int CollectedPieces { get { return collectedPieces.Count; } }
    public int TotalPieces { get { return totalPieces; } }

    private void Start()
    {
        OnPiecesNumberChanged?.Invoke(collectedPieces.Count, " pieces");
    }
    public void CollectPiece(Piece piece)
    {
        collectedPieces.Add(piece);
    }

    public void PlacePiece()
    {
        if (collectedPieces.Count == 0) return;

        int pieceCount = collectedPieces.Count;
        float waitTime = 0.5f;
        for (int i = 0; i < pieceCount; i++)
        {
            collectedPieces[0].PlacePiece(i, waitTime);
            collectedPieces.Remove(collectedPieces[0]);
            placedPieces++;
        }

        if (placedPieces < totalPieces) return;

        StartCoroutine(AllPiecesPlacedEvent(pieceCount, waitTime));
    }

    public void PiecesNumberChangedEvent()
    {
        OnPiecesNumberChanged?.Invoke(collectedPieces.Count, " pieces");
    }

    private IEnumerator AllPiecesPlacedEvent(int remainingPieces, float waitTime)
    {
        yield return new WaitForSeconds(remainingPieces * waitTime);
        OnAllPiecesPlaced?.Invoke();
    }
}

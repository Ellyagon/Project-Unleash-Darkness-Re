using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;

    void OnEnable()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        PiecesManager.OnPiecesNumberChanged += UpdateText;
    }

    void OnDisable()
    {
        PiecesManager.OnPiecesNumberChanged -= UpdateText;
    }

    private void UpdateText(int number, string text)
    {
        textMeshPro.text = number.ToString() + text;
    }
}

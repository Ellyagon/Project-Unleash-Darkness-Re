using UnityEngine;
using System.Collections.Generic;

public class RandomPiecesSpawner : MonoBehaviour
{
    [Tooltip("Arrastra aquí los 8 objetos que actuarán como cristales.")]
    public GameObject[] cristales;  // Debes asignar 8 elementos en el Inspector.

    [Tooltip("Cantidad de cristales que deseas activar.")]
    public int numCristalesActivar = 6;

    void Start()
    {
        // Asegúrate de que haya suficientes objetos en el array para activar los solicitados
        if (cristales.Length < numCristalesActivar)
        {
            Debug.LogError("No hay suficientes cristales en la lista para activar la cantidad deseada.");
            return;
        }

        ActivarCristalesRandom();
    }

    /// <summary>
    /// Activa aleatoriamente 'numCristalesActivar' cristales y desactiva el resto.
    /// </summary>
    private void ActivarCristalesRandom()
    {
        // Crear una lista de índices (0 a cristales.Length - 1)
        List<int> indices = new List<int>();
        for (int i = 0; i < cristales.Length; i++)
        {
            indices.Add(i);
        }

        // Barajamos la lista de índices (Fisher-Yates Shuffle sencillo)
        for (int i = 0; i < indices.Count; i++)
        {
            int randomIndex = Random.Range(i, indices.Count);
            int temp = indices[i];
            indices[i] = indices[randomIndex];
            indices[randomIndex] = temp;
        }

        // Activa las primeras 'numCristalesActivar' y desactiva el resto
        for (int i = 0; i < cristales.Length; i++)
        {
            if (i < numCristalesActivar)
            {
                cristales[indices[i]].SetActive(true);
            }
            else
            {
                cristales[indices[i]].SetActive(false);
            }
        }
    }
}

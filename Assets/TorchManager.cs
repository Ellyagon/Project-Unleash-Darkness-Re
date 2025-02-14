using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchManager : MonoBehaviour
{
    [SerializeField] private int totalTorches = 0;
    [SerializeField] private int lightedTorches;
    public static event Action OnAllTorchesFired;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            if (transform.GetChild(i).gameObject.activeInHierarchy) totalTorches++;

    }

    public void CountTorch()
    {
        lightedTorches++;
        print(totalTorches + " " + lightedTorches);
        if (lightedTorches == totalTorches)
            OnAllTorchesFired?.Invoke();
    }
}

using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchesCutscene : Cutscene
{
    private Torch[] torches;
    private CinemachineVirtualCamera virtualCamera;

    void OnEnable()
    {
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        GameObject[] torchObjects = GameObject.FindGameObjectsWithTag("Torch");
        torches = new Torch[torchObjects.Length];
        for (int i = 0; i < torchObjects.Length; i++) 
            torches[i] = torchObjects[i].GetComponent<Torch>();
        PiecesManager.OnAllPiecesPlaced += StartTorchesCutscene;
    }

    void OnDisable()
    {
        PiecesManager.OnAllPiecesPlaced -= StartTorchesCutscene;
    }

    void StartTorchesCutscene()
    {
        Debug.Log("Torches cutscene started");
        StartCoroutine(CutsceneRoutine());
    }


    private IEnumerator CutsceneRoutine()
    {
        CutsceneEvent(true);

        yield return new WaitForSeconds(1);
        virtualCamera.Priority = 11;
        float cameraWait = Camera.main.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time;
        yield return new WaitForSeconds(cameraWait + 1);

        foreach (var torch in torches)
        {
            torch.EnableTorch(true);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(1.5f);
        foreach (var torch in torches)
        {
            torch.EnableTorch(false);
            torch.SetInteractable(true);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(3);
        virtualCamera.Priority = 0;
        yield return new WaitForSeconds(cameraWait);
        CutsceneEvent(false);
    }
}

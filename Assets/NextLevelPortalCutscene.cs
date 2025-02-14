using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NextLevelPortalCutscene : Cutscene
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject bars;
    [SerializeField] private ParticleSystem particles;
    CinemachineVirtualCamera virtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        TorchManager.OnAllTorchesFired += StartCutscene;
    }

    void OnDisable()
    {
        TorchManager.OnAllTorchesFired -= StartCutscene;
    }

    private void StartCutscene()
    {
        StartCoroutine(Cutscene());
    }

    private IEnumerator Cutscene()
    {
        CutsceneEvent(true);

        yield return new WaitForSeconds(1);
        virtualCamera.Priority = 11;
        float cameraWait = Camera.main.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time;
        yield return new WaitForSeconds(cameraWait + 1);
        particles.Play();
        bars.SetActive(false);
        door.SetActive(true);
        yield return new WaitForSeconds(1);
        virtualCamera.Priority = 0;
        yield return new WaitForSeconds(cameraWait);
        CutsceneEvent(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] private bool interactable = false;
    [SerializeField] private Light light1;
    [SerializeField] private Light light2;
    [SerializeField] private ParticleSystem particle;
    private TorchManager torchManager;
    private bool triggered;

    private void Start()
    {
        torchManager = transform.parent.gameObject.GetComponent<TorchManager>();
        SetInteractable(interactable);
    }

    private void Update()
    {
        if (!triggered) return;
        if (!Input.GetMouseButtonDown(0)) return;

        LightTorch();
    }

    public void EnableTorch(bool enable)
    {
        light1.enabled = enable; light2.enabled = enable;
        if (enable) particle.Play();
        else
        {
            particle.Stop();
            Invoke(nameof(ClearParticles), 3);
        }
    }

    private void ClearParticles()
    {
        particle.Clear();
    }


    public void SetInteractable(bool interactable)
    {
        this.interactable = interactable;
        GetComponent<Collider>().enabled = interactable;
    }

    public void LightTorch()
    {
        EnableTorch(true);
        torchManager.CountTorch();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    private Fade fade;

    private void Start()
    {
        fade = FindAnyObjectByType<Fade>();
    }

    private void OnTriggerEnter(Collider other)
    {
        fade.PlayFade(Fade.FadeMode.In);
        Invoke(nameof(LoadNextScene), 2f);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

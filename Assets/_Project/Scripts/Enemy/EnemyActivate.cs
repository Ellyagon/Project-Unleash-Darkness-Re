using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivate : MonoBehaviour
{
    public GameObject monster;
    public GameObject Player;
    public LightMeter LightMeterScript;
    public float lightTime;
    public Input_Handler _Handler;
    public bool EnemyOn = false;

    public AudioClip EnemySound;
    private AudioSource audioSource;
    private bool isEnemySoundPlaying = false;
    private bool monsterActivated = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        monster.SetActive(false);   
        lightTime = 0;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterActivated) return;
        if (_Handler._lanternOn) 
        {
            lightTime += Time.deltaTime;
            lightTime = Mathf.Min(15, lightTime);
        }
        else 
        {
            lightTime -= Time.deltaTime;
            lightTime = Mathf.Max(0, lightTime);
        }
        Monster();
    }

    public void Monster()
    {
        if (lightTime >= 11 && !isEnemySoundPlaying )
        {
            SetActiveMonster();
            ActivateMonster();

        } else if (lightTime <= 10)
        {
            monster.SetActive(false);
            EnemyOn = false;
            isEnemySoundPlaying = false;
        }
    }

    public void ActivateMonster()
    {
        EnemyOn = true;
        audioSource.Play();
        monsterActivated = true;
        isEnemySoundPlaying = true;
    }

    public void SetActiveMonster()
    {
        monster.SetActive(true);
    }
}

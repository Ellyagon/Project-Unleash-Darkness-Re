using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAppear : MonoBehaviour
{
    private EnemyActivate enemyActivate;
    private Keys keys;

    // Start is called before the first frame update
    void Start()
    {
        enemyActivate = GetComponent<EnemyActivate>();
        keys = FindAnyObjectByType<Keys>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keys.keyCount == 0) return;

        enemyActivate.SetActiveMonster();
        Invoke(nameof(ActivateMonster), 1);
    }


    private void ActivateMonster()
    {
        enemyActivate.ActivateMonster();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;
    public EnemyActivate yep;
    private NavMeshAgent agent;
    [SerializeField] private Animator animator;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void OnEnable()
    {
        Cutscene.OnCutscene += SetOnCutscene;
    }

    private void OnDisable()
    {
        Cutscene.OnCutscene -= SetOnCutscene;
    }

    bool onCutscene = false;
    private void SetOnCutscene(bool isPlaying)
    {
        onCutscene = isPlaying;
        if (onCutscene) agent.ResetPath();
        animator.SetBool("IsStopped", isPlaying);
    }

    // Update is called once per frame
    void Update()
    {
        if (onCutscene) return;

        if (yep.EnemyOn) agent.SetDestination(target.position);
        else transform.Translate(0, 0, 0);

    }
}

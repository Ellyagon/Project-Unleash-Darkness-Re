using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float rotationDuration = 0.2f;
    public LookDirection lookDirection;
    private Vector2 input;
    private Rigidbody rb;
    private float currentVelocity;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        lookDirection.enabled = false;
        input = Vector2.zero;
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
    }

    private void LateUpdate()
    {
        if (onCutscene) return;

        RotatePlayerSmooth();
    }

    private void FixedUpdate()
    {
        if (onCutscene)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        Vector3 velocity = new(input.x, rb.velocity.y, input.y);
        rb.velocity = velocity;
    }

    public void UpdateInput(Vector2 input)
    {
        this.input = input.normalized * _speed;
    }

    private void RotatePlayerSmooth()
    {
        if (input.magnitude < 0.01) return;
        float current = transform.eulerAngles.y;
        float target = -(Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg + 90) + 180;
        float angle = Mathf.SmoothDampAngle(current, target, ref currentVelocity, rotationDuration);

        transform.eulerAngles = new(transform.eulerAngles.x, angle, transform.eulerAngles.z);
    }
}

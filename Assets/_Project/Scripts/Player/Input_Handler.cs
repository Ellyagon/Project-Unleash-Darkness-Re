using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;


public class Input_Handler : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector2> _onMove = new();
    [SerializeField] public GameObject _lantern;
    public Rigidbody rb;
    public Animator animator;
    public bool playerIsOnGround = true;
    public bool _lanternOn = false;
    public Transform lanternPartSpawn;
    public GameObject _lanternParticle;

  
    public AudioClip LightSoundOn;
    public AudioClip LightSoundOff;
    private AudioSource audioSource;
   

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        _lantern.SetActive(false);
        animator = GetComponent<Animator>();

    }


    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        _onMove?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        if (Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0)
        {
            animator.SetTrigger("Run");
            

        }
        if (Input.GetKeyDown("space") && playerIsOnGround)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            playerIsOnGround = false;
            animator.SetTrigger("Jump");

        } else if (Input.GetKeyDown("e") && (_lanternOn == false))
        {
            _lanternOn = true;
            audioSource.PlayOneShot(LightSoundOn);
            _lantern.SetActive(true);
            Instantiate(_lanternParticle, lanternPartSpawn);

        }
        else if (Input.GetKeyDown("e") && (_lanternOn == true))
        {
            _lantern.SetActive(false);
            _lanternOn = false;
            audioSource.PlayOneShot(LightSoundOff);
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerIsOnGround = true;
       
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

   
    public bool _isInRange;
    public KeyCode _interactKey;
    public UnityEvent _interactAction;


    void Update()
    {
        if (_isInRange)
        {
            if (Input.GetKeyDown(_interactKey))
            {
                _interactAction.Invoke();
                /* 
                if (_needsToDissapear)
                {
                  
                    Destroy(_gameObj);
                    
                }
                */
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":

                _isInRange = true;
                //other.gameObject.GetComponent<PlayerManager>().NotifyPlayer();
                //Debug.Log("Player is in range");

                break;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Player":

                _isInRange = false;
               // other.gameObject.GetComponent<PlayerManager>().DeNotifyPlayer();
                //Debug.Log("Player is out of range");

                break;



        }
    }

}

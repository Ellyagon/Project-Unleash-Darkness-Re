using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private void Start()
    {
        transform.eulerAngles = new(transform.eulerAngles.x, 0, transform.eulerAngles.z);
    }

    void Update()
    {

    }
}

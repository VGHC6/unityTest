using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    float horizentalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, horizentalInput * rotationSpeed*Time.deltaTime);
    }
}

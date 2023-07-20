using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    public Vector3 rotateVector;




    void Update()
    {
        transform.Rotate(rotateVector * Time.deltaTime);
        
    }
}

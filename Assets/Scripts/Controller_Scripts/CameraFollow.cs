using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform playerParent;

    float offsetZ;

    float offsetY;




    private void Start()
    {
        playerParent = FindObjectOfType<PlayerController>().transform;

        offsetZ = playerParent.position.z - transform.position.z;
        offsetY = playerParent.position.y - transform.position.y;

    }



    private void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, playerParent.position.x, .2f), playerParent.position.y - offsetY, playerParent.position.z - offsetZ);
        
    }

}

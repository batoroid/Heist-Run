using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMoveController : MonoBehaviour
{
    public bool isMove;

    public float speed;

    void Update()
    {
        if (isMove)
            transform.Translate(0, 0, speed * Time.deltaTime, Space.World);
        
    }
}

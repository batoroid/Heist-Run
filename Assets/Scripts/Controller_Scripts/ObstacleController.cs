using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public static ObstacleController instance;

    public bool isTrigger;

    private void Awake()
    {
        instance = this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    public float horizontalSpeed;
    
    public float verticalSpeed;

    public float edge;

    public float fireRate;

    public float fireRange;

    public float defaultRate;
    public float defaultRange;

}

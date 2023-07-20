using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public List<GameObject> projectiles;




    private void OnEnable()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            projectiles[i].SetActive(false);

        }

        projectiles[GameObject.FindObjectOfType<PlayerController>().level].SetActive(true);
    }

}

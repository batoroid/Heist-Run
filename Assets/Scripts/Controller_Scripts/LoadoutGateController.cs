using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutGateController : MonoBehaviour
{
    public Transform loadouts;

    public GameObject pipe;

    public int maxCost, unlockedLoadout;

    int collectedMoney, loadoutCount;




    void Start()
    {
        loadoutCount = loadouts.childCount;

    }



    void CollectMoney()
    {
        collectedMoney++;

        if (collectedMoney <= maxCost)
        {
            unlockedLoadout = Mathf.FloorToInt(collectedMoney / (maxCost / (loadoutCount - 1)));

            for (int i = 0; i < loadoutCount; i++)
            {
                loadouts.GetChild(i).gameObject.SetActive(false);

            }

            loadouts.GetChild(unlockedLoadout).gameObject.SetActive(true);

        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            Destroy(other.gameObject);

            CollectMoney();

        }

    }

}

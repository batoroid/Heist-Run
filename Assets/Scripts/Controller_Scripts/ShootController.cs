using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public static ShootController instance;

    public List<GameObject> BulletList;

    public GameObject bulletPoint;

    public PlayerData playerData;

    public Transform bulletPool;

    public Coroutine coro;




    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }


    public void StartShooting()
    {
        StartCoroutine("Bulletcoroutine");


    }

   


    IEnumerator Bulletcoroutine()
    {

       
        yield return new WaitForSeconds(playerData.fireRate);

        BulletList[0].gameObject.SetActive(true);

        //   BulletList[0].GetComponent<BulletController>().enabled = true;

        BulletList[0].transform.position = bulletPoint.transform.position;

        BulletList[0].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 20);

        BulletList.RemoveAt(0);

      



       
        StartCoroutine(Bulletcoroutine());

    }

}

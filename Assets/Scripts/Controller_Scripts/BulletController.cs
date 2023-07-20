using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public static BulletController instance;

    public PlayerData playerData;

    public bool moved;




    private void Awake()
    {
        instance = this;
    }



    public IEnumerator BulletRateEnum()
    {
        yield return new WaitForSeconds(playerData.fireRange);

        gameObject.transform.position = ShootController.instance.bulletPool.transform.position;

        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        ShootController.instance.BulletList.Add(gameObject);

        // gameObject.GetComponent<BulletController>().enabled = false;

        gameObject.SetActive(false);

    }



    private void OnEnable()
    {
        StartCoroutine(BulletRateEnum());

    }



    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Loadout"))
        {
            gameObject.transform.position = ShootController.instance.bulletPool.transform.position;

            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            ShootController.instance.BulletList.Add(gameObject);

            gameObject.SetActive(false);

        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obs"))
        {
            gameObject.transform.position = ShootController.instance.bulletPool.transform.position;

            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            ShootController.instance.BulletList.Add(gameObject);

            gameObject.SetActive(false);


        }
    }


}

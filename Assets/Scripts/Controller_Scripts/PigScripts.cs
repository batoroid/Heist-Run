using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigScripts : MonoBehaviour
{
    public GameObject rickGrimes;

    public GameObject pig;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }


    IEnumerator Piecesnum()
    {
        yield return new WaitForSeconds(1);

        pig.transform.gameObject.SetActive(true);

        rickGrimes.transform.gameObject.SetActive(false);



    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Floor"))
        {

            pig.transform.gameObject.SetActive(true);

            rickGrimes.transform.gameObject.SetActive(false);


        }

    }




}

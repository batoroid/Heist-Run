using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;


public class EndGameObs : MonoBehaviour
{

    public int obstackleHealt;

    public TextMeshPro obsHealtText;

    public GameObject rickGrimes;

    public GameObject pigPieces;

    public static EndGameObs instance;





    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.transform.DOScale(new Vector3(2.3f,2.4f,1),0.1f).OnComplete(() =>

            gameObject.transform.DOScale(new Vector3(2.3f, 2, 1), 0.1f));

            obstackleHealt -= 1;

            obsHealtText.text = obstackleHealt.ToString();

            if(obstackleHealt < 0)
            {
               


                gameObject.transform.DOScaleX(0.01f, 0.1f).OnComplete(() =>
  
                Destroy(gameObject));



              
                

            }

        }


    }

  

}

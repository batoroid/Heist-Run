using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyCollectorController : MonoBehaviour
{
    public Transform releasePoint;

    public Transform vacuum;

    public Vector3 vacuumStartPosition;




    private void Start()
    {
        vacuumStartPosition = vacuum.position;

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            other.GetComponent<MoneyMoveController>().isMove = false;

            other.transform.position = releasePoint.position;

            DOTween.Kill("Vacuum");

            vacuum.position = vacuumStartPosition;

            //vacuum.DOPunchPosition(new Vector3(0, -1.65f, 0), .15f);
            vacuum.DOPunchPosition(Vector3.up * -1.5f, .15f).SetId("Vacuum");

        }

    }

}

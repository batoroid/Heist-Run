using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OpeningOut : MonoBehaviour
{
    public CanvasGroup logoCanvas;
    



    void Start()
    {
        StartCoroutine(Fade());

    }

    

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(.25f);

        logoCanvas.DOFade(0, .5f);


    }

}

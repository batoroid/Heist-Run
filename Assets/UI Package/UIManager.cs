using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public CanvasGroup startCanvas, gameCanvas, winCanvas, loseCanvas;

    public Text levelCountText, moneyText;

    public Vector3 cameraPos, cameraRot;

    public Transform cam;




    void Start()
    {
        instance = this;

        levelCountText.text ="LEVEL "+(PlayerPrefs.GetInt("Level") + 1).ToString();

        Application.targetFrameRate = 60;
        
    }



    public void StartButton()
    {
        SetCanvasGroupValue(startCanvas, 0, false);

        SetCanvasGroupValue(gameCanvas,1, true);

        PlayerController.instance.ActivatePlayer();

        moneyText.text = "$" + PlayerPrefs.GetFloat("Money").ToString("0");

        //cam.DOLocalMove(cameraPos, 0.75f);
        //cam.DOLocalRotate(cameraRot, 0.75f);

        //DragTextEffect.instance.isStarted = true;

    }



    public IEnumerator LoseMethod()
    {
        // Losing Actions
        yield return new WaitForSeconds(1f);

        SetCanvasGroupValue(gameCanvas, 0, false);

        SetCanvasGroupValue(loseCanvas, 1, true);

        CloseSomePanels(winCanvas.gameObject);

     }



    public void RestarGame()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }



    public void WinStart(int total)
    {
        StartCoroutine(WinUIMethod(total));

    }



    private IEnumerator WinUIMethod(int totalCoin)
    {
        yield return new WaitForSeconds(2f);

        //Winning Actions

        //moneyText.text = totalCoin.ToString();

        SetCanvasGroupValue(gameCanvas, 0, false);

        SetCanvasGroupValue(winCanvas, 1,true);

        CloseSomePanels(loseCanvas.gameObject);
       
    }



    public void WinButton()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }



    private void SetCanvasGroupValue(CanvasGroup _group, float _value,bool _boolean)
    {
        _group.DOFade(_value, 1f);

        _group.gameObject.SetActive(_boolean);

        _group.interactable = _boolean;

    }



    private void CloseSomePanels(GameObject _panel)
    {
        startCanvas.gameObject.SetActive(false);

        gameCanvas.gameObject.SetActive(false);

        _panel.gameObject.SetActive(false);

    }
}

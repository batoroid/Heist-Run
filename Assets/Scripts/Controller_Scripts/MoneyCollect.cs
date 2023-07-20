using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class MoneyCollect : MonoBehaviour
{
    public Image moneyImage;

    public RectTransform uiTransform;

    public GameObject canvas;

    public RectTransform moneyTransform;

    public Text moneyText;

    public float money;




    private void Start()
    {
        money = PlayerPrefs.GetFloat("Money");

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            

            other.gameObject.layer = 12;

            other.transform.position = new Vector3(-5.25f, 1, other.transform.position.z + 9f);

            other.GetComponent<MoneyMoveController>().isMove = true;

        }
        if (other.CompareTag("Money2")) {
            other.gameObject.transform.DOMoveY(other.gameObject.transform.position.y + 3, 0.3f).SetEase(Ease.Linear).OnComplete(() =>
              {
                  Destroy(other.gameObject);

                  var obj = Instantiate(moneyImage, uiTransform.position, Quaternion.identity);

                  obj.transform.SetParent(canvas.transform, true);

                  obj.GetComponent<RectTransform>().DOAnchorPos(moneyTransform.anchoredPosition, 0.5f).OnComplete(() =>
                   {
                       money += 50;

                       moneyText.text = "$" + money.ToString("0");

                       Destroy(obj.gameObject);

                   });

              });

        }

    }






    private void OnDisable()
    {
        Debug.Log("Oyun sonuna al");
        PlayerPrefs.SetFloat("Money", money);

    }

}

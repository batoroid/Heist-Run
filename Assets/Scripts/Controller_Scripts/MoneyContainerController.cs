using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MoneyContainerController : MonoBehaviour
{
    int health, pieceCount;

    float blend = 0;

    [Header("Shared Variables")]
    public int defaultHealth;
    
    public int prizeMoney;

    public TextMeshPro healthText;

    [Header("Breakable Variables")]
    public bool isPieced;

    public GameObject bodyParent, pieceParent, moneyPrefab;

    public List<Rigidbody> pieces;

    [Header("Blend Shape Variables")]
    public bool isBlendShape;

    new public SkinnedMeshRenderer renderer;




    void Start()
    {
        health = defaultHealth;

        healthText.text = health.ToString();

        if (isPieced)
            pieceCount = pieces.Count;

    }



    void TakeDamage()
    {
        ReduceHealth(null);

        if (health > 0)
        {
            if (isPieced)
            {
                for (int i = 0; i < pieceCount/defaultHealth; i++)
                {
                    Break(pieces[0]);

                    pieces.RemoveAt(0);

                }

            }

            else if (isBlendShape)
            {
                Blend();

            }

        }

        else
        {
            healthText.text = "";

            GetComponent<Collider>().enabled = false;

            if (isPieced)
            {
                foreach (Rigidbody _piece in pieces)
                {
                    Break(_piece);                    

                }                

            }

            else if (isBlendShape)
            {
                Blend();

                transform.DORotate(Vector3.right * 90, .75f).SetEase(Ease.OutBounce).OnComplete(() => transform.DOMoveY(-3, .5f));

            }

            for (int i = 0; i < prizeMoney; i++)
            {
                GameObject _prize = Instantiate(moneyPrefab, transform.position, Quaternion.identity);

                _prize.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(Random.Range(-2, 2.6f), Random.Range(5f, 11), Random.Range(-1, 2.6f)), _prize.transform.position, ForceMode.Impulse);

            }

        }

    }



    void ReduceHealth(Transform _punchable)
    {
        health--;

        healthText.text = health.ToString();

        GameObject _money = Instantiate(moneyPrefab, transform.position, Quaternion.identity);

        _money.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(Random.Range(-2, 2.6f), Random.Range(10f, 16), Random.Range(-1, 2.6f)), _money.transform.position, ForceMode.Impulse);

        DOTween.Kill(transform);

        healthText.rectTransform.localScale = Vector3.one;

        healthText.rectTransform.DOPunchScale(Vector3.one * .45f, .15f).SetId(transform);

        //DOTween.Kill(_punchable.transform);

        //_punchable.localScale = Vector3.one;

        //_punchable.DOPunchScale(Vector3.one * .45f, .15f).SetId(_punchable.transform);

    }



    void Break(Rigidbody _piece)
    {
        _piece.isKinematic = false;

        _piece.transform.DOScale(Vector3.zero, 4f);

        Destroy(_piece.gameObject, 4.15f);

    }



    void Blend()
    {
        renderer.SetBlendShapeWeight(0, 100 - ((float)health / (float)defaultHealth * 100));

        //DOTween.To(() => blend, x => blend = x, health / defaultHealth * 100, .15f).OnUpdate(() =>
        //{
        //    renderer.SetBlendShapeWeight(0, blend);

        //});

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (isPieced)
            {
                if (health == defaultHealth)
                {
                    bodyParent.SetActive(false);

                    pieceParent.SetActive(true);

                }

            }

            TakeDamage();

        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public Transform bulletInsTransform;

    public GameObject bulletins;

    public GameObject m_Range;

    public static EnemyController instance;

    public List<GameObject> bullets = new List<GameObject>();

    public SkinnedMeshRenderer enemyMesh;

    public Color redColor;

    public GameObject keyPrefab;

    public int health;

    public TextMeshPro healthText;

    public Animator anim;


    private void Awake()
    {
        instance = this;
    }




    void Start()
    {
        healthText.text = health.ToString();

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;

            enemyMesh.material.DOColor(Color.white, .05f).SetEase(Ease.Linear).OnComplete(() => enemyMesh.material.DOColor(redColor, .05f));

            if (health > 0)
                healthText.text = health.ToString();

            else
            {
                healthText.text = "";

                anim.SetTrigger("Die");

                GetComponent<Collider>().enabled = false;

                GameObject _key = Instantiate(keyPrefab, transform.position, Quaternion.identity);

                _key.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(Random.Range(-2, 2.6f), Random.Range(5f, 11), Random.Range(-1, 2.6f)), _key.transform.position, ForceMode.Impulse);

            }

        }

    }


    IEnumerator Bulletins()
    {
        yield return new WaitForSeconds(.5f);

        var bullet = Instantiate(bulletins, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 2), Quaternion.identity);

        bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -15);

        yield return new WaitForSeconds(.5f);

        Destroy(bullet);

        StartCoroutine(Bulletins());

    }



    public void BulletInsCoro()
    {
        StartCoroutine(Bulletins());

    }

}

       










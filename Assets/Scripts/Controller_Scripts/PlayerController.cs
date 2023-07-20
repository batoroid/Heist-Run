using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    ShootController bulletController;

    public PlayerData playerData;

    public Animator anim;

    public Transform weapons;

    public GameObject transformationParticle;

    public static PlayerController instance;

    public List<string> animaTriggers;

    public IntEvent onSafeReached;

    public IntEvent onWeaponChanged;

    float startX, movedX, transformX;

    int collectedKey;

    public int level;

    bool isStart = false;

    public bool isObs;




    private void Awake()
    {
        instance = this;

        playerData.fireRange = playerData.defaultRange;
        playerData.fireRate = playerData.defaultRate;
    }



    void Start()
    {
        bulletController = ShootController.instance;
    }



    void Update()
    {
        if (isStart)
        {
            VerticalMovement();

            HorizontalMovement();

        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
               isObs = true;

               StartCoroutine(ObsNum());


               collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
   
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            DecideGate(other);

        }

        else if (other.CompareTag("Loadout"))
        {
            if (level <= other.GetComponent<LoadoutGateController>().unlockedLoadout)
            {
                StartCoroutine(ChangeWeapon(other));

            }

            Destroy(other.GetComponent<LoadoutGateController>().pipe);

            Destroy(other.gameObject);

        }

        else if (other.CompareTag("Key"))
        {
            collectedKey++;

            Destroy(other.gameObject);

        }

        else if (other.CompareTag("Safe"))
        {
            onSafeReached.Raise(collectedKey);

        }

        else if (other.CompareTag("Finish"))
        {
            UIManager.instance.WinStart(0);

        }

    }



    IEnumerator ChangeWeapon(Collider other)
    {
        level = other.GetComponent<LoadoutGateController>().unlockedLoadout;

        anim.SetTrigger(animaTriggers[level]);

        for (int i = 0; i < weapons.childCount; i++)
        {
            weapons.GetChild(i).gameObject.SetActive(false);

        }

        weapons.GetChild(level).gameObject.SetActive(true);

        transformationParticle.SetActive(true);

        yield return new WaitForSeconds(.75f);

        transformationParticle.SetActive(false);

    }



    void DecideGate(Collider other)
    {
        GateController _gate = other.GetComponent<GateController>();

        switch (_gate.gateType)
        {
            case GateController.GateType.fireRate:
                Debug.Log("Ayar cek");
                playerData.fireRate -= _gate.value / 25;

                if (playerData.fireRate < .11f)
                    playerData.fireRate = .10f;

                break;

            case GateController.GateType.fireRange:

                playerData.fireRange += _gate.value;

                break;

            case GateController.GateType.transformation:
                break;

            default:
                break;
        }

    }



    #region MOVEMENT
    private void VerticalMovement()
    {
        transform.position += playerData.verticalSpeed * Time.deltaTime * Vector3.forward;

    }



    private void HorizontalMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startX = touch.position.x;

                movedX = startX;

            }

            if (touch.phase == TouchPhase.Moved)
            {
                movedX = touch.position.x;

                transformX = movedX - startX;

                if (transformX != 0)
                {
                    Vector3 transformVector = new Vector2(transformX, 0);

                    transform.position += playerData.horizontalSpeed * Time.deltaTime * transformVector;

                }
            }

            startX = movedX;

        }

        if (Mathf.Abs(transform.position.x) > playerData.edge)
        {
            transform.position = new Vector3(Mathf.Sign(transform.position.x) * playerData.edge, transform.position.y, transform.position.z);

        }

    }



    public void ActivatePlayer()
    {
        isStart = true;

        bulletController.StartShooting();

        anim.SetTrigger("Run");

        anim.SetTrigger(animaTriggers[level]);



    }

    public void DeactivatePlayer()
    {
        isStart = false;

      




    }

    public IEnumerator ObsNum()
    {
      //  DeactivatePlayer();

        gameObject.transform.DOMoveZ(gameObject.transform.position.z - 3, 0.2f);

        yield return new WaitForSeconds(0.2f);

    //    ActivatePlayer();

    }

    #endregion

}

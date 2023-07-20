using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MiniGameController : MonoBehaviour
{
    public List<Transform> walls;

    public int key;

    public Transform safe, spawnPoint, prizeParent;

    public GameObject keyPrefab;

    int keyCount, collectedKey;

    public Animator padlockAnimator, safeAnimator;

    public TextMeshPro keyText;




    private void Start()
    {
        collectedKey = key;

        keyText.text = collectedKey.ToString();
        
    }



    public IEnumerator SafeActions()
    {
        for (int i = 0; i < keyCount; i++)
        {
            GameObject _key = Instantiate(keyPrefab, spawnPoint.position, Quaternion.identity);

            _key.transform.DOLookAt(padlockAnimator.transform.position, .25f);

            _key.transform.DOMove(padlockAnimator.transform.position, .35f).SetEase(Ease.Linear).OnComplete(() => 
            {
                Destroy(_key);

                collectedKey--;

                keyText.text = collectedKey.ToString();

            });

            yield return new WaitForSeconds(.25f);

        }

        if (keyCount >= key)
        {
            padlockAnimator.SetTrigger("Unlock");

            walls[0].DOMoveX(-10, .5f);

            walls[1].DOMoveX(10, .5f);

            yield return new WaitForSeconds(.55f);

            safeAnimator.SetTrigger("Unlock");

            yield return new WaitForSeconds(.75f);

            safe.DOMoveY(-5, .85f);

        }

        else
        {
            walls[0].DOMoveY(-5, .5f);

            walls[1].DOMoveY(-5, .5f);

            safe.DOMoveY(-5, .5f);

            Destroy(prizeParent.gameObject);

            padlockAnimator.transform.DOMoveY(-5, .5f);

        }
        
    }

    

    public void OnSafeReached(int _key)
    {
        keyCount = _key;

        StartCoroutine(SafeActions());

    }

}

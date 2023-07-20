using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningIn : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ChangeScene());
    }



    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(1);
        
    }
}

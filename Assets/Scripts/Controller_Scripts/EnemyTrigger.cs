using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public bool isTrigger;

    public GameObject range;

    public Animator anim;

    public Material redMaterial;

    public MeshRenderer warningMesh;





    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnemyController.instance.BulletInsCoro();

            anim.SetTrigger("Shoot");

            warningMesh.material = redMaterial;


        }

    }



    public IEnumerator RangeCoro()
    {
        yield return new WaitForSeconds(0.05f);

        range.transform.rotation = new Quaternion(0, transform.position.y + 0.5f, 0, 0);

        StartCoroutine(RangeCoro());

    }

}

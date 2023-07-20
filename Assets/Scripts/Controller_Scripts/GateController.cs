using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GateController : MonoBehaviour
{
    public enum GateType
    {
        fireRate,
        fireRange,
        transformation

    }

    public GateType gateType;

    public float value;

    public float addition;

    public TextMeshPro typeText, valueText, additionText;

    public List<MeshRenderer> gateMeshes;

    public List<GameObject> gateParticles;

    public Material greenMaterial, redMaterial;

    public Transform valueTextTransform;




    void Start()
    {
        InitializeGate();

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            value += addition;

            InitializeGate();

            DOTween.Kill("ValuePunch");

            valueTextTransform.localScale = Vector3.one;

            transform.DOPunchScale(Vector3.one * .075f, .15f).SetId("ValuePunch");
            //valueTextTransform.DOPunchScale(Vector3.one * .75f, .2f).SetId("ValuePunch");

        }

    }



    void InitializeGate()
    {
        switch (gateType)
        {
            case GateType.fireRate:
                typeText.text = "Fire Rate";
                break;

            case GateType.fireRange:
                typeText.text = "Fire Range";
                break;

            case GateType.transformation:
                typeText.text = "Upgrade";
                break;

            default:
                break;
        }

        WriteText();

        SetColor();

    }



    void SetColor()
    {
        if (value >= 0)
        {
            for (int i = 0; i < gateMeshes.Count; i++)
                gateMeshes[i].material = greenMaterial;

            gateParticles[0].SetActive(true);

            gateParticles[1].SetActive(false);

        }

        else
        {
            for (int i = 0; i < gateMeshes.Count; i++)
                gateMeshes[i].material = redMaterial;

            gateParticles[0].SetActive(false);

            gateParticles[1].SetActive(true);

        }
            
    }



    void WriteText()
    {
        valueText.text = value.ToString("0.00");

        additionText.text = addition.ToString();

    }

}

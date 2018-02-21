using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]

public class Lunar : MonoBehaviour
{
    private MeshRenderer    meshRenderer;
    private Collider        lunarCollider;
    private Rigidbody       lunarRigidbody;

    private List<GameObject> lightsList = new List<GameObject>();

    void Start()
    {
        lunarCollider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();

        lunarRigidbody = GetComponent<Rigidbody>();
        
        lunarRigidbody.useGravity = false;
        lunarRigidbody.isKinematic = true;
        
        tag = "Lunar";
    }

    void Update()
    {
        if (lightsList.Count > 0)
        {
            meshRenderer.enabled = false;
            lunarCollider.isTrigger = true;
        }
        else
        {
            meshRenderer.enabled = true;
            lunarCollider.isTrigger = false;
        }

        CleanupLightsList();
    } // End void Update ()

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Light" &&
            !lightsList.Contains(other.gameObject))
        {
            lightsList.Add(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Light" &&
            !lightsList.Contains(other.gameObject))
        {
            lightsList.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Light")
        {
            lightsList.Remove(other.gameObject);
        }
    }

    private void CleanupLightsList()
    {
        // Check for stray lights
        for (int i = 0; i < lightsList.Count; ++i)
        {
            if (!lightsList[i].activeInHierarchy ||
                lightsList[i] == null ||
                !lightsList[i].GetComponent<CapsuleCollider>().enabled)
            {
                lightsList.Remove(lightsList[i]);
            }
        }
    }
}

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requirement(s)
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
        // Get the necessary references 
        lunarCollider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();

        lunarRigidbody = GetComponent<Rigidbody>();

        // Fix the rigidbody settings
        lunarRigidbody.useGravity = false;
        lunarRigidbody.isKinematic = true;

        // Fix tag
        tag = "Lunar";
    } // End void Start ()

    void Update()
    {
        // This is a 'Lunar' object
        // Enable it only if it is unlit
        if (lightsList.Count > 0)
        {
            meshRenderer.enabled = false;
            lunarCollider.isTrigger = true;
        } // End else (lightsList.Count > 0)
        else
        {
            meshRenderer.enabled = true;
            lunarCollider.isTrigger = false;
        } // End else (lightsList.Count > 0)

        CleanupLightsList();
    } // End void Update ()

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Light" &&
            !lightsList.Contains(other.gameObject))
        {
            lightsList.Add(other.gameObject);
        } // End if (other.tag == "Light")
    } // End void OnTriggerEnter(Collider other)

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Light" &&
            !lightsList.Contains(other.gameObject))
        {
            lightsList.Add(other.gameObject);
        } // End if (other.tag == "Light")
    } // End void OnTriggerStay(Collider other)

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Light")
        {
            lightsList.Remove(other.gameObject);
        } // End if (other.tag == "Light")
    } // End void OnTriggerExit

    private void CleanupLightsList()
    {
        // Check for stray lights
        for (int i = 0; i < lightsList.Count; ++i)
        {
            // If a light in the list is no longer available
            if (!lightsList[i].activeInHierarchy ||
                lightsList[i] == null ||
                !lightsList[i].GetComponent<CapsuleCollider>().enabled)
            {
                // Remove that item from the list
                lightsList.Remove(lightsList[i]);
            } // End if (!go.activeInHierarchy || ..
        } // End foreach(GameObject go in lightsList)
    } // End private void CleanupLightsList()
} // End public class Lunar

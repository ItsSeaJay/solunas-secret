using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTriggerEnter : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad, collisionTag;

    private Collider warpCollider;

    void Start()
    {
        Debug.Assert(sceneToLoad != null, "Scene Warper " + name + GetInstanceID().ToString() + " must have a specified scene");

        warpCollider = GetComponent<Collider>();

        Debug.Assert(warpCollider.isTrigger, "Scene Warper " + name + GetInstanceID().ToString() + " is not a trigger.");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == collisionTag)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

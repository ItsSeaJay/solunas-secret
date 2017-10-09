
/******************************************************************************
* Product:     Soluna's Secret
* Script:      SceneWarper
* Description: Warps the player to a different scene when contact is made.
* Author(s):   Callum John
* Date:        10/9/2017 5:31:09 PM
******************************************************************************/

// Libraries
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
    } // End void Start ()

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == collisionTag)
        {
            SceneManager.LoadScene(sceneToLoad);
        } // End if (other.tag == "Player")
    } // End void OnTriggerEnter(Collider other)
} // End public class SceneWarper : MonoBehaviour

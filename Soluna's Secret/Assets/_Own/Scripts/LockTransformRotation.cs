
/******************************************************************************
* Product:     Soluna's Secret
* Script:      LockTransformRotation
* Description: Prevents an object from rotating in the three axes
* Author(s):   Callum John
* Date:        9/12/2017 3:47:25 PM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTransformRotation : MonoBehaviour
{
    private Quaternion startingRotation;

    void Start ()
    {
        startingRotation = transform.rotation;
    }

    void LateUpdate ()
	{
        transform.rotation = startingRotation;
    } // End void Update ()
} // End public class LockTransformRotation : MonoBehaviour

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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
	void Update ()
	{
        // Always face the direction of the main camera
        transform.forward = -Camera.main.transform.forward;
	}
}

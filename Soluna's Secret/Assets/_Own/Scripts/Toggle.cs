
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Toggle
* Description: N/a
* Author(s):   Callum John
* Date:        9/13/2017 8:24:12 AM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requirement(s)
[RequireComponent(typeof(Animator))]

public class Toggle : MonoBehaviour
{
    private Animator animator;

    private bool isOn = true;

	void Start ()
	{
        animator = GetComponent<Animator>();
	} // End void Start ()

	void Update ()
	{
		
	} // End void Update ()
} // End public class Toggle : MonoBehaviour

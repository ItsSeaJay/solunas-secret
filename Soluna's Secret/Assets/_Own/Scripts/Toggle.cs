
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Toggle
* Description: N/a
* Author(s):   Callum John
* Date:        9/22/2017 8:19:31 AM
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

    private bool isActive = false;

	void Start ()
	{
        animator = GetComponent<Animator>();	
	} // End void Start ()

    public void ToggleActivation()
    {
        isActive = !isActive;

        if (isActive)
        {
            animator.Play("Deactivate");
        } // End
        else
        {
            animator.Play("Activate");
        } // End else (isActive)
    } // End public void ToggleActivation()

    // Accessor / Mutator
    public bool IsActive
    {
        get
        {
            return isActive;
        } // End get
    } // End public bool IsActive
} // End public class Toggle : MonoBehaviour

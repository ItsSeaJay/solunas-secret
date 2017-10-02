
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Door
* Description: N/a
* Author(s):   Callum John
* Date:        9/21/2017 3:20:25 PM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

// Requirement(s)
[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Animator))]

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool locked = false;
    private bool open = false;

    private Animator animator;

	void Start ()
	{
        animator = GetComponent<Animator>();
	} // End void Start ()

	void Update ()
	{
		
	} // End void Update ()

    public void Move ()
    {
        if (!locked)
        {
            toggle.ToggleActivation();
        } // End if (!locked)
    } // End public void Toggle ()
} // End public class Door : MonoBehaviour

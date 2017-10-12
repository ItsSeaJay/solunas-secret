
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Toggle
* Description: An interactable object that can be turned on and off.
*              Used mainly for things like switches, crystals and pressure plates.
* Author(s):   Callum John
* Date:        10/10/2017 2:09:32 PM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requirement(s)
[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Animator))]

public class Toggle : MonoBehaviour 
{
    [SerializeField]
    private bool isOn = false;
    [SerializeField]
    private float transitionTime = 1.0f;

    private Interactable interactable;
    private Animator animator;

	void Start () 
	{
        interactable = GetComponent<Interactable>();
        interactable.KindOfInteractable = Interactable.Kind.Toggle;

        animator = GetComponent<Animator>();

        if (isOn)
        {
            animator.Play("On");
        } // End if (isOn)
        else
        {
            animator.Play("Off");
        } // End else (isOn)
    } // End void Start ()

    public void Move()
    {
        if (isOn)
        {
            animator.CrossFade("Deactivate", transitionTime);
        } // End if (isOn)
        else
        {
            animator.CrossFade("Activate", transitionTime);
        } // End else (isOn)

        isOn = !isOn;

        Debug.Log("Toggle " + name + GetInstanceID().ToString() + " is " + isOn);
    } // End public void Move()

    public bool IsOn
    {
        get
        {
            return isOn;
        }

        set
        {
            isOn = value;
        }
    }
} // End public class Toggle : MonoBehaviour

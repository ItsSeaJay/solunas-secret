
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

    private Interactable interactable;

	void Start () 
	{
        interactable = GetComponent<Interactable>();
        interactable.KindOfInteractable = Interactable.Kind.Toggle;
	} // End void Start ()
	
	void Update () 
	{
		
	} // End void Update ()

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

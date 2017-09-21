
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
    private bool isOpen = false;
    [SerializeField]
    private bool isLocked = false;

    private Interactable interactable;
    private Animator animator;

	void Start ()
	{
        interactable                        = GetComponent<Interactable>();
        animator                            = GetComponent<Animator>();

        animator.Play("Open");
	} // End void Start ()

	void Update ()
	{
		
	} // End void Update ()

    private void Open ()
    {

    }

    private void Close ()
    {

    }

    public void Move ()
    {

    } // End public void Toggle ()

    public bool IsOpen
    {
        get
        {
            return isOpen;
        } // End get
    } // End public bool Open
} // End public class Door : MonoBehaviour

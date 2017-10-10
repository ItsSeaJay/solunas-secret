
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Door
* Description: The class that controls doors. These tcn be locked.
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
    [SerializeField]
    private bool open = false;
    [SerializeField]
    private float transitionTime = 1.0f;
    [SerializeField]
    private string lockedSubtitle = "Locked";

    private Animator animator;
    private Interactable interactable;

	void Start ()
	{
        animator = GetComponent<Animator>();

        Debug.Assert(animator.runtimeAnimatorController != null, "Door " + name + ' ' + GetInstanceID().ToString() + " requires an animator controller to work.");

        if (tag != "Interactable")
        {
            tag = "Interactable";
        } // End if (tag == interactable)

        // Fix animation for when the game starts
        if (open)
        {
            // The door is open
            animator.Play("Opened");
        } // End if (open)
        else
        {
            // The door is closed
            animator.Play("Closed");
        } // End else (open)

        // Get a reference to the interactable and make it a door
        interactable = GetComponent<Interactable>();
        interactable.KindOfInteractable = Interactable.Kind.Door;
    } // End void Start ()

    public void Move ()
    {
        if (!locked)
        {
            if (open)
            {
                Close();
            } // End if (open)
            else
            {
                Open();
            } // End else (open)
        } // End if (!locked)
        else
        {
            Player.Instance.Subs.SetSubtitle(lockedSubtitle);
        } // End if (!locked)
    } // End public void Move ()

    private void Open ()
    {
        //Debug.Log("Opened door " + name + ' ' + GetInstanceID().ToString());
        animator.CrossFade("Open", transitionTime);
        open = true;
    } // End if private void Open()

    private void Close ()
    {
        //Debug.Log("Closed door " + name + ' ' + GetInstanceID().ToString());
        animator.CrossFade("Close", transitionTime);
        open = false;
    } // End if private void Open()
} // End public class Door : MonoBehaviour

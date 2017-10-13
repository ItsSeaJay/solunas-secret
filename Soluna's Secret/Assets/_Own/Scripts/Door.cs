
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Door
* Description: The class that controls doors. These can be locked.
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
[RequireComponent(typeof(Lock))]

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool isOpen = false;
    [SerializeField]
    private float transitionTime = 1.0f;

    private Lock doorLock;
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
        if (isOpen)
        {
            // The door is open
            animator.Play("Opened");
        } // End if (isOpen)
        else
        {
            // The door is closed
            animator.Play("Closed");
        } // End else (open)

        try
        {
            doorLock = GetComponent<Lock>();
        } // End try
        catch
        {
            doorLock = null;
        } // End catch

        // Get a reference to the interactable and make it a door
        interactable = GetComponent<Interactable>();
        interactable.KindOfInteractable = Interactable.Kind.Door;
    } // End void Start ()

    // NOTE: This function is specifically for the player
    public void Move ()
    {
        if (!doorLock.Locked)
        {
            if (isOpen)
            {
                Close();
            } // End if (isOpen)
            else
            {
                Open();
            } // End else (isOpen)
        } // End if (!locked)
        else
        {
            Player.Instance.Subs.SetSubtitle(doorLock.LockedSubtitle);
        } // End if (!locked)
    } // End public void Move ()

    public void Open ()
    {
        //Debug.Log("Opened door " + name + ' ' + GetInstanceID().ToString());
        animator.CrossFade("Open", transitionTime);
        isOpen = true;
    } // End if private void Open()

    public void Close ()
    {
        //Debug.Log("Closed door " + name + ' ' + GetInstanceID().ToString());
        animator.CrossFade("Close", transitionTime);
        isOpen = false;
    } // End if private void Close()

    // Accessor / Mutator
    public bool IsOpen
    {
        get
        {
            return isOpen;
        } // End get
    } // End public book IsOpen
} // End public class Door : MonoBehaviour


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
    private AnimationClip openingClip, openClip, closingClip, closedClip;
    [SerializeField]
    private bool isOpen = false;
    [SerializeField]
    private bool isLocked = false;

    private Interactable interactable;
    private Animator animator;
    private RuntimeAnimatorController runtimeAnimatorController = new RuntimeAnimatorController();

	void Start ()
	{
        interactable                       = GetComponent<Interactable>();
        animator                           = GetComponent<Animator>();

        CreateAnimatorController();
	} // End void Start ()

	void Update ()
	{
		
	} // End void Update ()

    private void CreateAnimatorController()
    {
        var controller = UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath("_Own/Animation/Controllers/" + 
                                                                                                  GetInstanceID().ToString() + "Door");

        // Add StateMachines
        var rootStateMachine = controller.layers[0].stateMachine;

        // Add States
        var openingState = rootStateMachine.AddState("Open");
        var openState    = rootStateMachine.AddState("Opening");
        var closingState = rootStateMachine.AddState("Closing");
        var closedState  = rootStateMachine.AddState("Closed");

        // Set state clips
        openingState.motion = openingClip;
        openState.motion    = openClip;
        closingState.motion = closingClip;
        closedState.motion  = closedClip;

        // Set State Transitions
        openingState.AddExitTransition(openState);
        closingState.AddExitTransition(closedState);
    }

    private void Open ()
    {

    }

    private void Close ()
    {

    }

    public void Move ()
    {
        if (!isLocked)
        {

        }
    } // End public void Toggle ()

    public bool IsOpen
    {
        get
        {
            return isOpen;
        } // End get
    } // End public bool Open
} // End public class Door : MonoBehaviour

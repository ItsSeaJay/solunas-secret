using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

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

        Debug.Assert
        (
            animator.runtimeAnimatorController != null,
            "Door " +
            name +
            ' ' +
            GetInstanceID().ToString()
            +
            " requires an animator controller to work."
        );

        if (tag != "Interactable")
        {
            tag = "Interactable";
        }
        
        if (isOpen)
        {
            animator.Play("Opened");
        }
        else
        {
            animator.Play("Closed");
        }

        doorLock = GetComponent<Lock>();
        
        interactable = GetComponent<Interactable>();
        interactable.KindOfInteractable = Interactable.Kind.Door;
    }
    
    public void Move ()
    {
        if (!doorLock.Locked)
        {
            if (isOpen)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
        else
        {
            Player.Instance.Subs.SetSubtitle(doorLock.LockedSubtitle);
        }
    }

    public void Open ()
    {
        animator.CrossFade("Open", transitionTime);
        isOpen = true;
    }

    public void Close ()
    {
        animator.CrossFade("Close", transitionTime);
        isOpen = false;
    }
    
    public bool IsOpen
    {
        get
        {
            return isOpen;
        }
    }
}

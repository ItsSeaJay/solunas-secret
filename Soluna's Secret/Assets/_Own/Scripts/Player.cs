
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Player
* Description: N/a
* Author(s):   Callum John
* Date:        9/11/2017 9:41:59 AM
******************************************************************************/

// Libraries
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public enum State
    {
        Normal,
        Frozen
    };

    [SerializeField]
    private Transform firstPersonCharacter;
    [SerializeField]
    private FirstPersonController firstPersonController;
    [SerializeField]
    private Crosshair crosshair;
    [SerializeField]
    private Transform hand;
    [SerializeField]
    private Subtitles subs;
    [SerializeField]
    [Tooltip("From how far away the player can interact with objects.")]
    private float reach = 4.0f;

    private Dictionary<string, Interactable> interactableDictionary = new Dictionary<string, Interactable>();
    private GameObject heldItem;
    private State currentState = State.Normal;
    private static Player instance;
    private RaycastHit forwardLookHit; // Used for detecting line-of-sight with objects

    void Awake()
    {
        // Ensure there is only one instance of the player in a given scene
        if (instance != null)
        {
            Destroy(gameObject);
        } // End if (instance != null)

        instance = this;
    }

    void Start ()
	{
        Debug.Assert(crosshair != null);
        Debug.Assert(hand      != null);

        RefreshInteractableDictionary();

        try
        {
            heldItem = hand.transform.GetChild(0).gameObject;
        }
        catch
        {
            heldItem = null;
        }
    } // End void Start ()

	void Update ()
	{
        switch (currentState)
        {
            case State.Normal:
                HandleLooking();
                firstPersonController.MouseLookEnabled = true;
                break;
            case State.Frozen:
                HandleLooking();
                Cursor.lockState = CursorLockMode.Locked;
                firstPersonController.MouseLookEnabled = false;
                break;
            default:
                break;
        }
	} // End void Update ()

    private void HandleLooking()
    {
        Vector3 forwardLookVector = firstPersonCharacter.transform.TransformDirection(Vector3.forward);
        LayerMask layerMask = 1 << LayerMask.NameToLayer("Default"); // Only collide with default objects

        if (Physics.Raycast(firstPersonCharacter.position,
                            forwardLookVector,
                            out forwardLookHit,
                            reach,
                            layerMask))
        {
            // Update Cursor when looking at an interactable object
            if (forwardLookHit.transform.tag == "Interactable")
            {
                // We are looking at an interactable object
                // Alter the sprite of the crosshair accordingly
                switch (interactableDictionary[forwardLookHit.transform.gameObject.GetInstanceID().ToString()].KindOfInteractable)
                {
                    case Interactable.Kind.Unspecified:
                        crosshair.SetSprite("Interact");
                        break;
                    case Interactable.Kind.Pedastal:
                        crosshair.SetSprite("Interact");
                        break;
                    case Interactable.Kind.Pickup:
                        crosshair.SetSprite("Pickup");
                        break;
                    case Interactable.Kind.Door:
                        crosshair.SetSprite("Interact");
                        break;
                    case Interactable.Kind.Inscription:
                        crosshair.SetSprite("Look");
                        break;
                    default:
                        crosshair.SetSprite("Default");
                        break;
                } // End if ()

                if (Input.GetButtonDown("Interact"))
                {
                    Interact();
                } // if (Input.GetButtonDown("Interact"))
            } // End if (forwardLookHit.transform.tag == "Interactable")
            else
            {
                // We are looking at a noninteractable object
                crosshair.SetSprite("Default");
            } // End else (forwardLookHit.transform.tag == "Interactable")
        } // End if (Physics.Raycast(firstPersonCharacter.position, ...
        else
        {
            // We are looking at nothing or the sky
            crosshair.SetSprite("Default");
        } // End else (Physics.Raycast(firstPersonCharacter.position, ...
    } // End private void

    private void Interact ()
    {
        interactableDictionary[forwardLookHit.transform.gameObject.GetInstanceID().ToString()].HandleInteraction();
    } // End private void Interact ()

    public void RefreshInteractableDictionary()
    {
        interactableDictionary.Clear();

        object[] interactableObjectsArray = FindObjectsOfType(typeof(Interactable));

        foreach (Interactable interactable in interactableObjectsArray)
        {
            interactableDictionary.Add(interactable.gameObject.GetInstanceID().ToString(), interactable);
        } // End foreach (Interactable interactable in interactableObjectsArray)
    } // End private void RefreshInteractableDictionary()

    // Accessors/Mutators()
    public State CurrentState
    {
        get
        {
            return currentState;
        }
        set
        {
            currentState = value;
        }
    }

    public static Player Instance
    {
        get
        {
            return instance;
        }
    }

    public Transform FirstPersonCharacter
    {
        get
        {
            return firstPersonCharacter;
        }
    }

    public Subtitles Subs
    {
        get
        {
            return subs;
        }
    }

    public Transform Hand
    {
        get
        {
            return hand;
        }
    }

    public GameObject HeldItem
    {
        get
        {
            return heldItem;
        }
        set
        {
            heldItem = value;
        }
    }
} // End public class Player : MonoBehaviour


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
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform firstPersonCharacter;
    [SerializeField]
    private Crosshair crosshair;
    [SerializeField]
    private Transform hand;
    [SerializeField]
    [Tooltip("From how far away the player can interact with objects.")]
    private float reach = 4.0f;

    private Dictionary<string, Interactable> interactableDictionary = new Dictionary<string, Interactable>();
    private GameObject heldItem;    
    private RaycastHit forwardLookHit; // Used for detecting line-of-sight with objects

    void Start ()
	{
        Debug.Assert(hand != null);

        RefreshInteractableDictionary();
    } // End void Start ()

	void Update ()
	{
        HandleLooking();
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
            // Update Cursor
            if (forwardLookHit.transform.tag == "Interactable")
            {
                // We are looking at an interactable object
                switch (interactableDictionary[forwardLookHit.transform.gameObject.GetInstanceID().ToString()].KindOfInteractable)
                {
                    case Interactable.Kind.Unspecified:
                        crosshair.SetSprite("Pickup");
                        break;
                    case Interactable.Kind.Pedastal:
                        crosshair.SetSprite("Pickup");
                        break;
                    default:
                        break;
                }

                if (Input.GetButtonDown("Interact"))
                {
                    Interact();
                } // if (Input.GetButtonDown("Interact"))
            } // End if (forwardLookHit.transform.tag == "Interactable")
            else
            {
                // We are looking at a noninteractable object
                crosshair.SetSprite("Default");
            }
        } // End if (Physics.Raycast(firstPersonCharacter.position, ...
        else
        {
            // We are looking at nothing or the sky
            crosshair.SetSprite("Default");
        } // End else (Physics.Raycast(firstPersonCharacter.position, ...
    }

    private void Interact ()
    {
        interactableDictionary[forwardLookHit.transform.gameObject.GetInstanceID().ToString()].HandleInteraction();
    } // End private void Interact ()

    private void RefreshInteractableDictionary()
    {
        interactableDictionary.Clear();

        object[] interactableObjectsArray = FindObjectsOfType(typeof(Interactable));

        foreach (Interactable interactable in interactableObjectsArray)
        {
            interactableDictionary.Add(interactable.gameObject.GetInstanceID().ToString(), interactable);
        } // End foreach (Interactable interactable in interactableObjectsArray)
    } // End private void RefreshInteractableDictionary()

    // Accessors/Mutators()
    public Transform FirstPersonCharacter
    {
        get
        {
            return firstPersonCharacter;
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

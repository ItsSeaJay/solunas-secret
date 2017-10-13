
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Interactable
* Description: N/a
* Author(s):   Callum John
* Date:        9/14/2017 1:46:15 PM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum Kind
    {
        Unspecified,
        Pedastal,
        Pickup,
        Door,
        Toggle,
        Inscription
    }

    private Kind kindOfInteractable = Kind.Unspecified;

    private Pedastal pedastal;
    private Pickup pickup;
    private Door door;
    private Toggle toggle;
    private Inscription inscription;

	void Start ()
	{
        if (tag != "Interactable")
        {
            tag = "Interactable";
        } // End if (tag != "Interactable")

        GetInteractableComponentFromKind();
    } // End void Start ()

    private void GetInteractableComponentFromKind()
    {
        switch (kindOfInteractable)
        {
            case Kind.Unspecified:
                Debug.LogWarning(name + 
                                 GetInstanceID().ToString() +
                                 "'s kindOfInteractable is unspecified!");
                break;
            case Kind.Pedastal:
                pedastal = GetComponent<Pedastal>();
                break;
            case Kind.Pickup:
                pickup = GetComponent<Pickup>();
                break;
            case Kind.Door:
                door = GetComponent<Door>();
                break;
            case Kind.Toggle:
                door = GetComponent<Door>();
                break;
            case Kind.Inscription:
                break;
            default:
                break;
        } // End switch (kindOfInteractable)
    } // End private void GetInteractableComponentFromKind()

    public void HandleInteraction()
    {
        switch (kindOfInteractable)
        {
            case Kind.Unspecified:
                break;
            case Kind.Pedastal:
                pedastal.Hold();
                break;
            case Kind.Pickup:
                Pickup pickup = GetComponent<Pickup>();

                pickup.Obtain();
                break;
            case Kind.Door:
                Door door = GetComponent<Door>();

                door.Move();
                break;
            case Kind.Inscription:
                Inscription inscription = GetComponent<Inscription>();

                inscription.Read();
                break;
            case Kind.Toggle:
                Toggle toggle = GetComponent<Toggle>();

                toggle.Move();
                break;
            default:
                break;
        } // End switch (kindOfInteractable)
    } // End public void HandleInteraction()

    // Accessors/Mutators
    public Kind KindOfInteractable
    {
        get
        {
            return kindOfInteractable;
        }
        set
        {
            kindOfInteractable = value;
        }
    }
} // End public class Interactable : MonoBehaviour


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

	void Start ()
	{
        if (tag != "Interactable")
        {
            tag = "Interactable";
        }
    } // End void Start ()

    public void HandleInteraction()
    {
        switch (kindOfInteractable)
        {
            case Kind.Unspecified:
                break;
            case Kind.Pedastal:
                Pedastal pedastal = GetComponent<Pedastal>();

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

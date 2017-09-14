
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
        Pickup
    }

    private Kind kindOfInteractable = Kind.Unspecified;

	void Start ()
	{
        tag = "Interactable";
    } // End void Start ()

	void Update ()
	{
		
	} // End void Update ()

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
            default:
                break;
        }
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

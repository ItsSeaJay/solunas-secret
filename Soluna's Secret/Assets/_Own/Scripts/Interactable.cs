
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Interactable
* Description: An object that the player can click on to make something happen.
*              Do not add this class directly!
* Author(s):   Callum John
* Date:        9/13/2017 8:10:20 AM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    enum Kind
    {
        Unspecified,
        Pedastal,
        Trigger,
        Door,
        Inscription
    }

    private Kind kindOfInteractable = Kind.Unspecified;
    private Player player;

    void Start ()
	{
        if (tag != "Interactable" ||
            transform.tag != "Interactable")
        {
            tag = "Interactable";
            transform.tag = "Interactable";
        } // if (tag != "Interactable" ||...

        player = GameObject.Find("Player").GetComponent<Player>();
    } // End void Start ()

	void Update ()
	{
		
	} // End void Update ()

    public void HandleInteraction ()
    {
        switch (kindOfInteractable)
        {
            case Kind.Unspecified:
                break;
            case Kind.Pedastal:
                break;
            case Kind.Trigger:
                break;
            case Kind.Door:
                break;
            case Kind.Inscription:
                break;
            default:
                break;
        }
    }
} // End public class Interactable : MonoBehaviour


/******************************************************************************
* Product:     Soluna's Secret
* Script:      Pedastal
* Description: N/a
* Author(s):   Callum John
* Date:        9/14/2017 12:40:56 PM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requirement(s)
[RequireComponent(typeof(Interactable))]

public class Pedastal : MonoBehaviour
{
    [SerializeField]
    private GameObject container;
    [SerializeField]
    private Player player;

    private Interactable interactable;
    private GameObject heldItem;

    private bool full = false;

	void Start ()
	{
        interactable = GetComponent<Interactable>();
        interactable.KindOfInteractable = Interactable.Kind.Pedastal;

        if (player == null)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        } // End if player == null

        try
        {
            heldItem = container.transform.GetChild(0).gameObject;
        }
        catch
        {
            heldItem = null;
        }
	} // End void Start ()

	void Update ()
	{
        if (container.transform.childCount > 0)
        {
            if (!full)
            {
                full = true;
            }
        } // End if (container.transform.childCount > 0)
        else
        {
            full = false;
        } // End if (container.transform.childCount > 0)
    } // End void Update ()

    public void Hold()
    {
        if (!full)
        {
            // If the player is currently holding an item
            if (player.HeldItem != null)
            {
                // Put it down on the pedastal
                heldItem = player.HeldItem;
                player.HeldItem = null;

                heldItem.transform.parent = container.transform;
                heldItem.transform.localPosition = new Vector3(0, heldItem.transform.localScale.y, 0);
                heldItem.transform.localEulerAngles = Vector3.zero;

                tag = "Untagged";
            } // End if (player.HeldItem != null)
        } // End if (!full)
    } // End public void Toggle()

    // Accessors/Mutators
    public bool Full
    {
        get
        {
            return full;
        }
    }
} // End public class Pedastal : MonoBehaviour

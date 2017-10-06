
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Pickup
* Description: N/a
* Author(s):   Callum John
* Date:        9/14/2017 3:30:13 PM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requirement(s)
[RequireComponent(typeof(Interactable))]

public class Pickup : MonoBehaviour
{
    private Interactable interactable;
    private bool held = false;

	void Start ()
	{
        interactable = GetComponent<Interactable>();
        interactable.KindOfInteractable = Interactable.Kind.Pickup;
	} // End void Start ()

	void Update ()
	{
		if (transform.parent == Player.Instance.Hand.transform)
        {
            held = true;
        } // if (transform.parent == player.Hand.transform)
        else
        {
            held = false;
        } // End else (transform.parent == player.Hand.transform)
    } // End void Update ()

    public void Obtain ()
    {
        // Only if the player isn't holding anything
        if (Player.Instance.HeldItem == null)
        {
            // Allow the player to pick it up
            transform.parent = Player.Instance.Hand.transform;
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;

            Player.Instance.HeldItem = this.gameObject;
        } // End if (player.Hand.transform.childCount == 0)
        else
        {
            Player.Instance.Subs.SetSubtitle("Hands are full.");
        }
    } // End public void Obtain ()

    public bool Held
    {
        get
        {
            return held;
        }
    }
} // End public class Pickup : MonoBehaviour

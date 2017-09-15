
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
    [SerializeField]
    private Player player;

    private Interactable interactable;
    private bool held = false;

	void Start ()
	{
        interactable = GetComponent<Interactable>();
        interactable.KindOfInteractable = Interactable.Kind.Pickup;

		if (player == null)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        } // End if (player == null)
	} // End void Start ()

	void Update ()
	{
		if (transform.parent == player.Hand.transform)
        {
            held = true;
        }
        else
        {
            held = false;
        }
	} // End void Update ()

    public void Obtain ()
    {
        // Allow the player to pick it up
        transform.parent           = player.Hand.transform;
        transform.localPosition    = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;

        player.HeldItem = this.gameObject;
    } // End public void Obtain ()
} // End public class Pickup : MonoBehaviour

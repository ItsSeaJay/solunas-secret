
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Lantern
* Description: N/a
* Author(s):   Callum John
* Date:        9/15/2017 2:45:14 PM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Requirement(s)
[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(FlickeringLight))]

public class Lantern : MonoBehaviour
{
    [SerializeField]
    private Projector lanternProjector;
    [SerializeField]
    private Light     lanternLight;
    [SerializeField]
    private Collider  lightCollider;
    [SerializeField]
    private FlickeringLight flickeringLight;

    private Pickup pickup;

    private bool isLit = true;
    private float target;

	void Start ()
	{
        Debug.Assert(lanternProjector != null);
        Debug.Assert(lanternLight != null);
        Debug.Assert(lightCollider != null);

        pickup = GetComponent<Pickup>();
	} // End void Start ()

	void Update ()
	{
		if (pickup.Held)
        {
            if (Input.GetButtonDown("Lantern") &&
                Player.Instance.CurrentState != Player.State.Frozen)
            {
                Toggle();
            } // End if (Input.GetKeyDown("Lantern"))
        } // End if (pickup.Held)
    } // End void Update ()

    private void Toggle()
    {
        isLit = !isLit;

        lanternProjector.enabled = !lanternProjector.enabled;
        lanternLight.enabled = !lanternLight.enabled;
        lightCollider.enabled = !lightCollider.enabled;
        flickeringLight.enabled = !flickeringLight.enabled;
    } // End private void Toggle()
} // End public class Lantern : MonoBehaviour

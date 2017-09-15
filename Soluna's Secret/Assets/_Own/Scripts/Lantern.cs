
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

public class Lantern : MonoBehaviour
{


    private Pickup pickup;

    private bool isLit = true;

	void Start ()
	{
        pickup = GetComponent<Pickup>();
	} // End void Start ()

	void Update ()
	{
		if (pickup.Held)
        {
            if (Input.GetButtonDown("Lantern"))
            {
                Toggle();
            } // End if (Input.GetKeyDown("Lantern"))
        } // End if (pickup.Held)
	} // End void Update ()

    private void Toggle()
    {
        isLit = !isLit;

        if (isLit)
        {

        } // End else (isLit)
        else
        {

        } // End else (isLit)
    } // End private void Toggle()
} // End public class Lantern : MonoBehaviour

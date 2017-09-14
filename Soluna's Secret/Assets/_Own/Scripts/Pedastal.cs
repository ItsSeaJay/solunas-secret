
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

    private GameObject heldItem;
    private Player player;

    private bool full = false;

	void Start ()
	{
        player = GameObject.Find("Player").GetComponent<Player>();
	} // End void Start ()

	void Update ()
	{
        if (container.transform.childCount > 0)
        {
            full = true;
        } // End if (container.transform.childCount > 0)
        else
        {
            full = false;
        } // End if (container.transform.childCount > 0)
    } // End void Update ()

    // Accessors/Mutators()
    public bool Full
    {
        get
        {
            return full;
        }
    }
} // End public class Pedastal : MonoBehaviour

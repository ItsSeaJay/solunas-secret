
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Player
* Description: N/a
* Author(s):   Callum John
* Date:        9/11/2017 9:41:59 AM
******************************************************************************/

// Libraries
using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform hand;
    [SerializeField]
    private GameObject heldObject;

	void Start ()
	{
        Debug.Assert(hand != null);

		try
        {
            heldObject = GetChild();
        }
        catch
        {
            Debug.LogWarning("No object held in the players hand on Start ()");
        }
	} // End void Start ()

	void Update ()
	{
		
	} // End void Update ()
} // End public class Player : MonoBehaviour

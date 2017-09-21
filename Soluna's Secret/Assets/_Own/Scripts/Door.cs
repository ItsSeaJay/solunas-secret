
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Door
* Description: N/a
* Author(s):   Callum John
* Date:        9/21/2017 3:20:25 PM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool open = false;

	void Start ()
	{
		
	} // End void Start ()

	void Update ()
	{
		
	} // End void Update ()

    public void Toggle ()
    {

    } // End public void Toggle ()

    public bool Open
    {
        get
        {
            return open;
        } // End get
    } // End public bool Open
} // End public class Door : MonoBehaviour

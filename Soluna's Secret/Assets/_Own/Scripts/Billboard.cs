
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Billboard
* Description: N/a
* Author(s):   Callum John
* Date:        9/15/2017 5:01:22 PM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
	void Update ()
	{
        transform.forward = -Camera.main.transform.forward;
	} // End void Update ()
} // End public class Billboard : MonoBehaviour

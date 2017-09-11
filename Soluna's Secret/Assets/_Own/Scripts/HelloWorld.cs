
/******************************************************************************
* Product:     Soluna's Secret
* Script:      HelloWorld
* Description: Outputs the message 'Hello, World!' to the debug console.
* Author(s):   Callum John
* Date:        8/27/2017 12:06:47 PM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    private const string helloWorld = "Hello, World!";

    void Start()
    {
        Say();
    } // End void Start()

    public static void Say()
    {
        // Same as Debug.Log in function
        print(helloWorld);
    } // End public static void Say()
} // End public class HelloWorld

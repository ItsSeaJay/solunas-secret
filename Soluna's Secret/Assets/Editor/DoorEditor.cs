
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Door
* Description: N/a
* Author(s):   Callum John
* Date:        10/10/2017 2:32:59 PM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Door))]
[ExecuteInEditMode]

public class DoorEditor : Editor 
{
	void OnInspectorGUI()
    {
        var door = target as Door;

        door.Locked = GUILayout.Toggle(door.Locked, "Locked");

        //if (door.Locked)
        //{
        //    door.DoorSwitches = EditorGUILayout.;
        //}
    }
} // End public class Door : MonoBehaviour

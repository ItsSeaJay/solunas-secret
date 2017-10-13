
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Lock
* Description: Can be placed alongside certain classes to prevent player interaction.
* Author(s):   Callum John
* Date:        10/13/2017 12:00:27 PM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [System.Serializable]
    public struct UnlockCondition
    {
        public Toggle toggle; // A reference to the toggle
        public bool listenFor;
    } // End private struct DoorSwitch

    [Tooltip("The Lock is 'locked' if this has more than zero values.")]
    private UnlockCondition[] unlockConditions;

    [SerializeField]
    private bool locked;

    void Start ()
	{
		
	} // End void Start ()

	void Update ()
	{
		
	} // End void Update ()

    // Accessors / Mutators
    public UnlockCondition[] UnlockConditions
    {
        get
        {
            return unlockConditions;
        } // End get
        set
        {
            unlockConditions = value;
        } // End set
    } // End public UnlockCondition[] UnlockConditions
} // End public class Lock : MonoBehaviour

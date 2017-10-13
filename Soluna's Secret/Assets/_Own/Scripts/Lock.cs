
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
        public Toggle toggle;  // A reference to the toggle
        public bool listenFor; // Whether that toggle should be on or off
    } // End private struct DoorSwitch
    
    [SerializeField]
    [Tooltip("The Lock is 'locked' if this has more than zero values.")]
    private UnlockCondition[] unlockConditions;

    [SerializeField]
    private bool locked;
    [SerializeField]
    private string lockedSubtitle = "Locked";

    private Door door;

    void Start()
    {
        try
        {
            door = GetComponent<Door>();
        } // End try
        catch
        {
            door = null;
        } // End catch
    } // End void Start ()

    void Update ()
	{
        // If the lock is locked and can be unlocked
		if (locked &&
            unlockConditions.Length > 0)
        {
            CheckUnlockConditions();
        } // End if (locked && ...
	} // End void Update ()

    private void CheckUnlockConditions()
    {
        int numberOfConditionsSatisfied = 0;

        for (int i = 0; i < unlockConditions.Length; ++i)
        {
            // If the toggle in this position is what the door is asking for
            if (unlockConditions[i].toggle.IsOn == unlockConditions[i].listenFor)
            {
                ++numberOfConditionsSatisfied;
            } // End if (unlockConditions[i].toggle.IsOn == unlockConditions[i].listenFor)
        } // End for (int i = 0; i < unlockConditions.Length; i++)

        if (numberOfConditionsSatisfied == unlockConditions.Length)
        {
            //if (locked)
            //{
            //    Unlock();
            //} // End if (locked)

            if (door != null)
            {
                if (!door.IsOpen)
                {
                    door.Open();
                } // End if (door.IsOpen)
            } // End if (door != null)
        } // End if (numberOfConditionsSatisfied == unlockConditions.Length)
        else
        {
            //if (!locked)
            //{
            //    LockUp();
            //} // End if (!locked)

            if (door != null)
            {
                if (door.IsOpen)
                {
                    door.Close();
                } // End if (door.IsOpen)
            } // End if (door != null)
        } // End else (numberOfConditionsSatisfied == unlockConditions.Length)
    } // End private void CheckUnlockConditions()

    public void LockUp()
    {
        locked = true;
    } // End public void LockUp()

    public void Unlock()
    {
        locked = false;
    } // End public void Unlock()

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

    public bool Locked
    {
        get
        {
            return locked;
        } // End get
        set
        {
            locked = value;
        } // End set
    } // End public bool Locked

    public string LockedSubtitle
    {
        get
        {
            return lockedSubtitle;
        } // End get
    } // End public bool Locked
} // End public class Lock : MonoBehaviour

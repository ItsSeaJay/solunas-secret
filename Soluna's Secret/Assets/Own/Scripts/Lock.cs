using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [System.Serializable]
    public struct UnlockCondition
    {
        public Toggle toggle;
        public bool listenFor;
    }
    
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
        }
        catch
        {
            door = null;
        }
    }

    void Update ()
	{
		if (locked &&
            unlockConditions.Length > 0)
        {
            CheckUnlockConditions();
        }
	}

    private void CheckUnlockConditions()
    {
        int numberOfConditionsSatisfied = 0;

        for (int i = 0; i < unlockConditions.Length; ++i)
        {
            if (unlockConditions[i].toggle.IsOn == unlockConditions[i].listenFor)
            {
                ++numberOfConditionsSatisfied;
            }
        }

        if (numberOfConditionsSatisfied == unlockConditions.Length)
        {
            if (door != null)
            {
                if (!door.IsOpen)
                {
                    door.Open();
                }
            }
        }
        else
        {
            if (door != null)
            {
                if (door.IsOpen)
                {
                    door.Close();
                }
            }
        }
    }

    public void LockUp()
    {
        locked = true;
    }

    public void Unlock()
    {
        locked = false;
    }
    
    public UnlockCondition[] UnlockConditions
    {
        get
        {
            return unlockConditions;
        }
        set
        {
            unlockConditions = value;
        }
    }

    public bool Locked
    {
        get
        {
            return locked;
        }
        set
        {
            locked = value;
        }
    }

    public string LockedSubtitle
    {
        get
        {
            return lockedSubtitle;
        }
    }
}

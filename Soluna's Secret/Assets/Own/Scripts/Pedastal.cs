using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]

public class Pedastal : MonoBehaviour
{
    [SerializeField]
    private GameObject container;
    [SerializeField]
    private Player player;

    private Interactable interactable;
    private GameObject heldItem;

    private bool full = false;

	void Start ()
	{
        interactable = GetComponent<Interactable>();
        interactable.KindOfInteractable = Interactable.Kind.Pedastal;

        if (player == null)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        }

        try
        {
            heldItem = container.transform.GetChild(0).gameObject;
        }
        catch
        {
            heldItem = null;
        }
	}

	void Update ()
	{
        if (container.transform.childCount > 0)
        {
            full = true;
            tag = "Untagged";
        }
        else
        { 
            full = false;
            tag = "Interactable";
        }
    }

    public void Hold()
    {
        if (!full)
        {
            if (player.HeldItem != null)
            {
                heldItem        = player.HeldItem;
                player.HeldItem = null;

                heldItem.transform.parent = container.transform;
                heldItem.transform.localPosition = new Vector3(0, heldItem.transform.localScale.y, 0);
                heldItem.transform.localEulerAngles = Vector3.zero;

                tag = "Untagged";
            }
        }
    } // End public void Toggle()

    // Accessors/Mutators
    public bool Full
    {
        get
        {
            return full;
        } // End get Full
    } // End public bool Full
} // End public class Pedastal : MonoBehaviour

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum Kind
    {
        Unspecified,
        Pedastal,
        Pickup,
        Door,
        Toggle,
        Inscription
    }

    private Kind kindOfInteractable = Kind.Unspecified;
    
    private Pedastal pedastal;
    private Pickup pickup;
    private Door door;
    private Toggle toggle;
    private Inscription inscription;

	void Start ()
	{
        tag = "Interactable";

        StartCoroutine(GetInteractableComponentFromKind());
    }

    private IEnumerator GetInteractableComponentFromKind()
    {
        yield return new WaitForSeconds(0.1f);

        switch (kindOfInteractable)
        {
            case Kind.Unspecified:
                Debug.LogWarning
                (
                    name + 
                    GetInstanceID().ToString() +
                    "'s kindOfInteractable is unspecified!"
                );
                break;
            case Kind.Pedastal:
                pedastal = GetComponent<Pedastal>();
                break;
            case Kind.Pickup:
                pickup = GetComponent<Pickup>();
                break;
            case Kind.Door:
                door = GetComponent<Door>();
                break;
            case Kind.Toggle:
                toggle = GetComponent<Toggle>();
                break;
            case Kind.Inscription:
                inscription = GetComponent<Inscription>();
                break;
            default:
                break;
        }
    }

    public void HandleInteraction()
    {
        switch (kindOfInteractable)
        {
            case Kind.Unspecified:
                Debug.LogWarning("Player tried to interact with unspecified interactable.");
                break;
            case Kind.Pedastal:
                pedastal.Hold();
                break;
            case Kind.Pickup:
                pickup.Obtain();
                break;
            case Kind.Door:
                door.Move();
                break;
            case Kind.Inscription:
                inscription.Read();
                break;
            case Kind.Toggle:
                toggle.Move();
                break;
            default:
                break;
        }
    }
    
    public Kind KindOfInteractable
    {
        get
        {
            return kindOfInteractable;
        }
        set
        {
            kindOfInteractable = value;
        }
    }
}

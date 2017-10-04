
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Inscription
* Description: An object that can be read when clicked on.
* Author(s):   Callum John
* Date:        10/4/2017 9:38:48 AM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requirement(s)
[RequireComponent(typeof(Interactable))]

public class Inscription : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private string[] messages = {"Lorem Ipsum"};

    private Interactable interactable;

    private string currentMessage = "";
    private int currentMessageIndex = 0;

	void Start ()
	{
        interactable = GetComponent<Interactable>();
        interactable.KindOfInteractable = Interactable.Kind.Inscription;

        if (player == null)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        } // End if (player == null)
	} // End void Start ()

	void Update ()
	{
		
	} // End void Update ()

    public void Read ()
    {
        
    }
} // End public class Inscription : MonoBehaviour

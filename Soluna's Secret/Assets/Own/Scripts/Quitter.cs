
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class allows objects to quit the game
// The following script was taken from Unity's official UI Live Training
// https://youtu.be/OWtQnZsSdEU
// Then upgraded by Callum John (@ItsSeaJay)

public class Quitter : MonoBehaviour
{
    [Tooltip("Whether the player is allowed to quit using a button.")]
    public bool quitUsingButton = false;
    [Tooltip("The button that will be used to quit the game.")]
    public string buttonToPush = "Cancel";
	
	void Update ()
    {
		if (Input.GetButtonDown(buttonToPush) &&
            quitUsingButton)
        {
            Quit();
        } // End if Input.GetButtonDown(buttonToPush)
    }

    public void Quit ()
    {
        // Quit the game using different methods
        // Depending on how it is being viewed
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    } // End private void Quit ()
} // End public class Quitter : MonoBehaviour

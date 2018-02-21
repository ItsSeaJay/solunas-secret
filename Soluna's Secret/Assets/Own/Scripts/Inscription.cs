
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Inscription
* Description: Something that the player can read.
* Author(s):   Callum John
* Date:        9/7/2017 12:48:35 PM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Interactable))]
public class Inscription : MonoBehaviour
{
    [System.Serializable]
    struct TextMeshProSettings
    {
        public float padding;
        public TMP_FontAsset font;
        public TMP_SpriteAsset cursor;
    }

    [SerializeField]
    private List<string> message = new List<string>();
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private TextMeshProSettings textMeshProSettings;
    [SerializeField]
    private float messageSpeed = 8.0f;

    private Interactable interactable;
    private GameObject display;
    private TextMeshProUGUI displayTextMeshProUGUI;

    private int currentMessageIndex = 0;
    private int numberOfInteractions = 0;
    private float bufferPosition = 0.0f;
    private string currentMessageString = "";

    void Start()
    {
        Debug.Assert(canvas != null);

        interactable = GetComponent<Interactable>();
        interactable.KindOfInteractable = Interactable.Kind.Inscription;

        display = new GameObject(name + GetInstanceID().ToString());
        display.transform.parent = canvas.transform;
        displayTextMeshProUGUI = display.AddComponent<TextMeshProUGUI>();

        display.SetActive(false);

        displayTextMeshProUGUI.rectTransform.sizeDelta = new Vector2(128 - textMeshProSettings.padding, 72 - textMeshProSettings.padding);
        displayTextMeshProUGUI.rectTransform.localScale = new Vector3(1, 1, 1);
        displayTextMeshProUGUI.rectTransform.localPosition = Vector3.zero;

        displayTextMeshProUGUI.font = textMeshProSettings.font;
        displayTextMeshProUGUI.fontSize = 8;
        displayTextMeshProUGUI.alignment = TextAlignmentOptions.Bottom;

        displayTextMeshProUGUI.spriteAsset = textMeshProSettings.cursor;
    } // End void Start ()

    void Update()
    {
        if (display.activeInHierarchy)
        {
            // Move the text buffer along
            bufferPosition += Time.deltaTime * messageSpeed;
            bufferPosition = Mathf.Clamp(bufferPosition, 0, message[currentMessageIndex].Length);
        } // End if (display.activeInHierarchy)

        displayTextMeshProUGUI.text = (message[currentMessageIndex]).Substring(0, (int)bufferPosition);
    } // End void Update ()

    public void Read()
    {
        bufferPosition = 0;

        // If the next message is not the end
        if (currentMessageIndex + 1 < message.Count)
        {
            Player.Instance.CurrentState = Player.State.Frozen;

            display.SetActive(true);

            if (numberOfInteractions == 0)
            {
                ++numberOfInteractions;
            } // End if (numberOfInteractions == 0)
            else
            {
                ++currentMessageIndex;
            } // End else (numberOfInteractions == 0)
        } // End if (currentMessageIndex + 1 < message.Count)
        else
        {
            currentMessageIndex = 0;
            numberOfInteractions = 0;

            display.SetActive(false);

            Player.Instance.CurrentState = Player.State.Normal;
        } // End else
    } // End public void Read()
} // End public class Inscription

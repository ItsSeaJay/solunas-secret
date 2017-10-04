
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
using TMPro;

// Requirement(s)
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
    private Player player;
    private GameObject display;
    private TextMeshProUGUI displayTextMeshProUGUI;

    private int currentMessageIndex = 0;
    private float bufferPosition = 0.0f;
    private string currentMessageString = "";

    void Start ()
	{
        interactable = GetComponent<Interactable>();
        interactable.KindOfInteractable = Interactable.Kind.Inscription;

        Debug.Assert(canvas != null);

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

        if (player == null)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        } // End if (player == null)

        if (canvas == null)
        {
            canvas = GameObject.Find("Canvas");
        } // End if (player == null)
    } // End void Start ()

    void Update()
    {
        bufferPosition += Time.deltaTime * messageSpeed;
        bufferPosition = Mathf.Clamp(bufferPosition, 0, message[currentMessageIndex].Length);

        displayTextMeshProUGUI.text = (message[currentMessageIndex] + " <sprite = 0>").Substring(0, (int)bufferPosition);
    } // End void Update ()

    public void Read()
    {
        bufferPosition = 0;

        if (currentMessageIndex < message.Count)
        {
            player.CurrentState = Player.State.Frozen;

            display.SetActive(true);

            currentMessageIndex++;

            if (currentMessageIndex != message.Count)
            {
                displayTextMeshProUGUI.spriteAsset = textMeshProSettings.cursor;
                displayTextMeshProUGUI.text += " <sprite=0>";
            } // End if (currentmessageindex == message.count)
        } // End if (currentMessageIndex <= message.Count)
        else
        {
            currentMessageIndex = 0;

            display.gameObject.SetActive(false);

            player.CurrentState = Player.State.Normal;
        } // End else (currentMessageIndex <= message.Count)
    } // public void Read()
} // End public class Inscription : MonoBehaviour

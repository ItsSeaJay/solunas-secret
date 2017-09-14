
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Crosshair
* Description: N/a
* Author(s):   Callum John
* Date:        9/13/2017 7:45:57 AM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Requirement(s)
[RequireComponent(typeof(Image))]

public class Crosshair : MonoBehaviour
{
    [System.Serializable]
    struct CrosshairType
    {
        public string name;
        public Sprite sprite;
    } // End struct CrosshairTypes

    [SerializeField]
    CrosshairType[] crosshairTypesArray;

    private Dictionary<string, Sprite> crosshairTypesDictionary = new Dictionary<string, Sprite>();

    private Image image;
    private RectTransform rectTransform;

    void Start ()
	{
        image         = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();

        foreach (CrosshairType ct in crosshairTypesArray)
        {
            crosshairTypesDictionary.Add(ct.name, ct.sprite);

            Debug.Log(ct.sprite.name);
        } // End foreach(CrosshairType crosshairType in crosshairTypesArray)
    } // End void Start ()

    public void SetSprite(string key)
    {
        image.sprite = crosshairTypesDictionary[key];

        // Fix sprite rect dimensions
        rectTransform.sizeDelta = new Vector2(crosshairTypesDictionary[key].rect.width,
                                              crosshairTypesDictionary[key].rect.height);
    } // public void SetSprite (int index)
} // End public class Crosshair : MonoBehaviour

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class Crosshair : MonoBehaviour
{
    [System.Serializable]
    struct CrosshairType
    {
        public string name;
        public Sprite sprite;
    }

    [SerializeField]
    CrosshairType[] crosshairTypesArray;

    private Dictionary<string, Sprite> crosshairTypesDictionary = new Dictionary<string, Sprite>();

    private Image image;
    private RectTransform rectTransform;

    void Start ()
	{
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();

        foreach (CrosshairType ct in crosshairTypesArray)
        {
            crosshairTypesDictionary.Add(ct.name, ct.sprite);
        }
    }

    private void FixSpriteRectDimensions(string key)
    {
        // Maintain the proper dimensions of the source file
        rectTransform.sizeDelta = new Vector2(crosshairTypesDictionary[key].rect.width,
                                              crosshairTypesDictionary[key].rect.height);
    }

    public void SetSprite(string key)
    {
        image.sprite = crosshairTypesDictionary[key];

        FixSpriteRectDimensions(key);
    }
}

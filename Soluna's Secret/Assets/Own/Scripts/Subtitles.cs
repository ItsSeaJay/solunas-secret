using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Subtitles : MonoBehaviour
{
    private TextMeshProUGUI subtitlesTextMeshProUGUI;
    private const float MAXDISPLAYTIME = 2.0f;
    private float displayTime = 0;

    void Start ()
	{
        subtitlesTextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        subtitlesTextMeshProUGUI.text = "";
	}

	void Update ()
	{
        displayTime -= Time.deltaTime;
        displayTime = Mathf.Clamp(displayTime, 0, MAXDISPLAYTIME);
        
        if (displayTime <= 0)
        {
            subtitlesTextMeshProUGUI.text = "";
        }
	}

    public void SetSubtitle(string subtitle)
    {
        displayTime = MAXDISPLAYTIME;
        subtitlesTextMeshProUGUI.text = subtitle;
    }
}

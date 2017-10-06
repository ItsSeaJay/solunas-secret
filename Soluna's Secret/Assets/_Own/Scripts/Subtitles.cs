
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Subtitles
* Description: N/a
* Author(s):   Callum John
* Date:        10/6/2017 10:42:48 AM
******************************************************************************/

// Libraries
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
	} // End void Start ()

	void Update ()
	{
        displayTime -= Time.deltaTime;
        displayTime = Mathf.Clamp(displayTime, 0, MAXDISPLAYTIME);

        if (displayTime <= 0)
        {
            subtitlesTextMeshProUGUI.text = "";
        } // End if displayTime <= 0
	} // End void Update ()

    public void SetSubtitle(string subtitle)
    {
        displayTime = MAXDISPLAYTIME;
        subtitlesTextMeshProUGUI.text = subtitle;
    }
} // End public class Subtitles : MonoBehaviour

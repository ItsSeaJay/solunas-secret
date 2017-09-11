
/******************************************************************************
* Product:     Soluna's Secret
* Script:      PixelBoy
* Description: N/a
* Author(s):   Callum John
* Date:        9/11/2017 9:19:26 AM
******************************************************************************/

// Libraries
using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/PixelBoy")]
[RequireComponent(typeof(Camera))]
public class PixelBoy : MonoBehaviour
{
    [SerializeField]
    private int width = 160,
                height = 144;

    protected void Start()
    {
        if (!SystemInfo.supportsImageEffects)
        {
            enabled = false;
            return;
        } // End if (!SystemInfo.supportsImageEffects)
    } // End protected void Start()

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        source.filterMode = FilterMode.Point;

        RenderTexture buffer = RenderTexture.GetTemporary(width, height, -1);
        buffer.filterMode = FilterMode.Point;

        Graphics.Blit(source, buffer);
        Graphics.Blit(buffer, destination);

        RenderTexture.ReleaseTemporary(buffer);
    } // End void OnRenderImage()
} // End public class PixelBoy : MonoBehaviour

// Using
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requirement(s)
[RequireComponent(typeof(Light))]

public class FlickeringLight : MonoBehaviour
{
    [SerializeField]
    private float minRange, maxRange, flickerRate;

    private Light lightToFlicker;
    private float rangeDifference;

	void Start ()
	{
        lightToFlicker = GetComponent<Light>();

        Debug.Assert(maxRange > minRange);

        rangeDifference = maxRange - minRange;
	} // End void Start ()

	void Update ()
	{
        if (lightToFlicker.enabled)
        {
            switch (lightToFlicker.type)
            {
                case LightType.Spot:
                    lightToFlicker.spotAngle += Random.Range(-rangeDifference, rangeDifference) * Time.deltaTime * flickerRate;
                    lightToFlicker.spotAngle = Mathf.Clamp(lightToFlicker.spotAngle, minRange, maxRange);
                    break;
                case LightType.Directional:
                    break;
                case LightType.Point:
                    lightToFlicker.range += Random.Range(-rangeDifference, rangeDifference) * Time.deltaTime * flickerRate;
                    lightToFlicker.range = Mathf.Clamp(lightToFlicker.range, minRange, maxRange);
                    break;
                case LightType.Area:
                    break;
                default:
                    break;
            }
        }
    } // End void Update ()
} // End public class FlickeringLight

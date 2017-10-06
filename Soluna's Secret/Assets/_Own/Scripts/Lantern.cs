
/******************************************************************************
* Product:     Soluna's Secret
* Script:      Lantern
* Description: N/a
* Author(s):   Callum John
* Date:        9/15/2017 2:45:14 PM
******************************************************************************/

// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requirement(s)
[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Pickup))]

public class Lantern : MonoBehaviour
{
    [SerializeField]
    private Projector       lanternProjector;
    [SerializeField]        
    private Light           lanternLight;
    [SerializeField]        
    private CapsuleCollider lightCollider;
    [SerializeField]
    private FlickeringLight flickeringLight;
    [SerializeField]
    private AnimationCurve  onCurve, offCurve;
    [SerializeField]
    private float transitionSpeed = 4.0f;
    [SerializeField]
    private float lanternLightRangeMax = 3.66f,
                  lanternProjectorOrthographicSizeMax = 4.0f,
                  lightColliderRadiusMax = 18.5f;

    private Pickup pickup;

    private bool isLit = true;
    private float targetLightRange,
                  targetProjectorOrthographicSize,
                  targetColliderRadius;

	void Start ()
	{
        Debug.Assert(lanternProjector != null);
        Debug.Assert(lanternLight     != null);
        Debug.Assert(lightCollider    != null);

        pickup = GetComponent<Pickup>();

        flickeringLight.enabled = isLit;

        if (isLit)
        {
            targetLightRange = lanternLightRangeMax;
            lanternLight.range = targetLightRange;

            targetProjectorOrthographicSize = lanternProjectorOrthographicSizeMax;
            lanternProjector.orthographicSize = targetProjectorOrthographicSize;

            targetColliderRadius = lightColliderRadiusMax;
            lanternProjector.orthographicSize = targetProjectorOrthographicSize;
        } // End if (isLit)
        else
        {
            targetLightRange = 0.0f;
            lanternLight.range = targetProjectorOrthographicSize;

            targetProjectorOrthographicSize = 0.0f;
            lanternProjector.orthographicSize = targetProjectorOrthographicSize;

            targetColliderRadius = 0.0f;
            lanternProjector.orthographicSize = targetProjectorOrthographicSize;
        } // End else (isLit)
	} // End void Start ()

	void Update ()
	{
        LerpLanternLight();

        if (pickup.Held)
        {
            if (Input.GetButtonDown("Lantern") &&
                Player.Instance.CurrentState != Player.State.Frozen)
            {
                Toggle();
            } // End if (Input.GetKeyDown("Lantern"))
        } // End if (pickup.Held)
    } // End void Update ()

    void LerpLanternLight()
    {
        if (isLit)
        {
            targetLightRange = lanternLightRangeMax;
            targetProjectorOrthographicSize = lanternProjectorOrthographicSizeMax;

            lanternLight.range = Mathf.Lerp(lanternLight.range, targetLightRange, onCurve.Evaluate(Time.deltaTime * transitionSpeed));
            lanternProjector.orthographicSize = Mathf.Lerp(lanternProjector.orthographicSize, targetProjectorOrthographicSize, onCurve.Evaluate(Time.deltaTime * transitionSpeed));
        } // End if (isLit)
        else
        {
            targetLightRange = 0.0f;
            targetProjectorOrthographicSize = 0.0f;

            lanternLight.range = Mathf.Lerp(lanternLight.range, targetLightRange, offCurve.Evaluate(Time.deltaTime * transitionSpeed));
            lanternProjector.orthographicSize = Mathf.Lerp(lanternProjector.orthographicSize, targetProjectorOrthographicSize, offCurve.Evaluate(Time.deltaTime * transitionSpeed));
        } // End else (isLit)
    } // End void LerpLanternLight

    private void Toggle()
    {
        isLit = !isLit;

        flickeringLight.enabled = !flickeringLight.enabled;
        lightCollider.enabled = !lightCollider.enabled;
    } // End private void Toggle()
} // End public class Lantern : MonoBehaviour

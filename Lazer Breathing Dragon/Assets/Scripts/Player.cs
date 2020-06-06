using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip ("In ms^-1")][SerializeField] float speed = 4f;
    [Tooltip("In m")] [SerializeField] float xScreenEdge; //from center
    [Tooltip("In m")] [SerializeField] float yScreenEdge; //from center

    [SerializeField] float positionPitchFactor = -2f; //when ship reaches y limit the pitch value is about double the y value
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] float positionYawFactor = 2f;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * speed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedNewXPos = Mathf.Clamp(rawNewXPos, -xScreenEdge, xScreenEdge);

        float yOffset = yThrow * speed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedNewYPos = Mathf.Clamp(rawNewYPos, -yScreenEdge, yScreenEdge);

        transform.localPosition = new Vector3(clampedNewXPos, transform.localPosition.y, transform.localPosition.z); //horizontal movement

        transform.localPosition = new Vector3(transform.localPosition.x, clampedNewYPos, transform.localPosition.z); //vertical movement
    }

    private void ProcessRotation()
    {

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}

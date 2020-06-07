using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip ("In ms^-1")][SerializeField] float speed = 4f;
    [Tooltip("In m")] [SerializeField] float xScreenEdge; //from center
    [Tooltip("In m")] [SerializeField] float yScreenEdge; //from center

    [Header("Screen-position Based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Control-throw Based")]
    [SerializeField] float positionPitchFactor = -2f; //Observed in editor: when ship reaches y limit the pitch value is about double the y value
    [SerializeField] float controlRollFactor = -20f;

    [SerializeField] GameObject[] lasers;

    float xThrow, yThrow;

    bool allowMovement = true;

    // Update is called once per frame
    void Update()
    {
        if (allowMovement)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    void DisableMovement() //Beware: called by string reference
    {
        allowMovement = false;
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


    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateLasers();
        }

        else
        {
            DeactivateLasers();
        }
    }

    private void ActivateLasers()
    {
        foreach (GameObject lazer in lasers)
        {
            lazer.SetActive(true);
        }
    }

    private void DeactivateLasers()
    {
        foreach (GameObject lazer in lasers)
        {
            lazer.SetActive(false);
        }
    }

}

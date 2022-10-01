using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [Header("Orbit")]
    public bool orbit = true;
    public Transform centre;
    public float radius;
    public float orbitSpeed = 15f;
    public float angle;
    float radian;

    [Header("Rotate")]
    public bool rotate = true;
    public bool syncRotations = true;
    public bool syncSpeeds = true;
    public float rotationSpeed = 15f; // looks the best if is the same as orbitSpeed
    public float angleRotation;

    private void Update()
    {
        if (syncSpeeds) rotationSpeed = orbitSpeed; // Sync Speeds
        if (syncRotations && rotate && orbit) angleRotation = angle; // Sync Rotations

        if (Application.isPlaying) // check if script is running in editor mode or in game, if in game rotate object
        {
            if (orbit) angle += orbitSpeed * Time.deltaTime;
            else if (rotate) angleRotation += rotationSpeed * Time.deltaTime;
        }
        checkAngles();

        radian = angle * (Mathf.PI / 180); // convert degrees to radians

        float x = (Mathf.Cos(radian) * radius) + centre.position.x; // calculate x position of orbiting object
        float y = (Mathf.Sin(radian) * radius) + centre.position.y; // calculate y position of orbiting object

        transform.position = new Vector2(x, y); // apply new position to orbiting object

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angleRotation); // apply new rotation to rotating object
    }

    void checkAngles()
    {
        if (angle >= 360) angle = 0; // keep angle in -360/360 range
        else if (angle <= -360) angle = 0;

        if (angleRotation >= 360) angleRotation = 0; // keep angle in -360/360 range
        else if (angleRotation <= -360) angleRotation = 0;

    }
}

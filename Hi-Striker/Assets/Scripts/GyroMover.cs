using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroMover : MonoBehaviour
{
    private Vector3 xyz = new Vector3(180.0f, 180.0f, 180.0f);
    private Vector3 frameSum = new Vector3(0,0,0);
    private static int avgFrames = 30;
    private int actualFrame = 0;
    private Vector3[] gyroFrames = new Vector3[avgFrames];

    void Start()
    {
        for (int i = 0; i < avgFrames; i++) {
            gyroFrames[i] = Input.gyro.attitude.eulerAngles;
            frameSum += Input.gyro.attitude.eulerAngles;
        }
    }

    void Update()
    {
        addFrame();
        this.transform.eulerAngles = (frameSum/avgFrames)-new Vector3(90.0f, 0.0f, 0.0f);
    }

    private void addFrame()
    {
        frameSum -= gyroFrames[actualFrame];
        gyroFrames[actualFrame] = Input.gyro.attitude.eulerAngles;
        frameSum += gyroFrames[actualFrame];
        actualFrame = (actualFrame + 1) % avgFrames;
    }
}

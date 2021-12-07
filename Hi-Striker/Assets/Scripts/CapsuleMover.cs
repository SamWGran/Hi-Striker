using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMover : MonoBehaviour
{
    private Vector3 xyz = new Vector3(180.0f, 180.0f, 180.0f);
    private Vector3 frameSum = new Vector3(0,0,0);
    private static int avgFrames = 30;
    private int actualFrame = 0;
    private Vector3[] accelFrames = new Vector3[avgFrames];

    void Start()
    {
        for (int i = 0; i < avgFrames; i++) {
            accelFrames[i] = Input.acceleration;
            frameSum += Input.acceleration;
        }
    }

    void Update()
    {
        addFrame();
        this.transform.eulerAngles = Vector3.Scale(xyz, frameSum/avgFrames);
    }

    private void addFrame()
    {
        frameSum -= accelFrames[actualFrame];
        accelFrames[actualFrame] = Input.acceleration;
        frameSum += accelFrames[actualFrame];
        actualFrame = (actualFrame + 1) % avgFrames;
    }
}

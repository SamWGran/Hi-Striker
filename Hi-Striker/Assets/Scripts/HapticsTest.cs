using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AndroidNativeCore;

public class HapticsTest : MonoBehaviour
{
    void Update()
    {
        Touch touch = Input.GetTouch(0);
        if (Input.touchCount > 0) {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    AddHaptics.Vibrate(300);
                    break;
                default: 
                    break;
            }
       }
    }
}

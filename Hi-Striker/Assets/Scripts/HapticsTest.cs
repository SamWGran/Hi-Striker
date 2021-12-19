using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AndroidNativeCore;

public class HapticsTest : MonoBehaviour
{
long[] pattern = new long[] {300, 900};

    // Start is called before the first frame update
    void Start()
    {
        AddHaptics.Vibrate(300);
        AddHaptics.Cancel();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

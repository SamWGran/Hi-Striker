using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMover : MonoBehaviour
{

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(2.0f, 0.0f, 0.0f, Space.Self);
    }
}

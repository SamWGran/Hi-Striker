using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroText : MonoBehaviour
{
    [SerializeField]
    private Text assignedText;

    void Awake()
    {
        Gyroscope phoneGyro = Input.gyro;
        phoneGyro.enabled = true;
    }
    void Update()
    {
        assignedText.text = Input.gyro.attitude.eulerAngles.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroHandler : MonoBehaviour
{
    Quaternion gyro;
    Quaternion offset;

    void Awake() {
        Gyroscope phoneGyro = Input.gyro;
        phoneGyro.enabled = true;
    }

    void Update() {
        gyro = GyroToUnity(Input.gyro.attitude);
        Vector3 removeZ = gyro.eulerAngles;
        gyro = Quaternion.Euler(removeZ.x, 0, removeZ.y);
    }

    private static Quaternion GyroToUnity(Quaternion q) {
        return new Quaternion(q.x, q.y, q.z, -q.w);
    }
}

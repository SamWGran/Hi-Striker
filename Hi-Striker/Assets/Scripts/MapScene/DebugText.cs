using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    public Text debugger;
    public static DebugText instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
        debugger = GetComponent<Text>();
    }
    public void debugText(string message) {
        debugger.text = message;
    }
}

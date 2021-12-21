using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEditor : MonoBehaviour
{
    [SerializeField]
    private Text assignedText;
    

    void Update()
    {
        assignedText.text = Input.acceleration.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StoreData : MonoBehaviour
{
    public static int frames = 100;
    private Vector3[] results = new Vector3[frames];
    private int index = 0;
    private string filepath;
    private bool recordStarted = false, recordFinished = false;

    void Awake()
    {
        filepath = Application.persistentDataPath + "/dataMM.txt";
    }

    void Update()
    {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case (TouchPhase.Began):
                    recordStarted = true;
                    GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Record Started");
                    break;
                case (TouchPhase.Ended):
                    recordFinished = true;
                    WriteFile();
                    break;
                default: 
                    break;
            }
        }

        if (recordStarted && !recordFinished) {
            results[index] = Input.acceleration;
            index++;
        }
    }

    void WriteFile()
    {
        using (StreamWriter sw = File.CreateText(filepath))
        {
            string line;
            foreach (Vector3 vector in results) {
                sw.WriteLine(vector);
                line = vector.x + ',' + vector.y + "," + vector.z;
                sw.WriteLine(line);
            }
        }
    }
}

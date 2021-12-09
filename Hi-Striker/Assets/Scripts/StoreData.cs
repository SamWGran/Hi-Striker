using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;

public class StoreData : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static int frames = 100;
    private Vector3[] results = new Vector3[frames];
    private int index = 0;
    private string filepath;
    private bool recordStarted = false, recordFinished = false;

    void Awake()
    {
        filepath = Application.persistentDataPath + "/" + PlayerData.playerName + ".txt";
    }

    void Update()
    {
        if (recordStarted && !recordFinished) {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Record Started");
            results[index] = Input.acceleration;
            index++;
        } else if (recordStarted && recordFinished) {
            WriteFile();
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        recordStarted = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        recordFinished = true;
    }

    void WriteFile()
    {
        using (StreamWriter sw = File.CreateText(filepath))
        {
            string line;
            foreach (Vector3 vector in results) {
                line = vector[0].ToString() + ',' + vector[1].ToString() + "," + vector[2].ToString();
                sw.WriteLine(line);
            }
        }
    }
}

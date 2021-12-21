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
            if (index < frames)
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

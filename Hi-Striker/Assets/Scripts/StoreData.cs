using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StoreData : MonoBehaviour
{
    private Vector3[] results = new Vector3[500];
    private int index = 0;
    private string filepath;

    void Awake()
    {
        filepath = Application.persistentDataPath + "/dataMM.txt";
    }

    void Update()
    {
        results[index] = Input.acceleration;
        index++;
        if (index <= 500) {
            WriteFile();
            Debug.Log(results);
        }
    }

    void WriteFile()
    {
        if (!File.Exists(filepath))
        {
            using (StreamWriter sw = File.CreateText(filepath))
            {
                foreach (Vector3 line in results) {
                    sw.WriteLine(line.ToString());
                }
            }
        }
    }
}

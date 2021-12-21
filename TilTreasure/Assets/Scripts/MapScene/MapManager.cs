using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MapManager : MonoBehaviour
{
    //Variables for drawing on screen
    [SerializeField]
    Sprite[] maps;
    [SerializeField]
    GameObject cross;
    private Image map;
    private float screenX, screenY;
    private RectTransform canvasRect;

    // Gyroscope related variables
    Quaternion gyro;
    Quaternion offset;
    Vector2 coords = new Vector2();
    private float angleSpan = 180;

    // Game variables
    private Vector2[] points = new Vector2[3];
    private bool sound, haptics;
    private int currentPoint = -1;
    private AudioSource successAudio;

    // Data storage variables
    private string filepath;
    private StreamWriter sw;
    private float time;
    public bool isRecording;

    void Awake() {
        map = GetComponent<Image>();
        map.sprite = maps[Random.Range(0, maps.Length-1)];
        successAudio = gameObject.GetComponent<AudioSource>();

        sound = PlayerData.sound;
        haptics = PlayerData.haptics;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (isRecording) {
            string name = PlayerData.playerName;
            if (sound) {
                name = name + "_haptics";
            }
            if (haptics) {
                name = name + "_sound";
            }
            filepath = Application.persistentDataPath + "/" + name + ".txt";
            sw = File.CreateText(filepath);
            time = Time.time;
        }
        canvasRect = cross.transform.parent.gameObject.GetComponent<Canvas>().GetComponent<RectTransform>();
        screenX = canvasRect.rect.width;
        screenY = canvasRect.rect.height;
        StartInstance();
    }

    void Start() {
        Gyroscope phoneGyro = Input.gyro;
        phoneGyro.enabled = true;
        SetupPoints();
    }

    private void SetupPoints() {
        if (sound && haptics) {
            points[0] = new Vector2(0.2f, 0.9f);
            points[1] = new Vector2(0.3f, 0.7f);
            points[2] = new Vector2(0.8f, 0.2f);
        } else if (sound) {
            points[0] = new Vector2(0.3f, 0.8f);
            points[1] = new Vector2(0.4f, 0.7f);
            points[2] = new Vector2(0.8f, 0.6f);
        } else {
            points[0] = new Vector2(0.7f, 0.2f);
            points[1] = new Vector2(0.2f, 0.6f);
            points[2] = new Vector2(0.9f, 0.7f);
        }
    }

    // Used when a  point is found
    private void StartInstance() {
        currentPoint++;
        if (currentPoint >= points.Length) {
            time = Time.time - time;
            if (isRecording) {
                sw.WriteLine("Time: " + time.ToString());
                sw.WriteLine("Name: " + PlayerData.playerName);
                sw.WriteLine("Haptics: " + PlayerData.haptics.ToString());
                sw.WriteLine("Sound: " + PlayerData.sound.ToString());
                // sw.WriteLine("Order: " + PlayerData.order.ToString());
                sw.Close();
            }
            PlayerData.LoadSuccess();
        }
        map.sprite = maps[Random.Range(0, maps.Length-1)];
        sw.WriteLine("Round nr: " + (currentPoint+1).ToString() + " below");
        ProximityPlayer.instance.StartNewPlayer();
    }

     void Update() {
        if (ProximityPlayer.instance.playingGame == false) {
            SetScreenPos(0.5f, 0.5f);
        } else {
            gyro = GyroToUnity(Input.gyro.attitude);
            Vector3 removeZ = gyro.eulerAngles;
            gyro = Quaternion.Euler(removeZ.x, 0, removeZ.y);

            // Stores correct orientations
            if (gyro.eulerAngles.x > 180) {
                coords.y = gyro.eulerAngles.x - 360;
            } else {
                coords.y = gyro.eulerAngles.x;
            }
            if (gyro.eulerAngles.z > 180) {
                coords.x = gyro.eulerAngles.z - 360;
            } else {
                coords.x = gyro.eulerAngles.z;
            }
            //Normalizes angles and sets to span 0-1
            coords *= (1/angleSpan);
            coords += new Vector2(0.5f, 0.5f);
            coords.x = 1.0f - coords.x;

            SetScreenPos(coords.x, coords.y);
            float time = GetDistanceTime(coords);
            if (time < 0.2f) {
                successAudio.Play();
                StartInstance();
            }
            if (isRecording) {
                string line = coords.x.ToString() + ", " + coords.y.ToString();
                sw.WriteLine(line);
            }
            ProximityPlayer.instance.timeBetweenFeedback = GetDistanceTime(coords);
        }
    }

    private float GetDistanceTime(Vector2 coords) {
        Vector2 scaledCoords, scaledPoint, scalar;
        scalar = new Vector2(screenX, screenY);
        scaledCoords = Vector2.Scale(coords, scalar);
        scaledPoint = Vector2.Scale(points[currentPoint], scalar);

        float distance = Vector2.Distance(scaledCoords, scaledPoint);
        distance /= Mathf.Sqrt(screenX*screenX + screenY*screenY);
        distance *= 1.9f; distance += 0.1f;
        return distance;
    }

    private void SetScreenPos(float xPercentage, float yPercentage) {
        float x = screenX * xPercentage;
        float y = screenY * yPercentage;
        Vector3 pos = cross.GetComponent<RectTransform>().anchoredPosition;
        pos.x = x; pos.y = y;
        cross.GetComponent<RectTransform>().anchoredPosition = pos;
    }

    private static Quaternion GyroToUnity(Quaternion q) {
        return new Quaternion(q.x, q.y, q.z, -q.w);
    }
}

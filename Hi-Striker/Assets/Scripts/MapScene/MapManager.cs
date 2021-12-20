using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    Sprite[] maps;
    [SerializeField]
    GameObject cross;

    private Image map;
    private Vector3 phoneTilt;
    private float screenX, screenY;
    private RectTransform canvasRect;

    void Awake() {
        map = GetComponent<Image>();
        map.sprite = maps[Random.Range(0, maps.Length-1)];
        canvasRect = cross.transform.parent.gameObject.GetComponent<Canvas>().GetComponent<RectTransform>();
        screenX = canvasRect.rect.width;
        screenY = canvasRect.rect.height;
        Gyroscope phoneGyro = Input.gyro;
        phoneGyro.enabled = true;
    }

    void Update() {
        phoneTilt = Input.gyro.attitude.eulerAngles;

        DebugText.instance.debugText(phoneTilt.ToString());

        if (phoneTilt.x < 180) {
            phoneTilt.x = (phoneTilt.x / 180) + 0.5f;
        } else {
            phoneTilt.x = (phoneTilt.x - 180.0f)/180.0f;
        }
        if (phoneTilt.y < 180) {
            phoneTilt.y = (phoneTilt.y / 180) + 0.5f;
        } else {
            phoneTilt.y = (phoneTilt.y - 180.0f)/180.0f;
        }

        setScreenPos(phoneTilt.x, phoneTilt.y);
        // setScreenPos(0.5f, 0.5f);
    }

    private void setScreenPos(float xPercentage, float yPercentage) {
        float x = screenX * xPercentage;
        float y = screenY * yPercentage;
        Vector3 pos = cross.GetComponent<RectTransform>().anchoredPosition;
        pos.x = x; pos.y = y;
        cross.GetComponent<RectTransform>().anchoredPosition = pos;
    }
}

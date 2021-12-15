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
    }

    void Update() {
        phoneTilt = Input.gyro.attitude.eulerAngles;
        DebugText.instance.debugText(phoneTilt.ToString());
        setScreenPos(phoneTilt.y, phoneTilt.x);
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

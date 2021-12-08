using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerName;
    [SerializeField]
    private Text PlayerNameText;
    
    void Update()
    {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case (TouchPhase.Ended):
                    if (PlayerNameText.text == "") {
                        MenuManager.instance.Shake(PlayerName);
                    } else {
                        MenuManager.instance.LoadGame(PlayerNameText.text);
                    }
                    break;
                default: 
                    break;
            }
        }
    }
}
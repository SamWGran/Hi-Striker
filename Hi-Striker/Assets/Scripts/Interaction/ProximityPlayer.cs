using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource player;
    public float timeBetweenFeedback = 1.0f;
    public bool haptics, sound, playingGame;
    public static ProximityPlayer instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    void Start()
    {
        haptics = PlayerData.haptics;
        sound = PlayerData.sound;
    }

    public void StartNewPlayer() {
        playingGame = false;
        StopCoroutine(Player());
        StartCoroutine(PrePlayer());
    }

    private IEnumerator PrePlayer() {
        for(int i = 0; i < 3; i++) {
            yield return  new WaitForSeconds(1.0f);
        }
        playingGame = true;
        StartCoroutine(Player());
    }
    private IEnumerator Player()
    {

        while (playingGame){
            if (sound) {
                player.Play();
            }
            if (haptics) {
                AddHaptics.Vibrate(100);
            }
            yield return new WaitForSeconds(timeBetweenFeedback);
        }

    }
}

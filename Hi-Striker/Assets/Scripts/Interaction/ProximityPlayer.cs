using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource player;
    public float timeBetweenFeedback = 1.0f;
    private bool haptics, sound, playingGame = true;
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
        haptics = true;
        sound = true;
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

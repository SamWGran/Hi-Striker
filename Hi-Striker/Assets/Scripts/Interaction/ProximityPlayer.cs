using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource player;
    private float timeBetweenFeedback = 1.0f;
    private bool haptics, sound, playingGame = true;

    void Start()
    {
        haptics = false;
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
                AddHaptics.Vibrate(200);
            }
            yield return new WaitForSeconds(timeBetweenFeedback);
        }

    }
}

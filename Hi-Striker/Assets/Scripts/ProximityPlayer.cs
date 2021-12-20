using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityPlayer : MonoBehaviour
{
    private float timeBetweenFeedback = 0.5f;
    private bool haptics, sound, playingGame = true;

    void Start()
    {
        haptics = PlayerData.haptics;
        sound = PlayerData.sound;
        Player();
    }

    private IEnumerator Player()
    {

        while (playingGame){
            if (sound) {
                // Play sound
            }
            if (haptics) {
                AddHaptics.Vibrate(200);
            }
            yield return new WaitForSeconds(timeBetweenFeedback);
        }

    }
}

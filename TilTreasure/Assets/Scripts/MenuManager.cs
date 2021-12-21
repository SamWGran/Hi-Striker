using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField]
    private GameObject TestObj, playerName;
    [SerializeField]
    private Text playerNameText;
    [SerializeField]
    private Button playGameButton;
    [SerializeField]
    private Toggle HapticsToggle, SoundToggle;
    [SerializeField]
    private Dropdown dropdown;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    void Start()
    {
        playGameButton.onClick.AddListener(LoadGame);
    }

    public void Shake(GameObject obj)
    {
        StartCoroutine(OnShake(obj, 30));
    }

    private static IEnumerator OnShake(GameObject obj, int frames)
    {
        Vector3 startTransform = obj.transform.position;
        Vector3 newTransform = obj.transform.position;

        for (int i = 0; i < frames; i++) {
            newTransform.x = startTransform.x + Mathf.Sin(Time.time * 100) * 0.02f;
            newTransform.y = startTransform.y + Mathf.Sin(Time.time * 250) * 0.02f;
            obj.transform.position = newTransform;
            yield return new WaitForFixedUpdate();
        }

        obj.transform.position = startTransform;
    }

    private void LoadGame()
    {
        if (playerNameText.text == "") {
            MenuManager.instance.Shake(playerName);
            Debug.Log("Haptics: " + HapticsToggle.isOn);
            Debug.Log("Sound: " + SoundToggle.isOn);
        } else {
            PlayerData.LoadNewGame(playerNameText.text, dropdown.captionText.text, HapticsToggle.isOn, SoundToggle.isOn);
        }
    }
}
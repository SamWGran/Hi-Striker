using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField]
    private GameObject TestObj;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("w")) {
            Shake(TestObj);
        }
    }

    public void Shake(GameObject obj)
    {
        StartCoroutine(OnShake(obj, 30));
    }

    private static IEnumerator OnShake(GameObject obj, int frames)
    {
        Vector3 startTransform = obj.transform.position;
        Vector3 newTransform = obj.transform.position;
        Debug.Log("W2");

        for (int i = 0; i < frames; i++) {
            newTransform.x = startTransform.x + Mathf.Sin(Time.time * 100) * 0.02f;
            newTransform.y = startTransform.y + Mathf.Sin(Time.time * 250) * 0.02f;
            obj.transform.position = newTransform;
            yield return new WaitForFixedUpdate();
        }

        obj.transform.position = startTransform;
    }

    public void LoadGame(string PlayerName)
    {
        PlayerData.PlayerName = PlayerName;
        SceneManager.LoadScene("GameScene");
    }
}

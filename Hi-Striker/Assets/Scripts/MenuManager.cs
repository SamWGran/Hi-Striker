using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static void Shake(GameObject obj)
    {

    }

    public static void LoadGame(string PlayerName)
    {
        PlayerData.PlayerName = PlayerName;
        SceneManager.LoadScene("GameScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlayerData
{
    public static string playerName { get; set; }
    public static bool haptics, sound;

    public static void LoadNewGame(string name, int order) {
        PlayerData.playerName = name;
        PlayerData.SetOrder(order);
        SceneManager.LoadScene("MapScene");
    }

    public static void SetOrder(int order) {
        PlayerData.haptics = true;
        PlayerData.sound = true;
    }
}

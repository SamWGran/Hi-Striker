using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlayerData
{
    public static string playerName { get; set; }
    public static bool haptics { get; set; }
    public static bool sound { get; set; }
    public static string order { get; set; }

    public static void LoadNewGame(string name, string order, bool haptics, bool sound) {
        PlayerData.playerName = name;
        PlayerData.order = order;
        PlayerData.haptics = haptics;
        PlayerData.sound = sound;
        SceneManager.LoadScene("MapScene");
    }

    public static void LoadMenu() {
        SceneManager.LoadScene("MenuScene");
    }

    public static void LoadSuccess() {
        SceneManager.LoadScene("SuccessScene");
    }
}

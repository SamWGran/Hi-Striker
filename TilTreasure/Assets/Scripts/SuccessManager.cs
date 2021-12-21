using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessManager : MonoBehaviour
{
    [SerializeField]
    private Button loadMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        loadMenuButton.onClick.AddListener(LoadMenu);
    }

    private void LoadMenu(){
        PlayerData.LoadMenu();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class InfoTabManager : MonoBehaviour
{
    public GameObject duze_info;   // UI вкладка (duze_info)
    public GameObject Player;  // Персонаж

    private bool isInfoOpen = false;

    // Вызывается, например, при нажатии на кнопку
    public void ToggleInfoTab()
    {
        Debug.Log("TAB TOGGLED!");
        isInfoOpen = !isInfoOpen;

        duze_info.SetActive(isInfoOpen);
        Player.SetActive(!isInfoOpen);
    }
   

}
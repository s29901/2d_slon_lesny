using UnityEngine;

public class SceneEntryHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject duze_info;

    void Start()
    {
        /* восстановим позицию
        if (PlayerMemory.HasSavedPosition != null && player != null)
        {
            player.transform.position = PlayerMemory.LastPosition;
        } */

        // спрячем вкладку, если она случайно активна
        if (duze_info != null)
        {
            duze_info.SetActive(false);
        }
    }
}
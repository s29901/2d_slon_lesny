using UnityEngine;

public class PlayerMemory : MonoBehaviour
{
    public static Vector3 LastPosition;
    public static bool HasSavedPosition = false;

    // Вызывай это перед сменой сцены
    public static void Save(Vector3 pos)
    {
        LastPosition = pos;
        HasSavedPosition = true;
    }
}
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance; // глобальный доступ

    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D eyeCursor;
    [SerializeField] private Vector2 hotSpot = Vector2.zero;

    void Awake()
    {
        // Удалить дубликаты
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SetDefaultCursor();
    }

    public void SetDefaultCursor()
    {
        Cursor.SetCursor(defaultCursor, hotSpot, CursorMode.Auto);
    }

    public void SetEyeCursor()
    {
        Cursor.SetCursor(eyeCursor, hotSpot, CursorMode.Auto);
    }
}
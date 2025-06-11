using UnityEngine;

public class BonePuzzleManager : MonoBehaviour
{
    [Tooltip("Массив ваших фрагментов")]
    public GameObject[] boneSlots;

    private int _collectedCount = 0;

    void Start()
    {
        foreach (var slot in boneSlots)
            slot.SetActive(false);
    }

    public void CollectBone(int index, GameObject pickedObject)
    {
        if (index < 0 || index >= boneSlots.Length) return;
        boneSlots[index].SetActive(true);
        pickedObject.SetActive(false);

        _collectedCount++;
        Debug.Log($"[Puzzle] Собрано {_collectedCount}/{boneSlots.Length}");

        if (_collectedCount == boneSlots.Length)
        {
            // Сообщаем GameManager, что пазл завершён
            GameManager.Instance.MarkPuzzleCompleted();
            Debug.Log("[Puzzle] Пазл собран! Теперь вручную нажмите кнопку «Назад в музей».");
        }
    }
}
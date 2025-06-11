using UnityEngine;

public class BonePuzzleManager : MonoBehaviour
{
    [Tooltip("Массив cien_1…cien_6 — заранее нарисованных фрагментов")]
    public GameObject[] boneSlots;

    void Start()
    {
        // прячем все cien_… в начале
        foreach (var slot in boneSlots)
            slot.SetActive(false);
    }

    public void CollectBone(int index, GameObject pickedObject)
    {
        if (index < 0 || index >= boneSlots.Length)
        {
            Debug.LogError($"CollectBone: неверный индекс {index}");
            return;
        }

        Debug.Log($"CollectBone: показываем slot[{index}] и прячем {pickedObject.name}");
        boneSlots[index].SetActive(true);
        pickedObject.SetActive(false);
    }
}
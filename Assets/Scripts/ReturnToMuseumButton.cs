using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ReturnToMuseumButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();

        // Удаляем все старые (инспекторные) подписки
        _button.onClick.RemoveAllListeners();

        // Подписываем кнопку на метод живого GameManager.Instance
        _button.onClick.AddListener(() =>
        {
            GameManager.Instance.ReturnToMuseum();
        });
    }
}
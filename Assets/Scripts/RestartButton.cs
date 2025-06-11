using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [Tooltip("Индекс стартовой сцены в Build Settings (обычно 0)")]
    public int initialSceneBuildIndex = 2;

    /// <summary>
    /// Загружает самую первую сцену по заданному индексу.
    /// </summary>
    public void RestartToFirstScene()
    {
        SceneManager.LoadScene(initialSceneBuildIndex);
    }
}
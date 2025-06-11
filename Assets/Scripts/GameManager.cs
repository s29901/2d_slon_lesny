using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Настройки костей")]
    public int totalBonesToCollect = 5;
    public string boneCollectionSceneName = "2_scene";

    [Header("Настройки появления слона")]
    public string elephantSceneName = "SampleScene";
    public GameObject elephantPrefab;

    public int BonesCount { get; private set; }

    // Флаг, указывающий, что мы действительно собрали кости и должны спавнить слона
    private bool _readyToSpawnElephant = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    /// <summary>
    /// Вызывается кнопкой-костью при клике.
    /// </summary>
    public void AddBone(int amount = 1)
    {
        // работаем только в сцене сбора
        if (SceneManager.GetActiveScene().name != boneCollectionSceneName)
            return;

        BonesCount += amount;
        Debug.Log($"[GM] Костей собрано: {BonesCount}/{totalBonesToCollect}");

        if (BonesCount >= totalBonesToCollect)
        {
            // ставим флаг и переходим в SampleScene
            _readyToSpawnElephant = true;
            Debug.Log("[GM] Достигли порога костей, загружаем SampleScene");
            SceneManager.LoadScene(elephantSceneName);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"[GM] Сцена загружена: {scene.name} (BonesCount={BonesCount}, ready={_readyToSpawnElephant})");

        // Спавним только если это SampleScene **и** мы пришли из сбора
        if (scene.name == elephantSceneName && _readyToSpawnElephant)
        {
            Vector3 spawnPos = new Vector3(922f, 737f, -6f);
            Debug.Log($"[GM] Спавню слона в {spawnPos}");
            Instantiate(elephantPrefab, spawnPos, Quaternion.identity);

            // сбросим флаг, чтобы при следующем заходе в SampleScene (например, по кнопке "Начать игру") слон не появлялся
            _readyToSpawnElephant = false;
        }
    }
}

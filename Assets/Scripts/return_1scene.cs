using UnityEngine;
using UnityEngine.SceneManagement;

public class return_1scene : MonoBehaviour
{
    public GameObject player;

    public void NextScene()
    {
        if (player != null)
        {
            PlayerMemory.Save(player.transform.position);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
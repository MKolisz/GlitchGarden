using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    int currentSceneIndex;
    int timeToWait = 3;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitAndLoadNextScene());
        }
    }

    public IEnumerator WaitAndLoadNextScene()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public IEnumerator WaitAndLoadGameOver()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadGameOver();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex+1);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over Screen");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }
}

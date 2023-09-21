using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float delay = 2f;
    ScoreKeeper scoreKeeper;
    public void LoadGame() {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("MainScene");
    }

    void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGameOver() {
        StartCoroutine(WaitAndLoad("ExitMenu", delay));
    }

    public void LoadMainMenu() {
        StartCoroutine(WaitAndLoad("EnterMenu", delay));
    }

    public void QuitGame() {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static ScoreKeeper instance;
    
    int score = 0;

    void Awake() {
        SetUpSingleton();
    }

    void SetUpSingleton() {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore() {
       return score;
    }

    public void ModifyScore(int scoreValue) {
        score += scoreValue;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log("Score: " + score);
    }

    public void ResetScore() {
        score = 0;
    }
}

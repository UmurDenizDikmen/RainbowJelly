using System.Collections;
using System.Collections.Generic;
using System.Data;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public int currentLevel;
    public int levelNumber;

    public static SaveManager instance;
    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("Level"))
        {
            currentLevel = PlayerPrefs.GetInt("Level");
            levelNumber = PlayerPrefs.GetInt("levelnumber");

        }
        else
        {
            currentLevel = PlayerPrefs.GetInt("Level", 0);
            levelNumber = PlayerPrefs.GetInt("levelnumber", 1);


        }
    }
    private void Start()
    {
        GameManager.OnStateChanged += OnStateChanged;

    }
    void OnDisable()
    {
        GameManager.OnStateChanged -= OnStateChanged;
    }
    public void NextLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private void OnStateChanged(GameState State)
    {
        switch (State)
        {

            case GameState.Success:
                currentLevel++;
                levelNumber++;
                if (currentLevel > 5)
                {
                    int Index = UnityEngine.Random.Range(1, 6);
                    currentLevel = Index;
                }
                PlayerPrefs.SetInt("Level", currentLevel);
                PlayerPrefs.SetInt("levelnumber", levelNumber);

                break;
        }
    }
}

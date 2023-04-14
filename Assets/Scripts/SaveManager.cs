using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public int currentLevel = 0;
    public int levelNumber = 1;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            currentLevel = PlayerPrefs.GetInt("Level");
        }
        else
        {
            currentLevel = PlayerPrefs.GetInt("Level",0);
        }

        levelNumber = PlayerPrefs.GetInt("levelnumber", 1);

    }
    private void Start()
    {
        GameManager.OnStateChanged += OnStateChanged;

    }
    private void OnStateChanged(GameState State)
    {
        switch (State)
        {
            case GameState.Start:

                break;
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

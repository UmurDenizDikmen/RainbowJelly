using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject failPanel;
    [SerializeField] private GameObject successPanel;
    private void Start()
    {
        GameManager.OnStateChanged += OnstateChanged;
    }
    private void OnstateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.Start:
                successPanel.SetActive(false);
                failPanel.SetActive(false);
                break;
            case GameState.InGame:
                successPanel.SetActive(false);
                failPanel.SetActive(false);
                break;
            case GameState.Success:
                successPanel.SetActive(true);
                failPanel.SetActive(false);
                break;

            case GameState.Fail:
                successPanel.SetActive(false);
                failPanel.SetActive(true);
                break;
        }
    }
}

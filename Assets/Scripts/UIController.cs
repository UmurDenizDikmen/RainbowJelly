using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject failPanel;
    [SerializeField] private GameObject successPanel;
    public TextMeshProUGUI orderCountText;
    [SerializeField] private TextMeshProUGUI levelCountText;

    private void Start()
    {
        GameManager.OnStateChanged += OnstateChanged;
        GameManager.onOrderCountChange += OnOrderCountChange;
        levelCountText.text = PlayerPrefs.GetInt("levelnumber", 1).ToString();

    }
    private void OnOrderCountChange()
    {
        orderCountText.text = GameManager.instance.OrderCount.ToString();
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
                levelCountText.text = PlayerPrefs.GetInt("levelnumber").ToString();
                break;

            case GameState.Fail:
                successPanel.SetActive(false);
                failPanel.SetActive(true);
                break;
        }
    }
}

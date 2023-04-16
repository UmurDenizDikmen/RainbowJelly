using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject failPanel;
    [SerializeField] private GameObject successPanel;
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject buttonplay;
    [SerializeField] private Animator succesPanelAnim;
    public TextMeshProUGUI orderCountText;
    [SerializeField] private TextMeshProUGUI levelCountText;
    public static UIController instance;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        GameManager.OnStateChanged += OnstateChanged;
        GameManager.onOrderCountChange += OnOrderCountChange;
        levelCountText.text = PlayerPrefs.GetInt("levelnumber", SaveManager.instance.levelNumber).ToString();


    }
    private void OnDisable()
    {
        GameManager.OnStateChanged -= OnstateChanged;

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
                inGamePanel.SetActive(true);
                levelCountText.text = PlayerPrefs.GetInt("levelnumber", SaveManager.instance.levelNumber).ToString();
                break;
            case GameState.InGame:
                successPanel.SetActive(false);
                failPanel.SetActive(false);
                inGamePanel.SetActive(true);
                buttonplay.SetActive(false);
                break;
            case GameState.Success:
                successPanel.SetActive(true);
                succesPanelAnim.Play("idle");
                failPanel.SetActive(false);
                inGamePanel.SetActive(false);
                levelCountText.text = PlayerPrefs.GetInt("levelnumber", SaveManager.instance.levelNumber).ToString();

                break;
            case GameState.Fail:
                successPanel.SetActive(false);
                failPanel.SetActive(true);
                inGamePanel.SetActive(true);
                buttonplay.SetActive(false);
                break;
        }
    }
}

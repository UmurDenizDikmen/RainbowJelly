using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using System.Security;

public class GameManager : MonoBehaviour
{
    public static event Action<GameState> OnStateChanged;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject[] jellyImages;
    public List<GameObject> jellyImagesList = new List<GameObject>();
    public List<GameObject> tableObjects = new List<GameObject>();
    [SerializeField] private GameObject[] orders;
    public static event Action onOrderCountChange;
    [SerializeField] Transform orderPoint;
    private int orderCount;
    public List<GameObject> orderList = new List<GameObject>();

    public bool isOrderGiven = false;

    [SerializeField] private Transform panelParent;

    public static GameManager instance;
    public GameState State { get; private set; }

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ChangeGameState(GameState.Start);

    }
    public int OrderCount
    {
        get
        {
            return orderCount;
        }
        set
        {
            orderCount = value;
            onOrderCountChange?.Invoke();
            if (OrderCount == 0)
            {
                ChangeGameState(GameState.Success);
                OrderCount++;


            }
        }
    }
    private void Update()
    {

        if (isOrderGiven == false)
        {
            isOrderGiven = true;
            int Index = UnityEngine.Random.Range(0, orders.Length);
            var newOrder = Instantiate(orders[Index], orderPoint.position, Quaternion.identity, orderPoint);
            orderList.Add(newOrder.gameObject);
        }

    }
    public void StartGameButton()
    {
        if (State == GameState.Start)
        {
            ChangeGameState(GameState.InGame);
            return;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void spawnJellyImage()
    {
        var index = UnityEngine.Random.Range(0, jellyImages.Length);
        var newObjects = Instantiate(jellyImages[index], spawnPoint.transform.position, Quaternion.identity, panelParent);
        jellyImagesList.Add(newObjects);
        ImageMovement.speed = 1f;
    }
    public void ChangeGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Start:
                tableObjects.Capacity = 3;
                 OrderCount=3;
                break;
            case GameState.InGame:
                InvokeRepeating("spawnJellyImage", .5f, 3.2f);
                break;
            case GameState.Success:
                OrderCount++;
                CancelInvoke("spawnJellyImage");
                break;
            case GameState.Fail:
                CancelInvoke("spawnJellyImage");
                break;
        }
        OnStateChanged?.Invoke(newState);
        State = newState;
    }
}

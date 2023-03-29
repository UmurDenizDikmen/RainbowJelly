using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static event Action<GameState> OnStateChanged;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject[] jellyImages;
    public List<GameObject> jellyImagesList = new List<GameObject>();
    public List<GameObject> tableObjects = new List<GameObject>();
    [SerializeField] private GameObject[] orders;

    [SerializeField] Transform orderPoint;

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

        State = GameState.Start;
    }
    private void Update()
    {
        if (State == GameState.Start && Input.GetMouseButtonDown(0))
        {
            ChangeGameState(GameState.InGame);
            return;
        }
        if (isOrderGiven == false)
        {
            isOrderGiven = true;
            int Index = UnityEngine.Random.Range(0, orders.Length);
            var newOrder = Instantiate(orders[Index], orderPoint.position, Quaternion.identity, orderPoint);
            orderList.Add(newOrder.gameObject);
        }

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
                break;
            case GameState.InGame:
                InvokeRepeating("spawnJellyImage", 5.7f, 2f);
                break;
            case GameState.Fail:
                CancelInvoke("spawnJellyImage");
                break;


        }
        OnStateChanged?.Invoke(newState);
        State = newState;

    }
}

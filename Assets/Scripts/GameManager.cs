using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject[] jellyImages;
    public List<GameObject> jellyImagesList = new List<GameObject>();
    [SerializeField] private GameObject [] orders;

    [SerializeField] Transform orderPoint;

    public List<GameObject>orderList = new List<GameObject>();

    public bool isOrderGiven = false;

    [SerializeField] private Transform panelParent;

    public static GameManager instance;
    
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        InvokeRepeating("spawnJellyImage",5.7f,2f);
    }
    private void Update()
    {
        /*if (JellyImages.isDestroy == true)
        {
            var index = Random.Range(0, jellyImages.Length);
            var newObjects = Instantiate(jellyImages[index], spawnPoint.transform.position, Quaternion.identity, panelParent);
            jellyImagesList.Add(newObjects);
            JellyImages.isDestroy = false;

        }*/
         if(isOrderGiven == false)
         {
            isOrderGiven = true;
            int Index = Random.Range(0,orders.Length);
            var newOrder = Instantiate(orders[Index],orderPoint.position,Quaternion.identity,orderPoint);
            orderList.Add(newOrder.gameObject);
         }
    }
    private void spawnJellyImage()
    { 
        var index = Random.Range(0, jellyImages.Length);
        var newObjects = Instantiate(jellyImages[index], spawnPoint.transform.position, Quaternion.identity, panelParent);
        jellyImagesList.Add(newObjects);
    }
}

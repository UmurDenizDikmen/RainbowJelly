using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField]private Transform spawnPoint;
   [SerializeField]private GameObject[] jellyImages;

   public List<GameObject> jellyImagesList = new List<GameObject>();

   [SerializeField]private Transform panelParent;

   public static GameManager instance;

    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        if(JellyImages.isDestroy == true)
        {
            var index = Random.Range(0,jellyImages.Length);
            var newObjects = Instantiate(jellyImages[index],spawnPoint.transform.position,Quaternion.identity,panelParent);
            jellyImagesList.Add(newObjects);
            JellyImages.isDestroy = false;

        }
    }

   
}

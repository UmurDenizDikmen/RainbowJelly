using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JellyImages : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.tag)
        {
            case "DestroyArea":
                Destroy(gameObject);
                break;
            case "ActiveDeactiveLocked":
                transform.GetChild(1).gameObject.SetActive(false);
                GameManager.instance.jellyImagesList.Remove(gameObject);
                var childObject = transform.GetChild(1).gameObject;
                if (!childObject.activeSelf)
                {

                    GameManager.instance.jellyImagesList[0].transform.GetChild(1).gameObject.SetActive(true);
                }
                break;
        }
    }
    private void Update()
    {
        GameManager.instance.jellyImagesList[0].transform.GetChild(1).gameObject.SetActive(true);
    }
}

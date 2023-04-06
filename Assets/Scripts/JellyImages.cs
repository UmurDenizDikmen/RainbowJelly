using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JellyImages : MonoBehaviour
{
    [SerializeField]private bool isLockedActive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.tag)
        {
            case "DestroyArea":
                Destroy(gameObject);
                break;
            case "ActiveDeactiveLocked":
                transform.GetChild(1).gameObject.SetActive(true);
                GameManager.instance.jellyImagesList.Remove(gameObject);
            break;
        }
    }
    private void ActivateLocked()
    {
        var childObject = transform.GetChild(1).gameObject;
        if (childObject.activeSelf)
        {
            isLockedActive = true;
            GameManager.instance.jellyImagesList[0].transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        ActivateLocked();

    }
}

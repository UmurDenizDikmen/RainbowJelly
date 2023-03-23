using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JellyImages : MonoBehaviour
{
    public static bool isDestroy = false;
    [SerializeField]private bool isLockedActive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        switch (other.tag)
        {
            case "DestroyArea":
                Destroy(gameObject);
                isDestroy = true;
                break;
            case "ActiveDeactiveLocked":
                transform.GetChild(0).gameObject.SetActive(true);
                GameManager.instance.jellyImagesList.Remove(gameObject);
                GameManager.instance.jellyImagesList[0].transform.GetChild(0).gameObject.SetActive(false);
                break;
        }
    }
    private void ActivateLocked()
    {
        var childObject = transform.GetChild(0).gameObject;
        if (childObject.activeSelf)
        {
            isLockedActive = true;
        }
    }
    private void Update()
    {
        ActivateLocked();
    }
}

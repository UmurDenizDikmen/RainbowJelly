using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TableControl : MonoBehaviour
{
    
    void Start()
    {

    }


    void Update()
    {

    }
    private void OnMouseDown()
    {
        var jellyImagesList = GameManager.instance.jellyImagesList;
        var firstJelly = jellyImagesList[0];
        var jellyToRemove = firstJelly;
        if (transform.GetChild(0).gameObject == null)
        {
            firstJelly.transform.DOMove(transform.position, 0.7f)
                 .SetEase(Ease.InOutFlash)
                 .OnComplete(() =>
                 {
                     jellyImagesList.Remove(jellyToRemove.gameObject);
                     jellyToRemove.transform.SetParent(transform);
                     Destroy(jellyToRemove.GetComponent<JellyImages>());
                     Destroy(jellyToRemove.GetComponent<ImageMovement>());
                     jellyToRemove.transform.gameObject.AddComponent<OnTableJelly>();

                    

                 });
        }
    }
}
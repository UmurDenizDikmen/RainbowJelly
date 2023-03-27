using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlateControl : MonoBehaviour
{
    [SerializeField] private Transform orderPoint;
     [SerializeField] private Transform moveTablePoint;

    private void OnMouseDown()
    {
        if (transform.childCount == 1)
        {
            var jellyImagesList = GameManager.instance.jellyImagesList;
            var firstJelly = jellyImagesList[0];
            jellyImagesList.Remove(firstJelly.gameObject);
            firstJelly.GetComponent<ImageMovement>().enabled = false;
            firstJelly.GetComponent<JellyImages>().enabled = false;
            firstJelly.transform.DOMove(moveTablePoint.position, 0.2f)
                    .SetEase(Ease.InOutFlash)
                    .OnComplete(() =>
                    {
                        firstJelly.transform.SetParent(transform);
                        firstJelly.GetComponent<OnTableJelly>().enabled = true;
                        firstJelly.GetComponent<OnTableJelly>().orderPoint = orderPoint;
                        Destroy(firstJelly.transform.GetChild(0).gameObject);
                    });
        }
    }
}

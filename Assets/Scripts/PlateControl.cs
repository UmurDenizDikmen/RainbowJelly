using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlateControl : MonoBehaviour
{
    [SerializeField] private Transform orderPoint;
    private Vector3 childPosition;

    private void Start()
    {
        childPosition = transform.GetChild(0).localPosition;
    }
    private void OnMouseDown()
    {
        if (transform.childCount == 0)
        {
            var jellyImagesList = GameManager.instance.jellyImagesList;
            var firstJelly = jellyImagesList[0];
            jellyImagesList.Remove(firstJelly.gameObject);
            firstJelly.GetComponent<ImageMovement>().enabled = false;
            firstJelly.GetComponent<JellyImages>().enabled = false;
            firstJelly.transform.SetParent(transform);
            firstJelly.transform.DOLocalMove(childPosition, 0.2f)
                    .SetEase(Ease.InOutFlash)
                    .OnComplete(() =>
                    {

                        firstJelly.GetComponent<OnTableJelly>().enabled = true;
                        firstJelly.GetComponent<OnTableJelly>().orderPoint = orderPoint;
                        Destroy(firstJelly.transform.GetChild(1).gameObject);
                    });
        }
    }
}

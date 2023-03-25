using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OnTableJelly : MonoBehaviour
{
    [SerializeField] private Color[] myColor;
    [SerializeField] private Transform panelMovePoint;

    [SerializeField] Transform orderPoint;

    public enum typeOfJelly
    {
        red,
        blue,
        yellow,
        orange,
        purple,
        green

    }
    [SerializeField] private typeOfJelly jellyType;
    private void OnMouseDown()
    {
        var jellyImagesList = GameManager.instance.jellyImagesList;
        var orderList = GameManager.instance.orderList;

        var firstJelly = jellyImagesList[0];
        var firstJellyColor = firstJelly.GetComponent<SpriteRenderer>().color;
        var jellyToRemove = firstJelly;
        if (jellyType == typeOfJelly.red)
        {
            if (firstJellyColor == myColor[2])
            {
                // Red jelly and green order
                firstJelly.transform.DOMove(GetPosition(panelMovePoint), 0.7f)
                    .SetEase(Ease.InOutFlash)
                    .OnComplete(() =>
                    {
                        jellyImagesList.Remove(jellyToRemove.gameObject);
                        Destroy(jellyToRemove);

                        transform.gameObject.GetComponent<SpriteRenderer>().color = myColor[3];
                        jellyType = typeOfJelly.purple;

                        if (orderList[0].GetComponent<OrderObjects>().orderType == OrderObjects.typeOfOrder.purple && jellyType == typeOfJelly.purple)
                        {
                            transform.DOMove(orderPoint.position, 1f)
                                .SetEase(Ease.InOutFlash)
                                .OnComplete(() =>
                                {
                                    Destroy(gameObject);

                                    var orderToRemove = orderList[0];
                                    orderList.Remove(orderToRemove.gameObject);
                                    Destroy(orderToRemove);

                                    GameManager.instance.isOrderGiven = false;
                                });
                        }
                    });
            }
            else if (firstJellyColor == myColor[1])
            {
                // Red jelly and yellow order
              
                firstJelly.transform.DOMove(GetPosition(panelMovePoint), 0.7f)
                    .SetEase(Ease.InOutFlash)
                    .OnComplete(() =>
                    {
                        jellyImagesList.Remove(jellyToRemove.gameObject);
                        Destroy(jellyToRemove);

                        transform.gameObject.GetComponent<SpriteRenderer>().color = myColor[4];
                        jellyType = typeOfJelly.orange;

                        if (orderList[0].GetComponent<OrderObjects>().orderType == OrderObjects.typeOfOrder.orange && jellyType == typeOfJelly.orange)
                        {
                            transform.DOMove(orderPoint.position, 1f)
                                .SetEase(Ease.InOutFlash)
                                .OnComplete(() =>
                                {
                                    Destroy(gameObject);

                                    var orderToRemove = orderList[0];
                                    orderList.Remove(orderToRemove.gameObject);
                                    Destroy(orderToRemove);

                                    GameManager.instance.isOrderGiven = false;
                                });
                        }
                    });
            }
        }

        if (jellyType == typeOfJelly.blue)
        {
            // Blue jelly and purple order
            if (firstJellyColor == myColor[0])
            {
              
                firstJelly.transform.DOMove(GetPosition(panelMovePoint), 0.7f)
                    .SetEase(Ease.InOutFlash)
                    .OnComplete(() =>
                    {
                        jellyImagesList.Remove(jellyToRemove.gameObject);
                        Destroy(jellyToRemove);

                        transform.gameObject.GetComponent<SpriteRenderer>().color = myColor[3];
                        jellyType = typeOfJelly.purple;

                        if (orderList[0].GetComponent<OrderObjects>().orderType == OrderObjects.typeOfOrder.purple && jellyType == typeOfJelly.purple)
                        {
                            transform.DOMove(orderPoint.position, 1f)
                                .SetEase(Ease.InOutFlash)
                                .OnComplete(() =>
                                {
                                    Destroy(gameObject);

                                    var orderToRemove = orderList[0];
                                    orderList.Remove(orderToRemove.gameObject);
                                    Destroy(orderToRemove);

                                    GameManager.instance.isOrderGiven = false;
                                });
                        }
                    });
            }
            else if (firstJellyColor == myColor[1])
            {
                // Blue jelly and green order
             
                firstJelly.transform.DOMove(GetPosition(panelMovePoint), 0.7f)
                    .SetEase(Ease.InOutFlash)
                    .OnComplete(() =>
                    {
                        jellyImagesList.Remove(jellyToRemove.gameObject);
                        Destroy(jellyToRemove);

                        transform.gameObject.GetComponent<SpriteRenderer>().color = myColor[5];
                        jellyType = typeOfJelly.green;

                        if (orderList[0].GetComponent<OrderObjects>().orderType == OrderObjects.typeOfOrder.green && jellyType == typeOfJelly.green)
                        {
                            transform.DOMove(orderPoint.position, 1f)
                                .SetEase(Ease.InOutFlash)
                                .OnComplete(() =>
                                {
                                    Destroy(gameObject);

                                    var orderToRemove = orderList[0];
                                    orderList.Remove(orderToRemove.gameObject);
                                    Destroy(orderToRemove);

                                    GameManager.instance.isOrderGiven = false;
                                });
                        }
                    });
            }
        }
        if (jellyType == typeOfJelly.yellow)
        {
            // yellow jelly and red order
            if (firstJellyColor == myColor[0])
            {
              
                firstJelly.transform.DOMove(GetPosition(panelMovePoint), 0.7f)
                    .SetEase(Ease.InOutFlash)
                    .OnComplete(() =>
                    {
                        jellyImagesList.Remove(jellyToRemove.gameObject);
                        Destroy(jellyToRemove);

                        transform.gameObject.GetComponent<SpriteRenderer>().color = myColor[4];
                        jellyType = typeOfJelly.orange;

                        if (orderList[0].GetComponent<OrderObjects>().orderType == OrderObjects.typeOfOrder.orange && jellyType == typeOfJelly.orange)
                        {
                            transform.DOMove(orderPoint.position, 1f)
                                .SetEase(Ease.InOutFlash)
                                .OnComplete(() =>
                                {
                                    Destroy(gameObject);

                                    var orderToRemove = orderList[0];
                                    orderList.Remove(orderToRemove.gameObject);
                                    Destroy(orderToRemove);

                                    GameManager.instance.isOrderGiven = false;
                                });
                        }
                    });
            }
            else if (firstJellyColor == myColor[2])
            {
                // yellow jelly and green orderS
                firstJelly.transform.DOMove(GetPosition(panelMovePoint), 0.7f)
                    .SetEase(Ease.InOutFlash)
                    .OnComplete(() =>
                    {
                        jellyImagesList.Remove(jellyToRemove.gameObject);
                        Destroy(jellyToRemove);

                        transform.gameObject.GetComponent<SpriteRenderer>().color = myColor[5];
                        jellyType = typeOfJelly.green;

                        if (orderList[0].GetComponent<OrderObjects>().orderType == OrderObjects.typeOfOrder.green && jellyType == typeOfJelly.green)
                        {
                            transform.DOMove(orderPoint.position, 1f)
                                .SetEase(Ease.InOutFlash)
                                .OnComplete(() =>
                                {
                                    Destroy(gameObject);

                                    var orderToRemove = orderList[0];
                                    orderList.Remove(orderToRemove.gameObject);
                                    Destroy(orderToRemove);

                                    GameManager.instance.isOrderGiven = false;
                                });
                        }
                    });
            }
        }

    }
     private Vector3 GetPosition(Transform target)
    {
        if (target.GetComponent<Transform>())
        {
            return target.GetComponent<Transform>().position;
        }
        else
        {
            return Vector3.zero;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OnTableJelly : MonoBehaviour
{
    [SerializeField] private Color[] myColor;
    public Transform orderPoint;

    public bool isClickable = true;
    public enum typeOfJelly
    {
        red,
        blue,
        yellow,
        orange,
        purple,
        green
    }
    private void Start()
    {
        GameManager.OnStateChanged += OnstateChanged;
      //  InvokeRepeating("ControlOrders", 1.1f, 2f);
    }
    private IEnumerator isClickableOnAgain()
    {
        yield return new WaitForSeconds(.5f);
        isClickable = true;
    }
    [SerializeField] private typeOfJelly jellyType;

    private void JellyMove(int indexColor,int newIndexColor,typeOfJelly newJellyType,int secondIndexColor,int newIndexSecondColor,typeOfJelly newSecondJellyType)
    {
        var jellyImagesList = GameManager.instance.jellyImagesList;
        var firstJelly = jellyImagesList[0];
        var firstJellyColor = firstJelly.GetComponent<SpriteRenderer>().color;
        var jellyToRemove = firstJelly;
            if (firstJellyColor == myColor[indexColor])
            {
                firstJelly.transform.DOMove(transform.position, 0.2f)
                    .SetEase(Ease.InOutFlash)
                    .OnComplete(() =>
                    {
                        jellyImagesList.Remove(jellyToRemove.gameObject);
                        Destroy(jellyToRemove);
                        transform.gameObject.GetComponent<SpriteRenderer>().color = myColor[newIndexColor];
                        jellyType = newJellyType;
                    });
            }
            else if(firstJellyColor == myColor[secondIndexColor])
            {
                    firstJelly.transform.DOMove(transform.position, 0.2f)
                    .SetEase(Ease.InOutFlash)
                    .OnComplete(() =>
                    {
                        jellyImagesList.Remove(jellyToRemove.gameObject);
                        Destroy(jellyToRemove);
                        transform.gameObject.GetComponent<SpriteRenderer>().color = myColor[newIndexSecondColor];
                        jellyType = newSecondJellyType;
                    });
            }
    }
    private void OnMouseDown()
    {
        if (jellyType == typeOfJelly.red && isClickable == true && gameObject.transform.childCount == 0)
        {
            isClickable = false;
            StartCoroutine(isClickableOnAgain());
            JellyMove(2,3,typeOfJelly.purple,1,4,typeOfJelly.orange);
           
            
        }
        if (jellyType == typeOfJelly.blue && isClickable == true && gameObject.transform.childCount == 0)
        {
            isClickable = false;
            StartCoroutine(isClickableOnAgain());
            JellyMove(0,3,typeOfJelly.purple,1,5,typeOfJelly.green);

          
        }
        if (jellyType == typeOfJelly.yellow && isClickable == true && gameObject.transform.childCount == 0)
        {
            isClickable = false;
            StartCoroutine(isClickableOnAgain());
            JellyMove(0,4,typeOfJelly.orange,2,5,typeOfJelly.green);
           
        }
    }
    private void ControlOrders()
    {
        var orderList = GameManager.instance.orderList;
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
    }
    private void OnstateChanged(GameState newState)
    {
        switch(newState)
        {
               case GameState.InGame :
                 InvokeRepeating("ControlOrders", 1.1f, 2f);
               break;
        }
    }
}

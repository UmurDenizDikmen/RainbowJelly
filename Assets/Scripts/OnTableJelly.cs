using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Data;

public class OnTableJelly : MonoBehaviour
{
    [SerializeField] private Sprite[] myRenderer;

    Animator anim;
    // [SerializeField] private Color[] myColor;
    public Transform orderPoint;
    public bool isClickable = true;
    public static OnTableJelly instance;
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

    private void Start()
    {
        GameManager.OnStateChanged += OnstateChanged;
        InvokeRepeating("ControlOrders", 1f, 1.3f);
        anim = GetComponent<Animator>();

    }
    private void OnDisable()
    {
        GameManager.OnStateChanged -= OnstateChanged;
    }
    private IEnumerator isClickableOnAgain()
    {
        yield return new WaitForSeconds(.5f);
        isClickable = true;
    }
    private void JellyMove(int indexColor, int newIndexColor, typeOfJelly newJellyType, int secondIndexColor, int newIndexSecondColor, typeOfJelly newSecondJellyType)
    {
        var jellyImagesList = GameManager.instance.jellyImagesList;
        var firstJelly = jellyImagesList[0];
        var firstJellyColor = firstJelly.GetComponent<SpriteRenderer>().sprite;
        var jellyToRemove = firstJelly;
        isClickable = false;
        StartCoroutine(isClickableOnAgain());
        if (firstJellyColor == myRenderer[indexColor] && jellyImagesList.Count > 0)
        {
            firstJelly.transform.DOMove(transform.position, 0.2f)
                .SetEase(Ease.InOutFlash)
                .OnComplete(() =>
                {
                    jellyImagesList.Remove(jellyToRemove.gameObject);
                    Destroy(jellyToRemove);
                    transform.gameObject.GetComponent<SpriteRenderer>().sprite = myRenderer[newIndexColor];
                    jellyType = newJellyType;
                    GameManager.instance.tableObjects.Add(transform.gameObject);
                    Vector3 originalScale = transform.localScale;
                    transform.DOScaleY(transform.localScale.y - 0.2f, 0.15f)
                    .OnComplete(() => transform.DOScale(originalScale, 0.15f));

                    isFailorGo();
                });
        }
        else if (firstJellyColor == myRenderer[secondIndexColor] && jellyImagesList.Count > 0)
        {
            firstJelly.transform.DOMove(transform.position, 0.2f)
            .SetEase(Ease.InOutFlash)
            .OnComplete(() =>
            {
                jellyImagesList.Remove(jellyToRemove.gameObject);
                Destroy(jellyToRemove);
                transform.gameObject.GetComponent<SpriteRenderer>().sprite = myRenderer[newIndexSecondColor];
                jellyType = newSecondJellyType;
                GameManager.instance.tableObjects.Add(transform.gameObject);
                Vector3 originalScale = transform.localScale;
                transform.DOScaleY(transform.localScale.y - 0.2f, 0.15f)
                .OnComplete(() => transform.DOScale(originalScale, 0.15f));
                isFailorGo();


            });
        }
    }
    private void OnMouseDown()
    {

        if (jellyType == typeOfJelly.red && isClickable == true && gameObject.transform.childCount == 1)
        {
            JellyMove(2, 3, typeOfJelly.purple, 1, 4, typeOfJelly.orange);

        }
        if (jellyType == typeOfJelly.blue && isClickable == true && gameObject.transform.childCount == 1)
        {
            JellyMove(0, 3, typeOfJelly.purple, 1, 5, typeOfJelly.green);

        }
        if (jellyType == typeOfJelly.yellow && isClickable == true && gameObject.transform.childCount == 1)
        {
            JellyMove(0, 4, typeOfJelly.orange, 2, 5, typeOfJelly.green);

        }
    }
    private void isFailorGo()
    {
        var orderList = GameManager.instance.orderList;
        if (GameManager.instance.tableObjects.Count == 3 && orderList.Count > 0 && orderList[0].GetComponent<OrderObjects>().orderType.ToString() != jellyType.ToString())
        {
            GameManager.instance.ChangeGameState(GameState.Fail);
        }
    }
    private void ControlOrders()
    {
        var orderList = GameManager.instance.orderList;

        if (orderList.Count > 0 && orderList[0].GetComponent<OrderObjects>().orderType.ToString() == jellyType.ToString())
        {
            transform.GetComponent<SpriteRenderer>().sortingOrder = 2;
            GameManager.instance.tableObjects.Remove(transform.gameObject);
            transform.DOMove(orderPoint.position, 1.5f)
                .SetEase(Ease.InOutFlash)
                .OnStart(() =>
                {

                    transform.DOScale(Vector3.zero, 1.8f).SetEase(Ease.InOutFlash);
                    transform.GetChild(0).gameObject.SetActive(true);
                })
                .OnComplete(() =>
                {

                    Destroy(gameObject);
                    var orderToRemove = orderList[0];
                    orderList.Remove(orderToRemove.gameObject);
                    Destroy(orderToRemove);
                    GameManager.instance.isOrderGiven = false;
                    GameManager.instance.OrderCount--;


                });
        }
    }
    private void OnstateChanged(GameState newState)
    {
        switch (newState)
        {


                case GameState.Success:
                CancelInvoke("ControlOrders");
                break;

            case GameState.Fail:
                CancelInvoke("ControlOrders");
                break;
        }
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OnTableJelly : MonoBehaviour
{
    [SerializeField] private Color[] myColor;
    [SerializeField] private Transform[] panelMovePoint;
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
    void Start()
    {

    }

    private void OnMouseDown()
    {
        if (jellyType == typeOfJelly.red)
        {
            if (GameManager.instance.jellyImagesList[0].GetComponent<SpriteRenderer>().color == myColor[2])
            {
                var jellyRemoves = GameManager.instance.jellyImagesList[0];
                GameManager.instance.jellyImagesList[0].transform.DOMove(GetPosition(panelMovePoint[0]), .7f)
                    .SetEase(Ease.InOutFlash)
                    .OnComplete(() =>
                    {
                        GameManager.instance.jellyImagesList.Remove(jellyRemoves.gameObject);
                        Destroy(jellyRemoves);
                        transform.gameObject.GetComponent<SpriteRenderer>().color = myColor[3];
                        jellyType = typeOfJelly.purple;
                    });
                   
            }
            else if (GameManager.instance.jellyImagesList[0].GetComponent<SpriteRenderer>().color == myColor[1])
            {
                var jellyRemoves = GameManager.instance.jellyImagesList[0];
                GameManager.instance.jellyImagesList[0].transform.DOMove(GetPosition(panelMovePoint[0]), .7f)
                    .SetEase(Ease.InOutFlash)
                    .OnComplete(() =>
                    {
                        GameManager.instance.jellyImagesList.Remove(jellyRemoves.gameObject);
                        Destroy(jellyRemoves);
                        transform.gameObject.GetComponent<SpriteRenderer>().color = myColor[4];
                        jellyType = typeOfJelly.orange;

                    });

            }
        }

    }
    private Vector3 GetPosition(Transform target)
    {
        if(target.GetComponent<Transform>())
        {
            return target.GetComponent<Transform>().position + new Vector3(0,-1.2f,0);
        }
        else
        { 
           return Vector3.zero;
        }
    }







}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ImageMovement : MonoBehaviour
{
    public static float speed;
    private void Start()
    {

        GameManager.OnStateChanged += OnStateChanged;
      
    }
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    private void OnStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.Start:
                speed = 0f;
                break;

            case GameState.InGame:
                speed = 1f;
                break;

            case GameState.Success:
                speed = 0f;
                break;

            case GameState.Fail:
                speed = 0f;
                break;


        }
    }
}

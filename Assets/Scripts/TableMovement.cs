using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableMovement : MonoBehaviour
{
    [SerializeField] private Transform rotationCenter;
    private float angularSpeed;

    private float rotationRadius = 1.8f;
    private float angle = 0;

    private void Start()
    {
        Vector2 direction = transform.position - rotationCenter.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameManager.OnStateChanged += OnStateChanged;
    }

    private void Update()
    {
        float posX = rotationCenter.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * rotationRadius;
        float posY = rotationCenter.position.y + Mathf.Sin(angle * Mathf.Deg2Rad) * rotationRadius;
        transform.position = new Vector2(posX, posY);

        angle += Time.deltaTime * angularSpeed;
        if (angle > 360)
        {
            angle = 0;
        }
    }
    private void OnStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.Start:
                angularSpeed = 0f;

                break;
            case GameState.InGame:
                angularSpeed = 100f;

                break;

            case GameState.Success:
               angularSpeed = 0f;

                break;

            case GameState.Fail:
              angularSpeed = 0;

                break;

        }
    }
}

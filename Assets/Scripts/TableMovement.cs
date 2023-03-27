using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableMovement : MonoBehaviour
{
    [SerializeField] private Transform rotationCenter;
    [SerializeField] private float angularSpeed, rotationRadius;
    private float angle = 0;

    private void Start()
    {
        Vector2 direction = transform.position - rotationCenter.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
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
}

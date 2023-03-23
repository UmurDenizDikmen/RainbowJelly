using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
      
      transform.position += Vector3.left * speed * Time.deltaTime;
        
    }
}

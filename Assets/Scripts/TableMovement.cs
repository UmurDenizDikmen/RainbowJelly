using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    void Update()
    {
      transform.rotation *= Quaternion.Euler(0, 0, -30 * speed * Time.deltaTime);

    }
}

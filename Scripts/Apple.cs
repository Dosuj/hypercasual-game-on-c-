using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 180 * Time.deltaTime, 0);
    }
}

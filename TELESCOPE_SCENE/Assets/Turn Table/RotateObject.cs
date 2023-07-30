using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationAmount;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationAmount * Time.deltaTime, 0);
    }
}

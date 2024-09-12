using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float degree = 45;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(degree * Time.deltaTime, 0, 0);
    }
}
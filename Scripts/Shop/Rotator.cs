using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotator : MonoBehaviour
{
    [SerializeField] float speedRotation=50;
    void Update()
    {
        transform.Rotate(0, speedRotation * Time.deltaTime, 0);
    }
}

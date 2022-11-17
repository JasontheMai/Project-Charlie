using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Reverse4Blades : MonoBehaviour
{

    private Vector3 startingPosition;
    [SerializeField] float RotationSpeed = 1;
    [SerializeField] float CircleRadius = 1;

    private Vector3 positionOffset;
    private float angle;

    private void Start()
    {
        startingPosition = transform.position;
    }


    void Update()
    {
        angle -= Time.deltaTime * RotationSpeed;
        positionOffset.Set(
            Mathf.Cos(angle) * CircleRadius,
            Mathf.Sin(angle) * CircleRadius,
            0
        );
        transform.position = startingPosition + positionOffset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VM2 : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] float speed;
    private Vector3 startingPostition;

    private void Start()
    {
        startingPostition = transform.position;
    }
    void Update()
    {
        Vector3 move = startingPostition;
        move.y += distance * Mathf.Cos(Time.time * speed);
        transform.position = move;

    }
}

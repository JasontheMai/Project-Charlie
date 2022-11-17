using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;

public class HML2 : MonoBehaviour
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
        move.x += distance * Mathf.Sin(Time.time * speed);
        transform.position = move;

    }
}

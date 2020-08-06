using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMothion : MonoBehaviour
{
    public float speed;
    private Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
    }
    private void FixedUpdate()
    {
        float move = Mathf.Repeat(Time.time * speed, 200);
        transform.position = startPosition + new Vector3(0, 0, -move);
    }
}

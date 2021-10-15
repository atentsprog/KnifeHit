using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 direction = new Vector3(0, 1, 0);
    public float speed = 50f;
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject knife;
    private void Start()
    {
        knife.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            CreateKnife();
    }

    private void CreateKnife()
    {
        var newItem = Instantiate(knife);
        newItem.SetActive(true);
    }
}

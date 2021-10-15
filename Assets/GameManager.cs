using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject knife;

    private void Start()
    {
        knife.GetComponent<Move>().enabled = false;
        knife.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
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
        newItem.GetComponent<Move>().enabled = true;

        newItem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        StartCoroutine(OnAndOffCo(knife));
    }

    private float disappearTime = 0.3f;
    private IEnumerator OnAndOffCo(GameObject knife)
    {
        knife.SetActive(false);
        // 적당히 쉬었다가 보이게 하자.
        yield return new WaitForSeconds(disappearTime);
        knife.SetActive(true);
    }
}

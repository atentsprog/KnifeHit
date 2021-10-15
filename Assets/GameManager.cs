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

        StartCoroutine(OnAndOffCo(knife));
    }

    private float disappearTime = 0.3f;
    private IEnumerator OnAndOffCo(GameObject knife)
    {
        knife.SetActive(false);
        // ������ �����ٰ� ���̰� ����.
        yield return new WaitForSeconds(disappearTime);
        knife.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBoard : MonoBehaviour
{
    public GameObject fixedKnife;
    private void Start()
    {
        fixedKnife.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("������ " + collision.transform.name, collision.transform);
        collision.gameObject.SetActive(false);

        var newItem = Instantiate(fixedKnife
            , fixedKnife.transform.position
            , fixedKnife.transform.rotation
            , transform); // �θ� ����.
        newItem.SetActive(true);
    }
}

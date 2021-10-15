using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBoard : MonoBehaviour
{
    public GameObject fixedKnife;

    public float appleRaio = 0.3f;
    public int appleMaxCount = 2;
    public GameObject appleGo;
    private void Start()
    {
        fixedKnife.SetActive(false);

        // ����� �����ϰ� ��������.
        for (int i = 0; i < appleMaxCount; i++)
        {
            if (Random.Range(0, 1f) < appleRaio)
            {
                var newApple = Instantiate(appleGo, appleGo.transform.parent);
                newApple.transform.rotation = Quaternion.Euler(
                    0, 0, Random.Range(0, 360));
                newApple.gameObject.SetActive(true);
            }
        }
        appleGo.SetActive(false);
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

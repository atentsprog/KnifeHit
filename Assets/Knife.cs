using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("TargetBoard"))
        {
            // 점수 증가.
            print("점수 증가");
            FindObjectOfType<GameManager>().AddPoint();
        }
        else if (collision.transform.CompareTag("FixedKnife"))
        {
            // 게임 오버.
            print("게임 오버");
            GetComponent<Move>().enabled = false;

            MoveDown();
            Rotate();

            Destroy(gameObject, 2);
        }
        else
        {
            //Debug.LogWarning(collision.transform.name, collision.transform);
        }
    }

    public float rotateMin = 200;
    public float rotateMax = 2000;
    private void Rotate()
    {
        RandomRotate randomRotate = gameObject.AddComponent<RandomRotate>();
        randomRotate.minAngle = rotateMin;
        randomRotate.maxAngle = rotateMax;
        randomRotate.minDuration = randomRotate.maxDuration = 3;
        randomRotate.ease = DG.Tweening.Ease.Linear;
    }

    public float reboundX = 3;
    public float reboundY = 10;
    private void MoveDown()
    {
        Vector3 destination = transform.position;
        destination.y -= reboundY;
        destination.x += Random.Range(-reboundX, reboundX);
        transform.DOMove(destination, 3);
    }
}

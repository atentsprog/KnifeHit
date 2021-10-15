using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Plugins.Options;
using DG.Tweening.Core;

public class RandomRotate : MonoBehaviour
{
    public float minAngle = 1000f;
    public float maxAngle = 1200f;
    public float minDuration = 3;
    public float maxDuration = 5;
    public Ease ease = Ease.InOutQuint;
    TweenerCore<float, float, FloatOptions> handle;
    void Rotate()
    {
        float startAngle = transform.eulerAngles.z;
        float angle = startAngle + Random.Range(minAngle, maxAngle);
        float duration = Random.Range(minDuration, maxDuration);

        handle.Kill();
        handle = DOTween.To(() => startAngle
            , x => transform.rotation = Quaternion.Euler(0.0f, 0.0f, x), angle, duration
            ).SetEase(ease);
    }

    private void Start()
    {
        Rotate();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rotate();
        }
    }
}

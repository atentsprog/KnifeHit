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

    public float delay = 0.1f;
    private IEnumerator Start()
    {
        while(true)
        { 
            float startAngle = transform.eulerAngles.z;
            float angle = startAngle + Random.Range(minAngle, maxAngle);
            float duration = Random.Range(minDuration, maxDuration);

            bool isComplete = false;
            DOTween.To(() => startAngle
                , x => transform.rotation = Quaternion.Euler(0.0f, 0.0f, x), angle, duration
                ).SetEase(ease)
                .OnComplete(() => isComplete = true);

            while (isComplete == false)
                yield return null;
            yield return new WaitForSeconds(delay);
        }
    }
}

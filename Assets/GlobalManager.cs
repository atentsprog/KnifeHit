using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance;
    public int point;
    public int applePoint;
    public int stage = 1;


    public CanvasGroup whilteCanvasGroup;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(transform.root.gameObject);
            return;
        }

        Instance = this;
        stage = 1;
        DontDestroyOnLoad(transform.root);
    }

    internal void StageClear()
    {
        StartCoroutine(StageClearCo());
    }

    private IEnumerator StageClearCo()
    {
        stage++;
        whilteCanvasGroup.DOFade(1, 0.3f);
        yield return new WaitForSeconds(0.3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        whilteCanvasGroup.DOFade(0, 0.3f);
    }
}

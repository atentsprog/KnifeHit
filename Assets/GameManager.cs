using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject knife;

    public Image baseKnifeIcon;
    public List<Image> knifeIcons;
    public Sprite useableKnife;   // 사용가능한 칼
    public Sprite usedKnife;    // 사용한 칼
    public int wholeCount = 8;
    public RandomRotate targetBoard;
    public int usedCount = 0;
    public Text pointText;
    public Text stageText;
    public int point
    {
        get => GlobalManager.Instance.point;
        set { GlobalManager.Instance.point = value; }
    }
    public Text applePointText;

    public int applePoint
    {
        get => GlobalManager.Instance.applePoint;
        set { GlobalManager.Instance.applePoint = value; }
    }
    internal void AddPoint()
    {
        point++;
        pointText.text = point.ToString();
        if(usedCount == wholeCount)
        {
            //스테이지 클리어 표시
            Debug.LogWarning("스테이지 클리어");
            targetBoard.StopAllCoroutines();
            GlobalManager.Instance.StageClear();
        }
    }
    internal void AddApplePoint()
    {
        applePoint++;
        applePointText.text = applePoint.ToString();
    }

    private void Start()
    {
        knife.GetComponent<Move>().enabled = false;
        knife.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        InitKnifeIcons(wholeCount);

        applePointText.text = applePoint.ToString();
        pointText.text = point.ToString();

        stageText.text = "STAGE " + GlobalManager.Instance.stage.ToString();
    }


    private void InitKnifeIcons(int wholeCount)
    {
        knifeIcons.Add(baseKnifeIcon);
        for (int i = 1; i < wholeCount; i++)
        {
            knifeIcons.Add(Instantiate(baseKnifeIcon, baseKnifeIcon.transform.parent));
        }

        // 전체를 사용 가능한 칼 아이콘으로 설정
        knifeIcons.ForEach(x => x.sprite = useableKnife);
    }
    private void IncreaseUsedKnifeIcon()
    {
        knifeIcons[usedCount].sprite = usedKnife;
        usedCount++;
    }

    void Update()
    {
        if(Input.anyKeyDown)
            CreateKnife();
    }

    private void CreateKnife()
    {
        var newItem = Instantiate(knife);
        newItem.SetActive(true);
        newItem.GetComponent<Move>().enabled = true;

        newItem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        StartCoroutine(OnAndOffCo(knife));

        IncreaseUsedKnifeIcon();
        if (usedCount == wholeCount)
        {
            knife.SetActive(false);
            return;
        }
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

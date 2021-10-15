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
    public int usedCount = 0;

    private void Start()
    {
        knife.GetComponent<Move>().enabled = false;
        knife.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        InitKnifeIcons(wholeCount);
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
        if (Input.GetKeyDown(KeyCode.Space))
            CreateKnife();
    }

    private void CreateKnife()
    {
        if(usedCount == wholeCount)
        {
            return;
        }
        var newItem = Instantiate(knife);
        newItem.SetActive(true);
        newItem.GetComponent<Move>().enabled = true;

        newItem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        StartCoroutine(OnAndOffCo(knife));

        IncreaseUsedKnifeIcon();
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

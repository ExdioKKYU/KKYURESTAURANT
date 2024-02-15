using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookButton : MonoBehaviour
{
    public GameObject[] images;
    private int currentIndex = 0;

    void Start()
    {
        // 첫 번째 이미지만 활성화
        ActivateImage(currentIndex);
    }

    public void OnNextButtonClick()
    {
        // 다음 이미지로 이동
        if (currentIndex < images.Length - 1)
        {
            currentIndex++;
        }
        else
        {
            Debug.Log("마지막 이미지입니다.");
            return;
        }
        ActivateImage(currentIndex);
    }

    public void OnPreviousButtonClick()
    {
        // 이전 이미지로 이동
        if (currentIndex > 0)
        {
            currentIndex--;
        }
        else
        {
            Debug.Log("첫 번째 이미지입니다.");
            return;
        }
        ActivateImage(currentIndex);
    }

    private void ActivateImage(int index)
    {
        // 현재 인덱스의 이미지만 활성화
        for (int i = 0; i < images.Length; i++)
        {
            if (i == index)
            {
                images[i].SetActive(true);
            }
            else
            {
                images[i].SetActive(false);
            }
        }
    }
}

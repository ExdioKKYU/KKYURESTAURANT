using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;

    private bool isImage1Active = true;
    private bool isButtonClick = true;

    void Start()
    {
        image1.SetActive(true);
        image2.SetActive(false);
        image3.SetActive(false);
    }

    public void OnButtonClick()
    {
        if (isButtonClick)
        {
            if (isImage1Active)
            {
                image1.SetActive(false);
                image2.SetActive(true);
                image3.SetActive(false);
            }
            else
            {
                image1.SetActive(false);
                image2.SetActive(false);
                image3.SetActive(true);
                isButtonClick = !isButtonClick;
            }

            // 이미지 상태를 변경
            isImage1Active = !isImage1Active;

        }
    }
}

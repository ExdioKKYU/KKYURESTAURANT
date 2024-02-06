using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBookButton : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;

    private bool isImage1Active = true;

    void Start()
    {
        image1.SetActive(true);
        image2.SetActive(false);
    }

    public void OnButtonClick()
    {
        if (isImage1Active)
        {
            image1.SetActive(false);
            image2.SetActive(true);
            isImage1Active = !isImage1Active;
         }
        else
        {
            image1.SetActive(true);
            image2.SetActive(false);
            isImage1Active = !isImage1Active;
        }
    }
}

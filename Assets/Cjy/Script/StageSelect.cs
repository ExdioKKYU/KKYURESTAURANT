using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;

    void Start()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }

    public void StagePlayClick()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }

    public void StageClick()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }
}

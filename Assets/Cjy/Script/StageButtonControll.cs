using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButtonControll : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;

    public GameObject canvas3;
    public GameObject canvas4;


    void Start()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
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

    public void Book()
    {
        canvas1.SetActive(false);
        canvas3.SetActive(true);
        canvas4.SetActive(false);
    }

    public void bookOut()
    {
        canvas1.SetActive(true);
        canvas3.SetActive(false);
        canvas4.SetActive(false);
    }

    public void CookCanvusClick()
    {
        canvas3.SetActive(false);
        canvas4.SetActive(true);
    }

    public void ingredientCanvusClick()
    {
        canvas3.SetActive(true);
        canvas4.SetActive(false);
    }
}

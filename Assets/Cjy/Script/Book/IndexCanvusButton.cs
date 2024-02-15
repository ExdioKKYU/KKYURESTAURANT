using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexCanvusButton : MonoBehaviour
{

    public GameObject canvas1;
    public GameObject canvas2;

    void Start()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }

    public void CookCanvusClick()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }

    public void ingredientCanvusClick()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }

}

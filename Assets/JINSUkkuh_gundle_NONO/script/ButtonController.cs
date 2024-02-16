using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    public GameObject menuPanel;

    void Start()
    {
        menuPanel.SetActive(false);
    }

    public void Menu_button()
    {
        Time.timeScale = 0; //게임 일시정지
        menuPanel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    public void Stage()
    {
        SceneManager.LoadScene("Stage");
    }

    public void InGame1()
    {
        SceneManager.LoadScene("Fight");
    }

    public void InGame2()
    {
        SceneManager.LoadScene("pha");
    }
}

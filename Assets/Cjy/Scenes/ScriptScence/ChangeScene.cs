using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Title_Chapter()
    {
        SceneManager.LoadScene("Chapter");
    }

    public void Chapter_Stage()
    {
        SceneManager.LoadScene("Stage");
    }

    public void Stage_InGame()
    {
        SceneManager.LoadScene("CJY");
    }

    public void book()
    {
        SceneManager.LoadScene("Book");
    }
}

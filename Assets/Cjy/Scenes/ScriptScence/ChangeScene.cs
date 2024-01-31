using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{


    public void Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void Stage()
    {
        SceneManager.LoadScene("Stage");
    }

    public void InGame()
    {
        SceneManager.LoadScene("CJY");
        Debug.Log("√º¿Œ¡ˆ æ¿");
    }

    public void book()
    {
        SceneManager.LoadScene("Book");
    }
}

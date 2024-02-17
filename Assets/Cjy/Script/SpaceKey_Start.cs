using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Textblink : MonoBehaviour
{
    Text flashingText;

    void Start()
    {
        flashingText = GetComponent<Text>();

        StartCoroutine(BlinkText());

    }
    public IEnumerator BlinkText()
    {
        while (true)
        {
            flashingText.text = "";

            yield return new WaitForSeconds(.5f);

            flashingText.text = "Touch to Start";

            yield return new WaitForSeconds(.5f);

        }
    }
}
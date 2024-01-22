using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class LineSelection  : MonoBehaviour
{
    public Line line;

    public GameObject Recall;
    

    private void Start()
    {

    }

    private void OnMouseUpAsButton()
    {
        DataMgr.instance.currentLine = line;
        Debug.Log("linechange");

        Recall.GetComponent<RecallUnit>().Call();

    }
}

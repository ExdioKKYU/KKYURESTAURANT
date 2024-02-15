using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringToFront : MonoBehaviour
{
    void Start()
    {
        // 패널의 SortingOrder를 최상위로 변경
        GetComponent<Renderer>().sortingOrder = 999;
    }
}

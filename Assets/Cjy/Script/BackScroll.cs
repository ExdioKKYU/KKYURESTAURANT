using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSwipe : MonoBehaviour
{
    public float swipeSpeed = 1.0f;
    private Vector3 touchStartPos;
    private Vector3 previousTouchPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPos = Input.mousePosition;
            previousTouchPos = touchStartPos;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentTouchPos = Input.mousePosition;
            Vector3 swipeDirection = (currentTouchPos - previousTouchPos) * swipeSpeed * Time.deltaTime;
            transform.position += swipeDirection;
            previousTouchPos = currentTouchPos;
        }
    }
}

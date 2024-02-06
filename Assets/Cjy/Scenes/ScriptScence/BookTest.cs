using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BookTest : MonoBehaviour
{
    [SerializeField] float pagesSpeed = 0.5f;
    [SerializeField] List<Transform> pages;  // RectTransform 대신 Transform을 사용

    int index = 0;
    bool isRotating = false;

    public void RotateForward()
    {
        if (!isRotating && index < pages.Count - 1)
        {
            float angle = 180f;
            StartCoroutine(Rotate(angle, true));
        }
        else if (index >= pages.Count - 1)
        {
            Debug.LogWarning("더 이상 앞으로 돌릴 수 없습니다. 마지막 페이지에 도달했습니다.");
        }
    }

    public void RotateBack()
    {
        if (!isRotating && index > 0)
        {
            float angle = 0f;
            StartCoroutine(Rotate(angle, false));
        }
        else if (index <= 0)
        {
            Debug.LogWarning("더 이상 뒤로 돌릴 수 없습니다. 이미 첫 페이지에 있습니다.");
        }
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        if (isRotating)
        {
            Debug.LogWarning("이미 회전 중입니다.");
            yield break;
        }

        isRotating = true;

        if (forward)
        {
            index++;
            if (index >= pages.Count)
            {
                index = pages.Count - 1;
                isRotating = false;
                yield break;
            }
        }
        else
        {
            index--;
            if (index < 0)
            {
                index = 0;
                isRotating = false;
                yield break;
            }
        }

        float value = 0f;
        while (value < 1f)
        {
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pagesSpeed;
            value = Mathf.Clamp01(value);

            if (index >= 0 && index < pages.Count)
            {
                pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value);

                float angleDiff = Quaternion.Angle(pages[index].rotation, targetRotation);
                if (angleDiff < 0.1f)
                {
                    // 인덱스가 변경되었으므로 코루틴 종료
                    break;
                }
            }
            else
            {
                Debug.LogError("유효하지 않은 인덱스: " + index);
                // 인덱스가 잘못되면 코루틴 종료
                break;
            }

            yield return null;
        }

        isRotating = false; // 회전이 끝났으므로 플래그를 false로 설정
    }
}

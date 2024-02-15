using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSwipe : MonoBehaviour
{
    private Vector3 touchStart;
    private float zDistance;
    private float minX = -29f;  // x 좌표의 최소값
    private float maxX = 29f;   // x 좌표의 최대값

    void Start()
    {
        zDistance = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    void Update()
    {
        // 화면 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            // 클릭 시작 위치 기록
            if (IsMouseInAllowedArea(Input.mousePosition))
            {
                touchStart = GetWorldPositionOnPlane(Input.mousePosition, zDistance);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            // 화면 터치 입력 감지
            if (IsMouseInAllowedArea(Input.mousePosition))
            {
                // 스와이프 거리 계산
                Vector3 direction = touchStart - GetWorldPositionOnPlane(Input.mousePosition, zDistance);
                direction.y = 0f; // y축 이동 방지

                // 배경을 부드럽게 좌우로 스와이프
                Camera.main.transform.position += direction;

                // x 좌표에 대한 제한
                Vector3 newPosition = Camera.main.transform.position + direction;
                newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

                // 부드러운 이동 적용
                Camera.main.transform.position = newPosition;

                // 현재 위치를 다음 프레임의 시작 위치로 업데이트
                touchStart = GetWorldPositionOnPlane(Input.mousePosition, zDistance);
            }
        }
    }

    bool IsMouseInAllowedArea(Vector3 mousePosition)
    {
        Vector3 worldPosition = GetWorldPositionOnPlane(mousePosition, zDistance);

        // 특정 위치(예: y좌표가 -3.5 미만인 경우)에서 드래그를 막음
        if (worldPosition.y < -3.2f)
        {
            return false;
        }

        // 나머지 영역은 드래그를 허용
        return true;
    }

    Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.up, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}

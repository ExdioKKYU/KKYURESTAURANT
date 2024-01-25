using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBack : MonoBehaviour
{
    public float swipeSpeed = 5.0f;
    public float smoothTime = 0.3f; // 부드러운 이동을 위한 시간
    public float minX = -25f; // x 좌표의 최소값
    public float maxX = 35f; // x 좌표의 최대값
    public ParticleSystem clickEffect; // 클릭 시 재생될 시펙트

    private Vector2 touchStartPos;
    private Vector3 velocity = Vector3.zero; // 이동 속도를 저장하는 변수

    void Update()
    {
        // 화면 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            // 클릭 시작 위치 기록
            touchStartPos = Input.mousePosition;

            // 클릭 시펙트 재생
            if (clickEffect != null)
            {
                Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                clickPosition.z = 0;
                Instantiate(clickEffect, clickPosition, Quaternion.identity);
            }
        }

        // 화면 터치 입력 감지
        if (Input.GetMouseButton(0))
        {
            // 스와이프 거리 계산
            float swipeDistance = Input.mousePosition.x - touchStartPos.x;

            // 배경을 부드럽게 좌우로 스와이프
            float targetX = transform.position.x + swipeDistance * swipeSpeed * Time.deltaTime;
            targetX = Mathf.Clamp(targetX, minX, maxX); // x 좌표에 대한 제한

            // 부드러운 이동 적용
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), ref velocity, smoothTime);

            // 현재 위치를 다음 프레임의 시작 위치로 업데이트
            touchStartPos = Input.mousePosition;
        }
    }

}

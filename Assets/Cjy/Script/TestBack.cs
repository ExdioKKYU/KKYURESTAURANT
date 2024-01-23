using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBack : MonoBehaviour
{
    public float swipeSpeed = 5.0f;
    public ParticleSystem clickEffect; // 클릭 시 재생될 시펙트

    private Vector2 touchStartPos;

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

            // 배경을 좌우로 스와이프
            transform.Translate(Vector3.right * swipeDistance * swipeSpeed * Time.deltaTime);

            // 현재 위치를 다음 프레임의 시작 위치로 업데이트
            touchStartPos = Input.mousePosition;

            // 화면 끝에 도달했을 때 스와이프 중지
            if (Mathf.Abs(transform.position.x) >= 29f && Mathf.Abs(transform.position.x) <= -29f) // 예시로 x좌표가 5.0f 이상이면 중지
            {
                transform.position = new Vector3(Mathf.Sign(transform.position.x) * 5.0f, transform.position.y, transform.position.z);
            }
        }
    }
}

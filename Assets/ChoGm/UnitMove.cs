using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    public float moveSpeed;
    private float speed;
    public float rangeUnit;   // 유닛의 사거리에 따른 스크립트 받아오기

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;    // 유닛의 사거리에 따른 스크립트 받아오기
    }

    // Update is called once per frame
    void Update()
    {
        // EnemyInit를 가지고 있는 모든 오브젝트를 찾음
        EnemyInit[] closeUnits = FindObjectsOfType<EnemyInit>();

        // Set the default speed
        speed = moveSpeed;

        foreach (EnemyInit unit in closeUnits)
        {
            // 현재 유닛과 각 적의 거리를 계산
            float distanceX = Mathf.Abs(transform.position.x - unit.transform.position.x);
            float distanceY = Mathf.Abs(transform.position.y - unit.transform.position.y);

            // X 축 거리가 사거리 이내이고 Y 축 거리가 0일 때만 속도를 0으로 설정
            if (distanceX <= rangeUnit && Mathf.Approximately(distanceY, 0))
            {
                speed = 0;
            }
        }

        // Move the unit based on the calculated speed
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
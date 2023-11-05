using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UnitMove의 스크립트 주석 참고
public class EnemyMove : MonoBehaviour
{
    private float moveSpeed;
    private float speed;
    private float rangeEnemy;   //유닛의 사거리에 따른 스크립트 받아오기
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3.0f;
        speed = 0;
        rangeEnemy = 3.0f;      //유닛의 사거리에 따른 스크립트 받아오기
    }

    // Update is called once per frame
    void Update()
    {
        // EnemyInit를 가지고 있는 모든 오브젝트를 찾음
        UnitInit floatCloseUnit = GameObject.FindObjectOfType<UnitInit>();

        //EnemyInit를 가지고 있는 오브젝트와의 거리를 계산
        float closeDistanceX = Mathf.Abs(transform.position.x - floatCloseUnit.transform.position.x);
        float closeDistanceY = Mathf.Abs(transform.position.y - floatCloseUnit.transform.position.y);

        //EnemyInit를 가지고 있는 오브젝트와의 거리와 나의 사거리를 비교해 이동
        if (closeDistanceX <= rangeEnemy)
        {
            speed = 0;
        }
        if (closeDistanceX >= rangeEnemy)
        {
            speed = -moveSpeed;
        }
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    private float moveSpeed;
    private float speed;
    private float rangeUnit;   //유닛의 사거리에 따른 스크립트 받아오기
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 4.0f;
        speed = 0;
        rangeUnit = 6.5f;      //유닛의 사거리에 따른 스크립트 받아오기
    }

    // Update is called once per frame
    void Update()
    {
        // EnemyInit를 가지고 있는 모든 오브젝트를 찾음
        EnemyInit floatCloseEnemy = GameObject.FindObjectOfType <EnemyInit> ();

        //EnemyInit를 가지고 있는 오브젝트와의 거리를 계산
        float closeDistance = Vector3.Distance(transform.position, floatCloseEnemy.transform.position);

        //EnemyInit를 가지고 있는 오브젝트와의 거리와 나의 사거리를 비교해 이동
        if (closeDistance <= rangeUnit)
        {
            speed = 0;
        }
        if (closeDistance >= rangeUnit)
        {
            speed = moveSpeed;
        }
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}

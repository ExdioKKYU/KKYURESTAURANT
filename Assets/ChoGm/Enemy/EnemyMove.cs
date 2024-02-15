using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UnitMove의 스크립트 주석 참고
public class EnemyMove : MonoBehaviour
{
    public float moveSpeed;
    public float speed;
    public float rangeEnemy;   // 유닛의 사거리에 따른 스크립트 받아오기

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        speed = 0;   // 유닛의 사거리에 따른 스크립트 받아오기
    }

    // Update is called once per frame
    void Update()
    {
        // EnemyInit를 가지고 있는 모든 오브젝트를 찾음
        UnitInit[] closeUnits = FindObjectsOfType<UnitInit>();

        // Set the default speed
        speed = moveSpeed;

        foreach (UnitInit unit in closeUnits)
        {
            // 현재 유닛과 각 적의 거리를 계산
            float distanceX = Mathf.Abs(transform.position.x - unit.transform.position.x);
            float distanceY = Mathf.Abs(transform.position.y - unit.transform.position.y);

            // X 축 거리가 사거리 이내이고 Y 축 거리가 0일 때만 속도를 0으로 설정
            if (distanceX <= rangeEnemy && Mathf.Approximately(distanceY, 0))
            {
                speed = 0;
            }
            if (speed <= 0.01)
            {
                animator.SetBool("Walk", false);
            }
        }


        if (speed <= 0.01)
        {
            animator.SetBool("Walk", false);
        }
        if (speed > 0.1)
        {
            animator.SetBool("Walk", true);
        }

        // Move the unit based on the calculated speed
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
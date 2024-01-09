using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_short_atk : MonoBehaviour
{
    public float AT_sp_e;      // 공격속도
    public float range_e;      // 사정 거리
    public float ATK_S_e;


    private bool attack;
    private float my_at_sp;

    Animator animator;
    Transform floatCloseEnemy; // 타입을 Transform으로 변경

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        my_at_sp = 0.0f;
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        my_at_sp += Time.deltaTime; // 공격속도 딜레이 계산

      

        Ability[] floatCloseEnemies = GameObject.FindObjectsOfType<Ability>();

        // 모든 적에 대해 반복
        foreach (Ability floatCloseEnemy in floatCloseEnemies)
        {
            // 추가: 같은 열에 위치한지 확인
            if (Mathf.Approximately(transform.position.y, floatCloseEnemy.transform.position.y))
            {
                // 해당 스크립트를 가지고 있는 오브젝트와의 거리를 계산
                float closeDistance = Vector3.Distance(transform.position, floatCloseEnemy.transform.position);

                //해당 스크립트를 가지고 있는 오브젝트와의 거리와 나의 사거리를 비교해 공격 가능 여부 결정
                if (closeDistance <= range_e)
                {
                    attack = true;
                    animator.SetBool("Attack", true);
                    this.floatCloseEnemy = floatCloseEnemy.transform; // floatCloseEnemy에 Transform 할당
                    if (attack && my_at_sp >= AT_sp_e)
                    {
                        floatCloseEnemy.short_hurt(ATK_S_e);
                        my_at_sp = 0.0f;

                    }
                    break; // 이미 하나의 유닛에 대해 공격이 결정되었으므로 루프를 종료합니다.
                }
                else
                {
                    attack = false;
                    animator.SetBool("Attack", false);
                }
            }
        }

       
    }
}

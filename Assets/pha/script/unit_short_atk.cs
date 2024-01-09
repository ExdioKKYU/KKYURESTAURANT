using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_short_atk : MonoBehaviour
{
    public float AT_sp;      // 공격속도
    public float range;      // 사정 거리
    public float ATK_S;


    private bool attack;
    private float my_at_sp;

    Animator animator;
    Transform enemy;

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


        Ability_enemy[] enemies = GameObject.FindObjectsOfType<Ability_enemy>();

        // 모든 적에 대해 반복
        foreach (Ability_enemy enemy in enemies)
        {
            // 추가: 같은 열에 위치한지 확인
            if (Mathf.Approximately(transform.position.y, enemy.transform.position.y))
            {
                // 해당 스크립트를 가지고 있는 오브젝트와의 거리를 계산
                float closeDistance = Vector3.Distance(transform.position, enemy.transform.position);

                //해당 스크립트를 가지고 있는 오브젝트와의 거리와 나의 사거리를 비교해 공격 가능 여부 결정
                if (closeDistance <= range)
                {
                    attack = true;
                    animator.SetBool("Attack", true);
                    this.enemy = enemy.transform;
                    if (enemy != null && my_at_sp >= AT_sp)    //사거리 안에 적이 있고 공격속도를 충족하면 공격
                    {
                        Debug.Log("단거리 공격");
                        enemy.short_hurt(ATK_S);
                        my_at_sp = 0.0f;

                        break;
                    }
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

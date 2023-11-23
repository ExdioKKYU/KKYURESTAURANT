using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit_short_atk : MonoBehaviour
{
    public float AT_sp;      // 공격속도
    public float range;      // 사정 거리
    
    public int num;       // 유닛들 중 번호를 매겨 어느 유닛인지 판별 위함

    private bool attack;
    private float my_at_sp;



    // Start is called before the first frame update
    void Start()
    {
        my_at_sp = 0.0f;

        attack = false;

    }

    // Update is called once per frame
    void Update()
    {
        my_at_sp += Time.deltaTime;     // 공격속도 딜레이 계산

        ability_enemy floatCloseEnemy = GameObject.FindObjectOfType<ability_enemy>();

        //해당 스크립트를 가지고 있는 오브젝트와의 거리를 계산
        float closeDistance = Vector3.Distance(transform.position, floatCloseEnemy.transform.position);

        //해당 스크립트를 가지고 있는 오브젝트와의 거리와 나의 사거리를 비교해 공격 가능 여부 결정
        if (closeDistance <= range)
        {
            attack = true;
        }
        else
        {
            attack = false;
        }

        if (attack == true && my_at_sp >= AT_sp)    //사거리 안에 적이 있고 공격속도를 충족하면 공격
        {
            FindTarget();
            my_at_sp = 0.0f;
        }

    }

    private void FindTarget()
    {
        ability_enemy[] enemies = GameObject.FindObjectsOfType<ability_enemy>();
        float closestDistance = float.MaxValue;
        ability_enemy closestEnemy = null;

        foreach (ability_enemy enemy in enemies)
        {
            // 현재 유닛과 적군 간의 거리를 계산
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            // 적군과의 거리가 현재까지의 최소 거리보다 작다면 업데이트
            if (distance < closestDistance)
            {
                // 추가: 같은 열에 위치한지 확인
                if (Mathf.Approximately(transform.position.y, enemy.transform.position.y))
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }

        // closestEnemy에 가장 가까운 오브젝트가 저장됩니다.

        // closestEnemy가 null이 아니면서 ability_enemy 컴포넌트를 가지고 있는지 확인
        ability_enemy closestAbilityComponent = closestEnemy?.GetComponent<ability_enemy>();
        if (closestAbilityComponent != null)
        {
            closestAbilityComponent.short_hurt(num);
        }
    }

}

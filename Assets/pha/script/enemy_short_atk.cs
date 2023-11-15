using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_short_atk : MonoBehaviour
{
    public float AT_sp_e;      // 공격속도
    public float range_e;      // 사정 거리

    public int num;       // 유닛들 중 번호를 매겨 어느 유닛인지 판별 위함

    private bool attack;
    private float e_at_sp;

    // Start is called before the first frame update
    void Start()
    {
        e_at_sp = 0.0f;

        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        e_at_sp += Time.deltaTime;     // 공격속도 딜레이 계산

        ability floatCloseEnemy1 = GameObject.FindObjectOfType<ability>();

        //해당 스크립트를 가지고 있는 오브젝트와의 거리를 계산
        float closeDistance1 = Vector3.Distance(transform.position, floatCloseEnemy1.transform.position);

        //해당 스크립트를 가지고 있는 오브젝트와의 거리와 나의 사거리를 비교해 공격 가능 여부 결정
        if (closeDistance1 <= range_e)
        {
            attack = true;
        }
        else
        {
            attack = false;
        }

        if (attack == true && e_at_sp >= AT_sp_e)    //사거리 안에 적이 있고 공격속도를 충족하면 공격
        {
            FindTarget1();
            e_at_sp = 0.0f;
        }
    }

    private void FindTarget1()
    {
        ability[] enemies = GameObject.FindObjectsOfType<ability>();
        float closestDistance1 = float.MaxValue;
        ability closestEnemy1 = null;

        foreach (ability enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance1)
            {
                closestDistance1 = distance;
                closestEnemy1 = enemy;
            }
        }
        // closestEnemy에 가장 가까운 오브젝트가 저장됩니다.

        ability closestAbilityComponent = closestEnemy1.GetComponent<ability>();
        if (closestAbilityComponent != null)
        {
            closestAbilityComponent.short_hurt(num);
        }


    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_long_atk : MonoBehaviour
{
    public float AT_sp_e;      // 공격속도
    public float range_e;      // 사정 거리

    private bool attack;
    private float my_at_sp;

    public GameObject str_Prefab;
    public Transform pos;

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

        // 주변에 있는 모든 ability_float_close 오브젝트를 배열로 가져옴
        ability[] floatCloseEnemies = GameObject.FindObjectsOfType<ability>();

        // 모든 적에 대해 반복
        foreach (ability floatCloseEnemy in floatCloseEnemies)
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
                    break; // 이미 하나의 유닛에 대해 공격이 결정되었으므로 루프를 종료합니다.
                }
                else
                {
                    attack = false;
                }
            }
        }

        if (attack && my_at_sp >= AT_sp_e)    //사거리 안에 적이 있고 공격속도를 충족하면 공격
        {
            Instantiate(str_Prefab, pos.position, transform.rotation);
            my_at_sp = 0.0f;
        }
    }
}

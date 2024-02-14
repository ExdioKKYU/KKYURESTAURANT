using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimbob_long_attack : MonoBehaviour
{
    public float AT_sp;      // 공격속도
    public float range;      // 사정 거리

    public GameObject str_Prefab;
    public Transform pos;

    private bool attack;
    private float my_at_sp;

    Animator animator;

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
        my_at_sp += Time.deltaTime;     // 공격속도 딜레이 계산

        // 주변에 있는 모든 ability_enemy 오브젝트를 배열로 가져옴
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
                    Debug.Log("장거리 공격");
                    break; // 이미 하나의 유닛에 대해 공격이 결정되었으므로 루프를 종료합니다.
                }
                else
                {
                    attack = false;
                    animator.SetBool("Attack", false);
                }
            }
        }
        //이거때문에 스크립트를 하나 더 만들어야하나...
        //총알 위치의 Y값 고려할것
        if (attack && my_at_sp >= AT_sp)
        {
            Vector3 spawnPosition1 = new Vector3(pos.position.x, 1f, pos.position.z);
            Vector3 spawnPosition2 = new Vector3(pos.position.x, -0.8f, pos.position.z);
            Vector3 spawnPosition3 = new Vector3(pos.position.x, -2.6f, pos.position.z);
            Instantiate(str_Prefab, spawnPosition1, transform.rotation);
            Instantiate(str_Prefab, spawnPosition2, transform.rotation);
            Instantiate(str_Prefab, spawnPosition3, transform.rotation);
            my_at_sp = 0.0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit_long_atk : MonoBehaviour
{
    public float AT_sp;      // 공격속도
    public float range;      // 사정 거리

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
            GameObject str_shot = Instantiate(str_Prefab, pos.position, transform.rotation);
            my_at_sp = 0.0f;
        }
    }
}

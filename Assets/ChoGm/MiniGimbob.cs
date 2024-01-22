using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGimbob : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //애니메이션 조건 확인
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Ability_enemy abilityEnemy = collision.GetComponent<Ability_enemy>();
        if (abilityEnemy != null)
        {
            // HP_e 값이 10 감소
            abilityEnemy.HP_e -= 10;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TABLE"))
        {
            GetComponent<UnitMove>().moveSpeed = 7.0f;
            GetComponent<UnitMove>().rangeUnit = 0.0f;
            GetComponent<Unit_short_atk>().ATK_S = 0.0f;
            GetComponent<Unit_short_atk>().AT_sp = 0.0f;
            GetComponent<Unit_short_atk>().range = 0.0f;
        }
    }
}

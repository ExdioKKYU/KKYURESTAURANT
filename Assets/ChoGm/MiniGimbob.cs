using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGimbob : MonoBehaviour
{
    public float Damage;
    private float Attack_Move_Speed;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Attack_Move_Speed = 0.0f;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Attack_Move_Speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Ability_enemy abilityEnemy = collision.GetComponent<Ability_enemy>();
        if (abilityEnemy != null)
        {
            // HP_e 값이 10 감소
            abilityEnemy.HP_e -= Damage;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Table"))
        {
            GetComponent<UnitMove>().moveSpeed = 0.0f;
            GetComponent<UnitMove>().rangeUnit = 0.0f;
            GetComponent<Unit_short_atk>().ATK_S = 0.0f;
            GetComponent<Unit_short_atk>().AT_sp = 0.0f;
            GetComponent<Unit_short_atk>().range = 9999.0f;
            Attack_Move_Speed = 7.0f;
        }
    }
}

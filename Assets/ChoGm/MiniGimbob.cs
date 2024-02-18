using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGimbob : MonoBehaviour
{
    public float Damage;
    public float Attack_speed;
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
        UnitMove unitMove = GetComponent<UnitMove>();
        float moveSpeed = unitMove.moveSpeed;
        if (Attack_Move_Speed == 0)
        {
            Attack();
        }
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
            Attack();
        }
        if (collision.CompareTag("Line"))
        {
            Destroy(gameObject, 1.0f);
        }
    }

    void Attack()
    {
        GetComponent<UnitMove>().moveSpeed = 0.0f;
        GetComponent<UnitMove>().rangeUnit = 0.0f;
        Unit_short_atk unit_short_atk = GetComponent<Unit_short_atk>();
        if (unit_short_atk != null)
            Destroy(unit_short_atk);
        Attack_Move_Speed = Attack_speed;
    }
}

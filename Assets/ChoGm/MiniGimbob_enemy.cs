using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGimbob_enemy : MonoBehaviour
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
        EnemyMove enemyMove = GetComponent<EnemyMove>();
        float moveSpeed = enemyMove.moveSpeed;
        if (Attack_Move_Speed == 0)
        {
            Attack();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Ability ability = collision.GetComponent<Ability>();
        if (ability != null)
        {
            // HP_e 값이 10 감소
            ability.HP -= Damage;
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
        GetComponent<EnemyMove>().moveSpeed = 0.0f;
        GetComponent<EnemyMove>().rangeEnemy = 0.0f;
        Attack_Move_Speed = -7.0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimbobBullet : MonoBehaviour
{
    public float speed;
    public float damage;
    public float direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Ability_enemy abilityEnemy = collision.GetComponent<Ability_enemy>();
        if (abilityEnemy != null)
        {
            // HP_e 값이 10 감소
            abilityEnemy.HP_e -= damage;
        }
    }

}
//김밥의 애니메이션 생각하기
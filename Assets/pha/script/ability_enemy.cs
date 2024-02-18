using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_enemy : MonoBehaviour
{
    public float HP_e;
    public float DEF_e;

    public float Hit_e;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    { 
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HP_e <= 0)   //체력이 0이 되면 사라짐
        {
            GetComponent<Death>().enabled = true;
        }
    }

    public void long_hit(float x)
    {
        Hit_e = x;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "shot1(Clone)")   //튀김가루
        //부딪힌 객체의 태그를 비교해서 총알인지 판단합니다.
        {
            Dex_atk enemyScript = other.gameObject.GetComponent<Dex_atk>();

            // 스크립트가 존재하면 변수에 접근 가능
            if (enemyScript != null)
            {
                // 여기에서 enemyScript의 변수에 접근하여 사용
                Hit_e = enemyScript.ATK_L;
            }

            // 체력 - (적의 공격력 - 자신의 방어력)
            HP_e -= Hit_e - (Hit_e * DEF_e);

            sprite.color = Color.red;   //공격당하면 색이 변함
            Invoke("color", 0.2f);

            //총알을 파괴합니다.
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot2(Clone)")   //면
        {
            Dex_atk enemyScript = other.gameObject.GetComponent<Dex_atk>();

            // 스크립트가 존재하면 변수에 접근 가능
            if (enemyScript != null)
            {
                // 여기에서 enemyScript의 변수에 접근하여 사용
                Hit_e = enemyScript.ATK_L;
            }

            HP_e -= Hit_e - (Hit_e * DEF_e);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot3(Clone)")   //소떡소떡
        {
            Dex_atk enemyScript = other.gameObject.GetComponent<Dex_atk>();

            // 스크립트가 존재하면 변수에 접근 가능
            if (enemyScript != null)
            {
                // 여기에서 enemyScript의 변수에 접근하여 사용
                Hit_e = enemyScript.ATK_L;
            }

            HP_e -= Hit_e - (Hit_e * DEF_e);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot4(Clone)")   //라볶이
        {
            Dex_atk enemyScript = other.gameObject.GetComponent<Dex_atk>();

            // 스크립트가 존재하면 변수에 접근 가능
            if (enemyScript != null)
            {
                // 여기에서 enemyScript의 변수에 접근하여 사용
                Hit_e = enemyScript.ATK_L;
            }

            HP_e -= Hit_e - (Hit_e * DEF_e);
            Destroy(other.gameObject);
        }
    }

    public void short_hurt(float hit)
    {

        Debug.Log("공격 받음");
        HP_e -= hit - (hit * DEF_e);
        sprite.color = Color.red;
        Invoke("color", 0.2f);
        
    }

    public void color()
    {
        sprite.color = Color.cyan;
    }
}

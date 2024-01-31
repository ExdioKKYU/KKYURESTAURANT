using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public float HP;         // 체력
    public float DEF;        // 방어력

    public float Hit;

    SpriteRenderer sprite;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)   //체력이 0이 되면 사라짐
        {
            GetComponent<Death>().enabled = true;
        }
    }

    public void long_hit(float x)
    {
        Hit = x;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "shot1_e(Clone)")   //튀김가루
        //부딪힌 객체의 태그를 비교해서 총알인지 판단합니다.
        {
            Dex_atk_e enemyScript = other.gameObject.GetComponent<Dex_atk_e>();

            // 스크립트가 존재하면 변수에 접근 가능
            if (enemyScript != null)
            {
                // 여기에서 enemyScript의 변수에 접근하여 사용
                Hit = enemyScript.ATK_L_e;
            }

            // 체력 - (적의 공격력 - 자신의 방어력)
            HP -= Hit - (Hit * DEF);
            sprite.color = Color.red;   //공격당하면 색이 변함
            Invoke("color", 0.2f);

            //총알을 파괴합니다.
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot2_e(Clone)")   //면
        {
            Dex_atk_e enemyScript = other.gameObject.GetComponent<Dex_atk_e>();

            // 스크립트가 존재하면 변수에 접근 가능
            if (enemyScript != null)
            {
                // 여기에서 enemyScript의 변수에 접근하여 사용
                Hit = enemyScript.ATK_L_e;
            }

            HP -= Hit - (Hit * DEF);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot3_e(Clone)")   //소떡소떡
        {
            Dex_atk_e enemyScript = other.gameObject.GetComponent<Dex_atk_e>();

            // 스크립트가 존재하면 변수에 접근 가능
            if (enemyScript != null)
            {
                // 여기에서 enemyScript의 변수에 접근하여 사용
                Hit = enemyScript.ATK_L_e;
            }

            HP -= Hit - (Hit * DEF);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot4_e(Clone)")   //라볶이
        {
            Dex_atk_e enemyScript = other.gameObject.GetComponent<Dex_atk_e>();

            // 스크립트가 존재하면 변수에 접근 가능
            if (enemyScript != null)
            {
                // 여기에서 enemyScript의 변수에 접근하여 사용
                Hit = enemyScript.ATK_L_e;
            }

            HP -= Hit - (Hit * DEF);
            Destroy(other.gameObject);
        }
    }

    public void short_hurt(float hit)
    {
        HP -= hit - (hit * DEF);
        sprite.color = Color.red;   //공격당하면 색이 변함
        Invoke("color", 0.2f);
   
    }

    public void color()
    {
        sprite.color = Color.white;
    }
}

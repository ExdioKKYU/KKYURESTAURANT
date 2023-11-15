using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability : MonoBehaviour
{
    public float HP;         // 체력
    public float ATK;        // 공격력
    public float DEF;        // 방어력

    GameObject flying_F_e;
    GameObject noodle_e;
    GameObject sotsot_e;
    GameObject rtbk_e;

    GameObject obj;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        flying_F_e = GameObject.Find("Frying_flour_enemy");
        noodle_e = GameObject.Find("Noodle_enemy");
        sotsot_e = GameObject.Find("Sotteok_Sotteok_enemy");
        rtbk_e = GameObject.Find("Laboki_enemy");

        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)   //체력이 0이 되면 사라짐
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "shot1_e(Clone)")   //튀김가루
        //부딪힌 객체의 태그를 비교해서 총알인지 판단합니다.
        {
            // 체력 - (적의 공격력 - 자신의 방어력)
            HP -= (flying_F_e.GetComponent<ability_enemy>().ATK_e - DEF);
            sprite.color = Color.red;   //공격당하면 색이 변함
            Invoke("color", 0.2f);

            //총알을 파괴합니다.
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot2_e(Clone)")   //면
        {
            HP -= (noodle_e.GetComponent<ability_enemy>().ATK_e - DEF);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot3_e(Clone)")   //소떡소떡
        {
            HP -= (sotsot_e.GetComponent<ability_enemy>().ATK_e - DEF);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot4_e(Clone)")   //라볶이
        {
            HP -= (rtbk_e.GetComponent<ability_enemy>().ATK_e - DEF);
            Destroy(other.gameObject);
        }
    }

    public void short_hurt(int x)
    {
        switch (x)
        {
            case 1:     //밥

                obj = GameObject.Find("Bob_enemy");
                break;

            case 2:     //돼지고기

                obj = GameObject.Find("Pork_enemy");
                break;

            case 3:     //김
                break;
            case 4:     //고구마
                break;
            case 5:     //소시지
                break;
            case 6:     //당근
                break;
            case 7:     //떡
                break;
            case 8:     //비법소스
                break;
            case 9:     //계란
                break;
            case 10:    //오뎅
                break;
            case 11:    //김밥
                break;
            case 12:    //돈까스
                break;
            case 13:    //고구마튀김
                break;
            case 14:    //꼬마김밥
                break;
            case 15:    //떡볶이
                break;
            case 16:    //오므라이스
                break;
            case 17:    //라면
                break;

        }

        HP -= (obj.GetComponent<ability_enemy>().ATK_e - (obj.GetComponent<ability_enemy>().ATK_e * DEF));
        sprite.color = Color.red;   //공격당하면 색이 변함
        Invoke("color", 0.2f);
    }

    public void color()
    {
        sprite.color = Color.white;
    }
}

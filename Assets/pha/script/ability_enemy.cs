using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability_enemy : MonoBehaviour
{
    public float HP_e;
    public float ATK_e;
    public float DEF_e;

    GameObject flying_F;
    GameObject noodle;
    GameObject sotsot;
    GameObject rtbk;

    GameObject obj;

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        flying_F = GameObject.Find("Frying_flour");
        noodle = GameObject.Find("Noodle");
        sotsot = GameObject.Find("Sotteok_Sotteok");
        rtbk = GameObject.Find("Laboki");
        // 원거리 유닛들을 불러옴

        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HP_e <= 0)   //체력이 0이 되면 사라짐
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "shot1(Clone)")   //튀김가루
        //부딪힌 객체의 태그를 비교해서 총알인지 판단합니다.
        {
            // 체력 - (적의 공격력 - 자신의 방어력)
            HP_e -= (flying_F.GetComponent<ability>().ATK - (flying_F.GetComponent<ability>().ATK * DEF_e));

            sprite.color = Color.red;   //공격당하면 색이 변함
            Invoke("color", 0.2f);

            //총알을 파괴합니다.
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot2(Clone)")   //면
        {
            HP_e -= (noodle.GetComponent<ability>().ATK - (noodle.GetComponent<ability>().ATK  * DEF_e));
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot3(Clone)")   //소떡소떡
        {
            HP_e -= (sotsot.GetComponent<ability>().ATK - (sotsot.GetComponent<ability>().ATK * DEF_e));
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot4(Clone)")   //라볶이
        {
            HP_e -= (rtbk.GetComponent<ability>().ATK - (rtbk.GetComponent<ability>().ATK * DEF_e));
            Destroy(other.gameObject);
        }
    }

    public void short_hurt(int x)
    {
        switch (x)
        {
            case 1:     //밥

                obj = GameObject.Find("Bob");
                break;

            case 2:     //돼지고기

                obj = GameObject.Find("Pork");
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
            default:
                // 기본적으로 할당할 오브젝트가 없을 경우 null로 설정하거나, 다른 처리를 수행할 수 있습니다.
                obj = null;
                break;
        }

        if (obj != null)
        {
            HP_e -= (obj.GetComponent<ability>().ATK - (obj.GetComponent<ability>().ATK * DEF_e));
            sprite.color = Color.red;
            Invoke("color", 0.2f);
        }
    }

    public void color()
    {
        sprite.color = Color.cyan;
    }
}

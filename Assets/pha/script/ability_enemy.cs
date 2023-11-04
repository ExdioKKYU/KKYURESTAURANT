using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability_enemy : MonoBehaviour
{
    public float HP_e;
    public float ATK_e;
    public float DEF_e;
    public float AT_sp_e;
    public float range_e;

    GameObject flying_F;
    GameObject noodle;
    GameObject sotsot;
    GameObject rtbk;
    // Start is called before the first frame update
    void Start()
    {
        flying_F = GameObject.Find("Frying_flour");
        noodle = GameObject.Find("Noodle");
        sotsot = GameObject.Find("Sotteok_Sotteok");
        rtbk = GameObject.Find("Laboki");
        // 원거리 유닛들을 불러옴
        
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
            HP_e -= (flying_F.GetComponent<ability>().ATK - DEF_e);
            
            //총알을 파괴합니다.
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot2")   //면
        {
            HP_e -= (noodle.GetComponent<ability>().ATK - DEF_e);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot3")   //소떡소떡
        {
            HP_e -= (sotsot.GetComponent<ability>().ATK - DEF_e);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot4")   //라볶이
        {
            HP_e -= (rtbk.GetComponent<ability>().ATK - DEF_e);
            Destroy(other.gameObject);
        }
    }
}

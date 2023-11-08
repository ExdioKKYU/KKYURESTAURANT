using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability : MonoBehaviour
{
    public float HP;         // Ã¼·Â
    public float ATK;        // °ø°Ý·Â
    public float DEF;        // ¹æ¾î·Â

    GameObject flying_F_e;
    GameObject noodle_e;
    GameObject sotsot_e;
    GameObject rtbk_e;

    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        flying_F_e = GameObject.Find("Frying_flour_enemy");
        noodle_e = GameObject.Find("Noodle_enemy");
        sotsot_e = GameObject.Find("Sotteok_Sotteok_enemy");
        rtbk_e = GameObject.Find("Laboki_enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)   //Ã¼·ÂÀÌ 0ÀÌ µÇ¸é »ç¶óÁü
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "shot1_e(Clone)")   //Æ¢±è°¡·ç
        //ºÎµúÈù °´Ã¼ÀÇ ÅÂ±×¸¦ ºñ±³ÇØ¼­ ÃÑ¾ËÀÎÁö ÆÇ´ÜÇÕ´Ï´Ù.
        {
            // Ã¼·Â - (ÀûÀÇ °ø°Ý·Â - ÀÚ½ÅÀÇ ¹æ¾î·Â)
            HP -= (flying_F_e.GetComponent<ability_enemy>().ATK_e - DEF);

            //ÃÑ¾ËÀ» ÆÄ±«ÇÕ´Ï´Ù.
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot2_e(Clone)")   //¸é
        {
            HP -= (noodle_e.GetComponent<ability_enemy>().ATK_e - DEF);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot3_e(Clone)")   //¼Ò¶±¼Ò¶±
        {
            HP -= (sotsot_e.GetComponent<ability_enemy>().ATK_e - DEF);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot4_e(Clone)")   //¶óººÀÌ
        {
            HP -= (rtbk_e.GetComponent<ability_enemy>().ATK_e - DEF);
            Destroy(other.gameObject);
        }
    }

    public void short_hurt(int x)
    {
        switch (x)
        {
            case 1:     //¹ä

                obj = GameObject.Find("Bob_enemy");
                break;

            case 2:     //µÅÁö°í±â

                obj = GameObject.Find("Pork_enemy");
                break;

            case 3:     //±è
                break;
            case 4:     //°í±¸¸¶
                break;
            case 5:     //¼Ò½ÃÁö
                break;
            case 6:     //´ç±Ù
                break;
            case 7:     //¶±
                break;
            case 8:     //ºñ¹ý¼Ò½º
                break;
            case 9:     //°è¶õ
                break;
            case 10:    //¿Àµ­
                break;
            case 11:    //±è¹ä
                break;
            case 12:    //µ·±î½º
                break;
            case 13:    //°í±¸¸¶Æ¢±è
                break;
            case 14:    //²¿¸¶±è¹ä
                break;
            case 15:    //¶±ººÀÌ
                break;
            case 16:    //¿À¹Ç¶óÀÌ½º
                break;
            case 17:    //¶ó¸é
                break;

        }

        HP -= (obj.GetComponent<ability_enemy>().ATK_e - (obj.GetComponent<ability_enemy>().ATK_e * DEF));
    }
}

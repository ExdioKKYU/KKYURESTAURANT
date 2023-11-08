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
    // Start is called before the first frame update
    void Start()
    {
        flying_F = GameObject.Find("Frying_flour");
        noodle = GameObject.Find("Noodle");
        sotsot = GameObject.Find("Sotteok_Sotteok");
        rtbk = GameObject.Find("Laboki");
        // ¿ø°Å¸® À¯´ÖµéÀ» ºÒ·¯¿È
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP_e <= 0)   //Ã¼·ÂÀÌ 0ÀÌ µÇ¸é »ç¶óÁü
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "shot1(Clone)")   //Æ¢±è°¡·ç
        //ºÎµúÈù °´Ã¼ÀÇ ÅÂ±×¸¦ ºñ±³ÇØ¼­ ÃÑ¾ËÀÎÁö ÆÇ´ÜÇÕ´Ï´Ù.
        {
            // Ã¼·Â - (ÀûÀÇ °ø°Ý·Â - ÀÚ½ÅÀÇ ¹æ¾î·Â)
            HP_e -= (flying_F.GetComponent<ability>().ATK - (flying_F.GetComponent<ability>().ATK * DEF_e));
            
            //ÃÑ¾ËÀ» ÆÄ±«ÇÕ´Ï´Ù.
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot2(Clone)")   //¸é
        {
            HP_e -= (noodle.GetComponent<ability>().ATK - (noodle.GetComponent<ability>().ATK  * DEF_e));
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot3(Clone)")   //¼Ò¶±¼Ò¶±
        {
            HP_e -= (sotsot.GetComponent<ability>().ATK - (sotsot.GetComponent<ability>().ATK * DEF_e));
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "shot4(Clone)")   //¶óººÀÌ
        {
            HP_e -= (rtbk.GetComponent<ability>().ATK - (rtbk.GetComponent<ability>().ATK * DEF_e));
            Destroy(other.gameObject);
        }
    }

    public void short_hurt(int x)
    {
        switch (x)
        {
            case 1:     //¹ä

                obj = GameObject.Find("Bob");
                break;

            case 2:     //µÅÁö°í±â

                obj = GameObject.Find("Pork");
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

        HP_e -= (obj.GetComponent<ability>().ATK - (obj.GetComponent<ability>().ATK * DEF_e));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dex_atk_e : MonoBehaviour
{
    public float shot_speed;
    public float ATK_L_e;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.5f);    //시간이 지나면 사라지기
    }

    // Update is called once per frame
    void Update()
    {
        // 총알 발사
        transform.Translate(transform.right * shot_speed * Time.deltaTime);
    }

}

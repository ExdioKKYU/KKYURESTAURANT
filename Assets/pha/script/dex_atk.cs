using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dex_atk : MonoBehaviour
{
    public float shot_speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);    //시간이 지나면 사라지기
    }

    // Update is called once per frame
    void Update()
    {
        // 총알 발사
        transform.Translate(transform.right * shot_speed * Time.deltaTime);
    }

}

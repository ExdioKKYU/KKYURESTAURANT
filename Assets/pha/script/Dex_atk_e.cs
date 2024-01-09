using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dex_atk_e : MonoBehaviour
{
    public float shot_speed;
    public float ATK_L_e;

    private void OnTriggerEnter(Collider other)
    {
        // 부딪힌 객체에 원하는 스크립트가 있을 경우 해당 스크립트의 함수를 호출합니다.
        Ability scriptOnOtherObject = other.GetComponent<Ability>();

        if (scriptOnOtherObject != null)
        {
            // 부딪힌 객체의 스크립트에 정의된 함수 호출
            scriptOnOtherObject.short_hurt(ATK_L_e);
        }
    }

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

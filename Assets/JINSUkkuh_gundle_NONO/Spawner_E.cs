using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Spawner_E : MonoBehaviour
{
    public Transform pos;
    public GameObject unit1;
    private float cool;
    private float position;
    private float line;
    private float unit;
    private float timeAfterSpawn;
    public GameObject bob;
    public GameObject pigmeat;
    public GameObject gim;
    public GameObject sweetpotato;
    public GameObject sausage;
    public GameObject carrot;
    public GameObject ricecake;
    public GameObject noodle;
    public GameObject frymix;
    public GameObject sauce;
    public GameObject egg;
    public GameObject fishcake;


    //아직 상대의 기지 체력 변수를 연결시켜놓지 않아 오류가 나지 않도록 정의만 해놓음
    private float e_hp = 7000;

    void Start()
    {
        cool = Random.Range(3, 6);
        timeAfterSpawn = 0f;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        //적군 기지 프로그래밍을 하는 팀원의 스크립트에서 체력변수를 가져올 것임
        //e_hp = ob.GetComponent <???> ().e_hp;

        if (timeAfterSpawn >= cool)
        {
            //세 라인 중 위치 정하기
            line = Random.Range(1, 4);

            Transform objectTransform = gameObject.GetComponent<Transform>();

            //각 열의 좌표를 입력할 예정
            if (line == 1)
            {
                objectTransform.position = new Vector2(0.0f, 0.0f);
            }
            if (line == 2)
            {
                objectTransform.position = new Vector2(0.0f, 0.0f);
            }
            if (line == 3)
            {
                objectTransform.position = new Vector2(0.0f, 0.0f);
            }

            //상대 기지의 체력 변수에 따라 확률을 조정할것임
            if (e_hp >= 3500)
            {
                //position = 유닛 유형선택 *아직 개발도중임으로 임의의 값임
                //돌격, 방어 탱커 = 각각 20%
                //근거리, 원거리 딜러 = 각각 25%
                //버퍼 + 힐러 = 10%

                position = Random.Range(1, 101);

                if (position < 21) //돌격형 탱커
                {
                    //unit = 특정 유닛 선택 *확률은 스테이지마다 변동 가능 임의의 값임
                    unit = Random.Range(1, 101);
                    if (position < 51)
                        Instantiate(bob, pos.position, transform.rotation);
                    else
                        Instantiate(pigmeat, pos.position, transform.rotation);
                }
                if (position > 20 && position < 41) //방어형 탱커
                {
                    if (position < 51)
                        Instantiate(gim, pos.position, transform.rotation);
                    else
                        Instantiate(sweetpotato, pos.position, transform.rotation);
                }
                if (position > 40 && position < 66) //근거리 딜러
                {
                    if (position < 31)
                        Instantiate(sausage, pos.position, transform.rotation);
                    if (position > 30 && position < 61)
                        Instantiate(carrot, pos.position, transform.rotation);
                    else
                        Instantiate(ricecake, pos.position, transform.rotation);
                }
                if (position > 65 && position < 91) //돌격형 탱커
                {
                    if (position < 51)
                        Instantiate(frymix, pos.position, transform.rotation);
                    else
                        Instantiate(noodle, pos.position, transform.rotation);
                }
                if (position > 90 && position < 101) //힐러 + 버퍼
                {
                    if (position < 31)
                        Instantiate(sauce, pos.position, transform.rotation);
                    if (position > 30 && position < 61)
                        Instantiate(egg, pos.position, transform.rotation);
                    else
                        Instantiate(fishcake, pos.position, transform.rotation);
                }
            }

            // 상대 기지의 체력이 절반 이하로 떨어졌을떄 확률 조정
            else
            {
                position = Random.Range(1, 101);

                if (position < 21) //돌격형 탱커
                {
                    unit = Random.Range(1, 101);
                    if (position < 51)
                        Instantiate(bob, pos.position, transform.rotation);
                    else
                        Instantiate(pigmeat, pos.position, transform.rotation);
                }
                if (position > 20 && position < 41) //방어형 탱커
                {
                    if (position < 51)
                        Instantiate(gim, pos.position, transform.rotation);
                    else
                        Instantiate(sweetpotato, pos.position, transform.rotation);
                }
                if (position > 40 && position < 66) //근거리 딜러
                {
                    if (position < 31)
                        Instantiate(sausage, pos.position, transform.rotation);
                    if (position > 30 && position < 61)
                        Instantiate(carrot, pos.position, transform.rotation);
                    else
                        Instantiate(ricecake, pos.position, transform.rotation);
                }
                if (position > 65 && position < 91) //돌격형 탱커
                {
                    if (position < 51)
                        Instantiate(frymix, pos.position, transform.rotation);
                    else
                        Instantiate(noodle, pos.position, transform.rotation);
                }
                if (position > 90 && position < 101) //힐러 + 버퍼
                {
                    if (position < 31)
                        Instantiate(sauce, pos.position, transform.rotation);
                    if (position > 30 && position < 61)
                        Instantiate(egg, pos.position, transform.rotation);
                    else
                        Instantiate(fishcake, pos.position, transform.rotation);
                }
            }
            //생성 쿨타임 정하기
            cool = Random.Range(3, 6);
            timeAfterSpawn = 0f;
        }
    }
}

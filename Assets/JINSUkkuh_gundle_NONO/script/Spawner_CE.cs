using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_CE : MonoBehaviour
{
    //inspector 창에서 유닛, 유닛확률, 포지션, 포지션 확률을 조정가능

    [SerializeField]
    GameObject[] cook_unit;//요리 유닛 목록

    [SerializeField]
    float[] cook_percentage;//요리 유닛별 소환 확률


    [SerializeField]
    Transform spawnPoint;//스포너

    [SerializeField]
    float[] cooltime;//생성 쿹타임

    [SerializeField]
    float first_spawn;//첫 요리유닛 소환시간

    private float cool;
    private int gh = 0;

    //아직 상대의 기지 체력 변수를 연결시켜놓지 않아 오류가 나지 않도록 정의만 해놓음
    //적군 기지 프로그래밍을 하는 팀원의 스크립트에서 체력변수를 가져올 것임
    //e_hp = ob.GetComponent <???> ().e_hp;
    private float e_hp = 7000;
    //위와 같음 한 열에 아군이 얼마나 존재하는지 (소환될떄 변수에 1씩 더하고 죽을때마다 1씩 감소시킬 예정)
    private int our_unit1 = 0;
    private int our_unit2 = 0;
    private int our_unit3 = 0;

    private float timeAfterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        cool = first_spawn;
        timeAfterSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        //적 기지의 체력이 일정 이하일 경우 적용
        if (e_hp < 3500)
            gh = 2;

        if (timeAfterSpawn >= cool)
        {
            //세 라인 중 위치 정하기
            GetRow();

            Instantiate(cook_unit[GetRandom(cook_percentage, cook_percentage.Length, cook_unit.Length)], spawnPoint);

            cool = Random.Range(cooltime[0] - gh, cooltime[1] - gh);
            timeAfterSpawn = 0f;
        }
    }

    //라인을 정하는 함수
    private void GetRow()
    {
        int a = 0, b = 0, c = 0;
        int line;
        float[] line_percentages = { 30, 30, 30 };

        //열당 존재하는 아군 유닛수가 일정 이상일 시 해당 라인에 스폰될 확률 증가
        if (our_unit1 > 5)
            a = 40;
        if (our_unit2 > 5)
            b = 40;
        if (our_unit3 > 5)
            c = 40;
        line_percentages[0] = 30 + a;
        line_percentages[1] = 30 + b;
        line_percentages[2] = 30 + c;

        Transform objectTransform = gameObject.GetComponent<Transform>();
        line = GetRandom(line_percentages, 3, 3);

        //각 열의 좌표를 입력할 예정
        if (line == 0)
        {
            objectTransform.position = new Vector2(0.0f, 0.0f);
        }
        if (line == 1)
        {
            objectTransform.position = new Vector2(0.0f, 0.0f);
        }
        if (line == 2)
        {
            objectTransform.position = new Vector2(0.0f, 0.0f);
        }
    }


    //확률 계산기 함수

    private int GetRandom(float[] percentages, int p_count, int o_count)
    {
        float random = Random.Range(0f, 1f);
        float numForAdding = 0;
        float total = 0;
        for (int i = 0; i < p_count; i++)
        {
            total += percentages[i];
        }

        for (int i = 0; i < o_count; i++)
        {
            if (percentages[i] / total + numForAdding >= random)
            {
                return i;
            }
            else
            {
                numForAdding += percentages[i] / total;
            }
        }
        return 0;
    }
}
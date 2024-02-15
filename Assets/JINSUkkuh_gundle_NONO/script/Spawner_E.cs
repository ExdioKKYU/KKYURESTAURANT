using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Spawner_E : MonoBehaviour
{
    //inspector 창에서 유닛, 유닛확률, 포지션, 포지션 확률을 조정가능
    [Tooltip("포지션 별 확률 *순서는 돌격형 탱커, 방어형 탱커, 근거리 딜러, 원거리 딜러, 서포터 순으로함")]
    [SerializeField]
    float[] p_percentages = new float[5];//포지션 별 확률 *순서는 돌격형 탱커, 방어형 탱커, 근거리 딜러, 원거리 딜러, 서포터 순으로함

    int[] unitPosition = new int[5];//유닛 포지션

    [SerializeField]
    GameObject[] rush_tank;//돌격형 탱커 포지션의 유닛 목록
    [SerializeField]
    float[] rush_tank_percentage;//돌격형 탱커 포지션의 유닛별 소환 확률

    [SerializeField]
    GameObject[] guard_tank;//방어형 탱커 포지션의 유닛 목록
    [SerializeField]
    float[] guard_tank_percentage;//방어형 탱커 포지션의 유닛별 소환 확률

    [SerializeField]
    GameObject[] close_deal;//근거리 딜러 포지션의 유닛 목록
    [SerializeField]
    float[] close_deal_percentage;//근거리 딜러 포지션의 유닛별 소환 확률

    [SerializeField]
    GameObject[] long_deal;//원거리 딜러 포지션의 유닛 목록
    [SerializeField]
    float[] long_deal_percentage;//원거리 딜러 포지션의 유닛별 소환 확률

    [SerializeField]
    GameObject[] support;//서포터 포지션의 유닛 목록
    [SerializeField]
    float[] support_percentage;//서포터 포지션의 유닛별 소환 확률

    [Tooltip("최소값, 최대값")]
    [SerializeField]
    float[] cooltime = new float[2];//생성 쿹타임

    [Tooltip("유닛 첫 소환 시간")]
    [SerializeField]
    float first_spawn;//첫 유닛 소환

    public Transform pos;
    private float cool;
    private int gh = 0;
    private int unit_position;

    //한 열에 아군이 얼마나 존재하는지 (소환될떄 변수에 1씩 더하고 죽을때마다 1씩 감소시킬 예정)
    private int our_unit1 = 0;
    private int our_unit2 = 0;
    private int our_unit3 = 0;

    private float[] original_p = new float[5];

    private float timeAfterSpawn;

    private int Bob_cloneCounter = 0;
    private int Pork_cloneCounter = 0;
    private int Kim_cloneCounter = 0;
    private int Sweet_potato_cloneCounter = 0;
    private int Sausage_cloneCounter = 0;
    private int Carrot_cloneCounter = 0;
    private int Rice_cake_cloneCounter = 0;
    private int Frying_flour_cloneCounter = 0;
    private int Noodle_cloneCounter = 0;
    private int Secret_sauce_cloneCounter = 0;
    private int Egg_cloneCounter = 0;
    private int Fish_cake_cloneCounter = 0;



    // Start is called before the first frame update
    void Start()
    {
        change(original_p, p_percentages);

        cool = first_spawn;
        timeAfterSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_BaseHp BaseHp = GetComponent<Enemy_BaseHp>();
        float e_hp = BaseHp.curHealth;
        float max_hp = BaseHp.maxHealth;

        timeAfterSpawn += Time.deltaTime;

        //적 기지의 체력이 일정 이하일 경우 적용
        if ((float)e_hp / max_hp < 1 / 3)
            gh = 1;

        if (timeAfterSpawn >= cool)
        {
            //세 라인 중 위치 정하기
            GetRow();
            Transform objectTransform = gameObject.GetComponent<Transform>();

            //생성원리 = 포지션 선택 ex)돌격형 탱커, 원거리 딜러 등등 -> 해당 포지션의 적군 선택 -> 소환 및 해당 포지션 확률 조정

            //1. 확률에 따라 소환되는 유닛 포지션 선택
            //0 = 돌격형 탱커, 1 = 방어형 탱커, 2 = 근거리 딜러, 3 = 원거리 딜러, 4 = 서포터 
            unit_position = GetRandom(p_percentages, 5, 5);
            if (unit_position == 0)
            {
                //2. 결정된 유닛 포지션의 적군을 확률에 따라 소환
                GameObject unitPrefab = rush_tank[GetRandom(rush_tank_percentage, rush_tank_percentage.Length, rush_tank.Length)];
                GameObject clonedObject = Instantiate(unitPrefab, pos.position, transform.rotation);

                //3. 유닛의 이름 설정
                if (unitPrefab.name == "Bob_enemy")
                {
                    Bob_cloneCounter++;
                    clonedObject.name = unitPrefab.name + "_Clone" + Bob_cloneCounter;
                }
                else
                {
                    Pork_cloneCounter++;
                    clonedObject.name = unitPrefab.name + "_Clone" + Pork_cloneCounter;
                }

                change(p_percentages, original_p);

                //4. 다음번 소환에 같은 유닛 포지션이 연속으로 여러변 소환되는 것을 방지 하기위해 유닛 포지션별 확률을 조정
                Percents_Adj(unit_position);
            }

            else if (unit_position == 1)
            {
                GameObject unitPrefab = guard_tank[GetRandom(guard_tank_percentage, guard_tank_percentage.Length, guard_tank.Length)];
                GameObject clonedObject = Instantiate(unitPrefab, pos.position, transform.rotation);

                if (unitPrefab.name == "Kim_enemy")
                {
                    Kim_cloneCounter++;
                    clonedObject.name = unitPrefab.name + "_Clone" + Kim_cloneCounter;
                }
                else
                {
                    Sweet_potato_cloneCounter++;
                    clonedObject.name = unitPrefab.name + "_Clone" + Sweet_potato_cloneCounter;
                }

                change(p_percentages, original_p);
                Percents_Adj(unit_position);
            }

            else if (unit_position == 2)
            {
                GameObject unitPrefab = close_deal[GetRandom(close_deal_percentage, close_deal_percentage.Length, close_deal.Length)];
                GameObject clonedObject = Instantiate(unitPrefab, pos.position, transform.rotation);

                if (unitPrefab.name == "Sausage_enemy")
                {
                    Sausage_cloneCounter++;
                    clonedObject.name = unitPrefab.name + "_Clone" + Sausage_cloneCounter;
                }
                else if (unitPrefab.name == "Carrot_enemy")
                {
                    Carrot_cloneCounter++;
                    clonedObject.name = unitPrefab.name + "_Clone" + Carrot_cloneCounter;
                }
                else
                {
                    Rice_cake_cloneCounter++;
                    clonedObject.name = unitPrefab.name + "_Clone" + Rice_cake_cloneCounter;
                }

                change(p_percentages, original_p);
                Percents_Adj(unit_position);
            }

            else if (unit_position == 3)
            {
                GameObject unitPrefab = long_deal[GetRandom(long_deal_percentage, long_deal_percentage.Length, long_deal.Length)];
                GameObject clonedObject = Instantiate(unitPrefab, pos.position, transform.rotation);

                if (unitPrefab.name == "Frying_flour_enemy")
                {
                    Frying_flour_cloneCounter++;
                    clonedObject.name = unitPrefab.name + "_Clone" + Frying_flour_cloneCounter;
                }
                else
                {
                    Noodle_cloneCounter++;
                    clonedObject.name = unitPrefab.name + "_Clone" + Noodle_cloneCounter;
                }

                change(p_percentages, original_p);
                Percents_Adj(unit_position);
            }

            else
            {
                GameObject unitPrefab = support[GetRandom(support_percentage, support_percentage.Length, support.Length)];
                GameObject clonedObject = Instantiate(unitPrefab, pos.position, transform.rotation);

                if (unitPrefab.name == "Secret_sauce_enemy")
                {
                    Secret_sauce_cloneCounter++;
                    clonedObject.name = unitPrefab.name + "_Clone" + Secret_sauce_cloneCounter;
                }
                else if (unitPrefab.name == "Egg_enemy")
                {
                    Egg_cloneCounter++;
                    clonedObject.name = unitPrefab.name + "_Clone" + Egg_cloneCounter;
                }
                else
                {
                    Fish_cake_cloneCounter++;
                    clonedObject.name = unitPrefab.name + "_Clone" + Fish_cake_cloneCounter;
                }
                change(p_percentages, original_p);
                Percents_Adj(unit_position);
            }

            //쿨타임 정하기
            //적 기지의 체력이 일정 이하일 경우 쿨타임을 줄이기(자주 소환되도록 -> 난이도 상승)
            if (gh == 0)
                cool = Random.Range(cooltime[0], cooltime[1]);
            else
                cool = Random.Range(cooltime[0], cooltime[1]) / 2;
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
            objectTransform.position = new Vector2(33.0f, 1.0f);
        }
        if (line == 1)
        {
            objectTransform.position = new Vector2(33.0f, -0.8f);
        }
        if (line == 2)
        {
            objectTransform.position = new Vector2(33.0f, -2.6f);
        }
    }

    //유닛 포지션별 확률을 조정하는 함수
    //이것과 비슷한 형식으로 적 기지 체력이 일정 이하일 결우 고 코스트의 강한 유닛의 출현 빈도가 높도록 확률 설정 가능 (상의중)

    private void change(float[] original_p, float[] p_percentages)
    {
        for (int i = 0; i < 5; i++)
        {
            original_p[i] = p_percentages[i];
        }
    }

    private void Percents_Adj(int i)
    {
        float a = 1, b = 1, c = 1, d = 1, e = 1;
        if (i == 0)
            a = 0.6f;
        else if (i == 1)
            b = 0.6f;
        else if (i == 2)
            c = 0.6f;
        else if (i == 3)
            d = 0.6f;
        else
            e = 0.6f;
        p_percentages[0] = p_percentages[0] * a;//돌격형 탱커
        p_percentages[1] = p_percentages[1] * b;//방어형 탱커
        p_percentages[2] = p_percentages[2] * c;//근거리 딜러
        p_percentages[3] = p_percentages[3] * d;//원거리 딜러
        p_percentages[4] = p_percentages[4] * e;//서포터
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
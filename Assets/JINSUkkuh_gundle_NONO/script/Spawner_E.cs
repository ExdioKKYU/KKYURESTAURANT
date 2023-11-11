using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_E : MonoBehaviour
{
    //inspector 창에서 유닛, 유닛확률, 포지션, 포지션 확률을 조정가능
    [SerializeField]
    float[] p_percentages;//포지션 별 확률
    [SerializeField]
    float[] unitPosition;//유닛 포지션

    [SerializeField]
    float[] rush_tnak_percentage;//돌격형 탱커 포지션의 유닛별 소환 확률
    [SerializeField]
    GameObject[] rush_tnak;//돌격형 탱커 포지션의 유닛 목록

    [SerializeField]
    float[] guard_tnak_percentage;//방어형 탱커 포지션의 유닛별 소환 확률
    [SerializeField]
    GameObject[] guard_tnak;//방어형 탱커 포지션의 유닛 목록

    [SerializeField]
    float[] close_deal_percentage;//근접 딜러 포지션의 유닛별 소환 확률
    [SerializeField]
    GameObject[] close_deal;//근접 딜러 포지션의 유닛 목록

    [SerializeField]
    float[] long_deal_percentage;//원거리 딜러 포지션의 유닛별 소환 확률
    [SerializeField]
    GameObject[] long_deal;//원거리 딜러 포지션의 유닛 목록

    [SerializeField]
    float[] support_percentage;//서포터 포지션의 유닛별 소환 확률
    [SerializeField]
    GameObject[] support;//서포터 포지션의 유닛 목록

    [SerializeField]
    Transform spawnPoint;//스포너

    private float cool;
    private int gh;

    //아직 상대의 기지 체력 변수를 연결시켜놓지 않아 오류가 나지 않도록 정의만 해놓음
    //적군 기지 프로그래밍을 하는 팀원의 스크립트에서 체력변수를 가져올 것임
    //e_hp = ob.GetComponent <???> ().e_hp;
    private float e_hp = 7000;

    private float timeAfterSpawn;
    private float line;

    // Start is called before the first frame update
    void Start()
    {
        cool = Random.Range(3, 6);
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
            
            //생성원리 = 포지션 선택 ex)돌격형 탱커, 원거리 딜러 등등 -> 해당 포지션의 적군 선택 -> 소환 및 해당 포지션 확률 조정

            //1. 확률에 따라 소환되는 유닛의 포지션 선택
            //0 = 돌격형 탱커, 1 = 방어형 탱커, 2 = 근거리 딜러, 3 = 원거리 딜러, 4 = 서포터 
            if (GetRandom(p_percentages, p_percentages.Length, unitPosition.Length) == 0)
            {
                //2. 결정된 포지션의 적군을 확률에 따라 소환
                Instantiate(rush_tnak[GetRandom(rush_tnak_percentage, rush_tnak_percentage.Length, rush_tnak.Length)], spawnPoint);

                //3. 다음번 소환에 같은 포지션이 연속으로 여러변 소환되는 것을 방지 하기위해 포지션별 확률을 조정
                Percents_Adj(GetRandom(p_percentages, p_percentages.Length, unitPosition.Length));
            }

            else if (GetRandom(p_percentages, p_percentages.Length, unitPosition.Length) == 1)
            {
                Instantiate(guard_tnak[GetRandom(guard_tnak_percentage, guard_tnak_percentage.Length, guard_tnak.Length)], spawnPoint);
                Percents_Adj(GetRandom(p_percentages, p_percentages.Length, unitPosition.Length));
            }

            else if (GetRandom(p_percentages, p_percentages.Length, unitPosition.Length) == 2)
            {
                Instantiate(rush_tnak[GetRandom(close_deal_percentage, close_deal_percentage.Length, close_deal.Length)], spawnPoint);
                Percents_Adj(GetRandom(p_percentages, p_percentages.Length, unitPosition.Length));
            }

            else if (GetRandom(p_percentages, p_percentages.Length, unitPosition.Length) == 3)
            {
                Instantiate(rush_tnak[GetRandom(long_deal_percentage, long_deal_percentage.Length, long_deal.Length)], spawnPoint);
                Percents_Adj(GetRandom(p_percentages, p_percentages.Length, unitPosition.Length));
            }

            else
            {
                Instantiate(rush_tnak[GetRandom(support_percentage, support_percentage.Length, support.Length)], spawnPoint);
                Percents_Adj(GetRandom(p_percentages, p_percentages.Length, unitPosition.Length));
            }
            
            //쿨타임 정하기
            //적 기지의 체력이 일정 이하일 경우 쿨타임을 줄이기(자주 소환되도록 -> 난이도 상승)
            cool = Random.Range(4-gh, 6-gh);
            timeAfterSpawn = 0f;
        }
    }

    //라인을 정하는 함수
    private void GetRow()
    {
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
    }

    //포지션별 확률을 조정하는 함수
    //이것과 비슷한 형식으로 적 기지 체력이 일정 이하일 결우 고 코스트의 강한 유닛의 출현 빈도가 높도록 확률 설정 가능 (상의중)
    private void Percents_Adj(int i)
    {
        int a = 0, b = 0, c = 0, d = 0, e = 0;
        if (i == 0)
            a = -10;
        else if (i == 1)
            b = -10;
        else if (i == 2)
            c = -10;
        else if (i == 3)
            d = -10;
        else
            e = -10;
        p_percentages[0] = 20+a;//돌격형 탱커
        p_percentages[1] = 20+b;//방어형 탱커
        p_percentages[2] = 30+c;//근거리 딜러
        p_percentages[3] = 30+d;//원거리 딜러
        p_percentages[4] = 15+e;//서포터
    }

    //확률 계산기 함수

    private int GetRandom(float[] percentages, int p_count, int o_count)
    {
        float random = Random.Range(0f, 1f);
        float numForAdding = 0;
        float total = 0;
        for (int i = 0; i <  p_count; i++)
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
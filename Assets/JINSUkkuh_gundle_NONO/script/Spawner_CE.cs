using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

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

    [Tooltip("유닛 첫 소환 시간")]
    [SerializeField]
    float first_spawn;//첫 요리유닛 소환시간

    public Transform pos;
    private float cool;
    private int gh = 0;

    private int Kimbob_cloneCounter = 0;
    private int Little_Kimbob_cloneCounter = 0;
    private int Pork_cutlet_cloneCounter = 0;
    private int Fried_sweet_potato_cloneCounter = 0;
    private int Tteokbokki_cloneCounter = 0;
    private int Sotteok_cloneCounter = 0;
    private int Rabokki_cloneCounter = 0;
    private int Omelet_cloneCounter = 0;
    private int Ramen_cloneCounter = 0;

    //한 열에 아군이 얼마나 존재하는지 (소환될떄 변수에 1씩 더하고 죽을때마다 1씩 감소시킬 예정)
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

            GameObject unitPrefab = cook_unit[GetRandom(cook_percentage, cook_percentage.Length, cook_unit.Length)];
            GameObject clonedObject = Instantiate(unitPrefab, pos.position, transform.rotation);

            if (unitPrefab.name == "Kimbob_enemy")
            {
                Kimbob_cloneCounter++;
                clonedObject.name = unitPrefab.name + "_Clone" + Kimbob_cloneCounter;
            }
            else if (unitPrefab.name == "Little_Kimbob_enemy")
            {
                Little_Kimbob_cloneCounter++;
                clonedObject.name = unitPrefab.name + "_Clone" + Little_Kimbob_cloneCounter;
            }
            else if (unitPrefab.name == "Pork_cutlet_enemy")
            {
                Pork_cutlet_cloneCounter++;
                clonedObject.name = unitPrefab.name + "_Clone" + Pork_cutlet_cloneCounter;
            }
            else if (unitPrefab.name == "Fried_sweet_potato_enemy")
            {
                Fried_sweet_potato_cloneCounter++;
                clonedObject.name = unitPrefab.name + "_Clone" + Fried_sweet_potato_cloneCounter;
            }
            else if (unitPrefab.name == "Tteokbokki_enemy")
            {
                Tteokbokki_cloneCounter++;
                clonedObject.name = unitPrefab.name + "_Clone" + Tteokbokki_cloneCounter;
            }
            else if (unitPrefab.name == "Sotteok_enemy")
            {
                Sotteok_cloneCounter++;
                clonedObject.name = unitPrefab.name + "_Clone" + Sotteok_cloneCounter;
            }
            else if (unitPrefab.name == "Rabokkit_enemy")
            {
                Rabokki_cloneCounter++;
                clonedObject.name = unitPrefab.name + "_Clone" + Rabokki_cloneCounter;
            }
            else if (unitPrefab.name == "Omelet_enemy")
            {
                Omelet_cloneCounter++;
                clonedObject.name = unitPrefab.name + "_Clone" + Omelet_cloneCounter;
            }
            else
            {
                Ramen_cloneCounter++;
                clonedObject.name = unitPrefab.name + "_Clone" + Ramen_cloneCounter;
            }

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
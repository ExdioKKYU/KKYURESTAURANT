using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Spawner_CE : MonoBehaviour
{
    //inspector â���� ����, ����Ȯ��, ������, ������ Ȯ���� ��������

    [SerializeField]
    GameObject[] cook_unit;//�丮 ���� ���

    [SerializeField]
    float[] cook_percentage;//�丮 ���ֺ� ��ȯ Ȯ��

    [SerializeField]
    Transform spawnPoint;//������

    [SerializeField]
    float[] cooltime;//���� �lŸ��

    [Tooltip("���� ù ��ȯ �ð�")]
    [SerializeField]
    float first_spawn;//ù �丮���� ��ȯ�ð�

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

    //�� ���� �Ʊ��� �󸶳� �����ϴ��� (��ȯ�ɋ� ������ 1�� ���ϰ� ���������� 1�� ���ҽ�ų ����)
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
        BaseHp BaseHp = GetComponent<BaseHp>();
        float e_hp = BaseHp.curHealth;
        float max_hp = BaseHp.maxHealth;

        timeAfterSpawn += Time.deltaTime;

        //�� ������ ü���� ���� ������ ��� ����
        if ((float)e_hp / max_hp < 1 / 3)
            gh = 1;

        if (timeAfterSpawn >= cool)
        {
            //�� ���� �� ��ġ ���ϱ�
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

    //������ ���ϴ� �Լ�
    private void GetRow()
    {
        int a = 0, b = 0, c = 0;
        int line;
        float[] line_percentages = { 30, 30, 30 };

        //���� �����ϴ� �Ʊ� ���ּ��� ���� �̻��� �� �ش� ���ο� ������ Ȯ�� ����
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

        //�� ���� ��ǥ�� �Է��� ����
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


    //Ȯ�� ���� �Լ�

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
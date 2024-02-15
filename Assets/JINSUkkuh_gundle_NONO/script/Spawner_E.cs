using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Spawner_E : MonoBehaviour
{
    //inspector â���� ����, ����Ȯ��, ������, ������ Ȯ���� ��������
    [Tooltip("������ �� Ȯ�� *������ ������ ��Ŀ, ����� ��Ŀ, �ٰŸ� ����, ���Ÿ� ����, ������ ��������")]
    [SerializeField]
    float[] p_percentages = new float[5];//������ �� Ȯ�� *������ ������ ��Ŀ, ����� ��Ŀ, �ٰŸ� ����, ���Ÿ� ����, ������ ��������

    int[] unitPosition = new int[5];//���� ������

    [SerializeField]
    GameObject[] rush_tank;//������ ��Ŀ �������� ���� ���
    [SerializeField]
    float[] rush_tank_percentage;//������ ��Ŀ �������� ���ֺ� ��ȯ Ȯ��

    [SerializeField]
    GameObject[] guard_tank;//����� ��Ŀ �������� ���� ���
    [SerializeField]
    float[] guard_tank_percentage;//����� ��Ŀ �������� ���ֺ� ��ȯ Ȯ��

    [SerializeField]
    GameObject[] close_deal;//�ٰŸ� ���� �������� ���� ���
    [SerializeField]
    float[] close_deal_percentage;//�ٰŸ� ���� �������� ���ֺ� ��ȯ Ȯ��

    [SerializeField]
    GameObject[] long_deal;//���Ÿ� ���� �������� ���� ���
    [SerializeField]
    float[] long_deal_percentage;//���Ÿ� ���� �������� ���ֺ� ��ȯ Ȯ��

    [SerializeField]
    GameObject[] support;//������ �������� ���� ���
    [SerializeField]
    float[] support_percentage;//������ �������� ���ֺ� ��ȯ Ȯ��

    [Tooltip("�ּҰ�, �ִ밪")]
    [SerializeField]
    float[] cooltime = new float[2];//���� �lŸ��

    [Tooltip("���� ù ��ȯ �ð�")]
    [SerializeField]
    float first_spawn;//ù ���� ��ȯ

    public Transform pos;
    private float cool;
    private int gh = 0;
    private int unit_position;

    //�� ���� �Ʊ��� �󸶳� �����ϴ��� (��ȯ�ɋ� ������ 1�� ���ϰ� ���������� 1�� ���ҽ�ų ����)
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
        BaseHp BaseHp = GetComponent<BaseHp>();
        float e_hp = BaseHp.curHealth;
        float max_hp = BaseHp.maxHealth;

        timeAfterSpawn += Time.deltaTime;

        //�� ������ ü���� ���� ������ ��� ����
        if ((float)e_hp / max_hp < 1/3)
            gh = 1;

        if (timeAfterSpawn >= cool)
        {
            //�� ���� �� ��ġ ���ϱ�
            GetRow();
            Transform objectTransform = gameObject.GetComponent<Transform>();

            //�������� = ������ ���� ex)������ ��Ŀ, ���Ÿ� ���� ��� -> �ش� �������� ���� ���� -> ��ȯ �� �ش� ������ Ȯ�� ����

            //1. Ȯ���� ���� ��ȯ�Ǵ� ���� ������ ����
            //0 = ������ ��Ŀ, 1 = ����� ��Ŀ, 2 = �ٰŸ� ����, 3 = ���Ÿ� ����, 4 = ������ 
            unit_position = GetRandom(p_percentages, 5, 5);
            if (unit_position == 0)
            {
                //2. ������ ���� �������� ������ Ȯ���� ���� ��ȯ
                GameObject unitPrefab = rush_tank[GetRandom(rush_tank_percentage, rush_tank_percentage.Length, rush_tank.Length)];
                GameObject clonedObject = Instantiate(unitPrefab, pos.position, transform.rotation);

                //3. ������ �̸� ����
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

                //4. ������ ��ȯ�� ���� ���� �������� �������� ������ ��ȯ�Ǵ� ���� ���� �ϱ����� ���� �����Ǻ� Ȯ���� ����
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

            //��Ÿ�� ���ϱ�
            //�� ������ ü���� ���� ������ ��� ��Ÿ���� ���̱�(���� ��ȯ�ǵ��� -> ���̵� ���)
            if (gh == 0)
                cool = Random.Range(cooltime[0], cooltime[1]);
            else
                cool = Random.Range(cooltime[0], cooltime[1])/2;
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

    //���� �����Ǻ� Ȯ���� �����ϴ� �Լ�
    //�̰Ͱ� ����� �������� �� ���� ü���� ���� ������ ��� �� �ڽ�Ʈ�� ���� ������ ���� �󵵰� ������ Ȯ�� ���� ���� (������)

    private void change(float[] original_p, float[] p_percentages)
    {
        for(int i = 0; i < 5;  i++)
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
        p_percentages[0] = p_percentages[0] * a;//������ ��Ŀ
        p_percentages[1] = p_percentages[1] * b;//����� ��Ŀ
        p_percentages[2] = p_percentages[2] * c;//�ٰŸ� ����
        p_percentages[3] = p_percentages[3] * d;//���Ÿ� ����
        p_percentages[4] = p_percentages[4] * e;//������
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
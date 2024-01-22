using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecallUnit : MonoBehaviour
{
    // 유닛 프리팹들을 저장할 변수들
    public GameObject unitPrefab1;
    public GameObject unitPrefab2;
    public GameObject unitPrefab3;
    public GameObject unitPrefab4;

    public GameObject Shop;

    // 선택된 유닛을 저장할 변수
    private GameObject selectedUnitPrefab;

    // 프리팹을 소환할 위치
    public Vector2 spawnPosition;

    private int cloneCounter = 0;

    void Update()
    {
        // 선택된 라인에 따라 소환 위치 결정
        if (DataMgr.instance.currentLine == Line.Line1)
        {
            spawnPosition = new Vector2(-35f, 1f);
        }
        else if (DataMgr.instance.currentLine == Line.Line2)
        {
            spawnPosition = new Vector2(-35f, -0.8f);
        }
        else if (DataMgr.instance.currentLine == Line.Line3)
        {
            spawnPosition = new Vector2(-35f, -2.6f);
        }
    }

    // 버튼이 클릭될 때 선택된 유닛을 설정
    public void OnClickButten1()
    {
        selectedUnitPrefab = unitPrefab1;
        Shop.GetComponent<Shop>().UnitCoin = 100f;
        Debug.Log("유닛 1");
    }

    public void OnClickButten2()
    {
        selectedUnitPrefab = unitPrefab2;
        Shop.GetComponent<Shop>().UnitCoin = 200f;
        Debug.Log("유닛 2");
    }

    public void OnClickButten3()
    {
        selectedUnitPrefab = unitPrefab3;
        Shop.GetComponent<Shop>().UnitCoin = 300f;
        Debug.Log("유닛 3");
    }

    public void OnClickButten4()
    {
        selectedUnitPrefab = unitPrefab4;
        Shop.GetComponent<Shop>().UnitCoin = 400f;
        Debug.Log("유닛 4");
    }

    // 라인이 클릭될 때 선택된 유닛을 소환
    public void Call()
    {
        Update();

        // 선택된 유닛이 있다면 소환
        if (selectedUnitPrefab != null && (Shop.GetComponent<Shop>().CoinInt >= Shop.GetComponent<Shop>().UnitCoin))
        {
            GameObject unit = Instantiate(selectedUnitPrefab, spawnPosition, Quaternion.identity);

            // 복제본에 고유한 번호를 붙여서 이름 지정
            cloneCounter++;
            unit.name = selectedUnitPrefab.name + "_Clone" + cloneCounter;

            Shop.GetComponent<Shop>().lostMoney();

            selectedUnitPrefab = null;
        }
        else
        {
            Debug.LogWarning("유닛이 선택되지 않았습니다. 소환하기 전에 유닛을 선택해주세요.");
        }

    }
}

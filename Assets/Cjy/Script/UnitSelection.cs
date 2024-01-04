using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    public GameObject unitPrefab; // 소환할 유닛 프리팹
    public KeyCode summonKey = KeyCode.S; // 소환할 키
    public Transform spawnArea; // 소환 영역
    public Vector2 fixedSpawnPosition; // 고정된 소환 위치

    void Update()
    {
        // 특정 키를 눌렀을 때 유닛 소환
        if (Input.GetKeyDown(summonKey))
        {
            SummonUnit();
        }
    }

    void SummonUnit()
    {
        // 선택된 오브젝트의 좌표를 기준으로 소환 위치를 조정
        Vector3 spawnPosition = spawnArea.position;

        // 고정된 소환 위치를 사용
        spawnPosition += new Vector3(fixedSpawnPosition.x, fixedSpawnPosition.y, 0f);

        Instantiate(unitPrefab, spawnPosition, Quaternion.identity);
    }
}

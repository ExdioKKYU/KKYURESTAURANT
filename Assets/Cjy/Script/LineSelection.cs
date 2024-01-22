using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class LineSelection  : MonoBehaviour
{
    public GameObject unitPrefab; // 유닛의 프리팹

    void OnMouseDown()
    {
        // 마우스 클릭이 감지되면 유닛을 소환
        SpawnUnit();
    }

    void SpawnUnit()
    {
        //특정 오브젝트에서 유닛 소환하면서 x축 위치를 고정
        float fixedXPosition = -36f; // 고정할 x축 위치
        Vector3 spawnPosition = new Vector3(fixedXPosition, transform.position.y, transform.position.z);

        // 여기에서는 간단히 새로운 유닛을 특정 오브젝트의 위치에 생성
        Instantiate(unitPrefab, spawnPosition, Quaternion.identity);
    }
}

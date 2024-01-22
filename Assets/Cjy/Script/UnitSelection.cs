using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    // 버튼에 연결된 유닛을 저장할 배열 또는 리스트
    public GameObject[] unitButtons;

    void Start()
    {
    }

    void SelectUnit(int unitIndex)
    {
        // 여기에서 선택된 유닛에 대한 추가 처리를 수행하면 됩니다.
        GameObject selectedUnit = unitButtons[unitIndex];

        Debug.Log("Selected Unit: " + selectedUnit.name);
    }
}

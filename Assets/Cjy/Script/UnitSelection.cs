using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    private Vector3 startDragPosition;
    private Rect selectionBox;

    void Update()
    {
        HandleSelectionInput();
    }

    void HandleSelectionInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 드래그 시작 위치 저장
            startDragPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            // 드래그 박스 크기 계산
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 lowerLeft = Vector3.Min(startDragPosition, currentMousePosition);
            Vector3 upperRight = Vector3.Max(startDragPosition, currentMousePosition);
            selectionBox = Rect.MinMaxRect(lowerLeft.x, lowerLeft.y, upperRight.x, upperRight.y);

            // 드래그 박스를 시각적으로 표시
            DrawSelectionBox(selectionBox);
        }

        if (Input.GetMouseButtonUp(0))
        {
            // 드래그가 끝났을 때 선택된 유닛 처리
            HandleSelectedUnits();
        }
    }

    void DrawSelectionBox(Rect box)
    {
        // GUI.Box 등을 사용하여 드래그 박스를 시각적으로 표시
        GUI.Box(box, "");
    }

    void HandleSelectedUnits()
    {
        // 드래그 박스에 포함된 모든 유닛을 선택
        Collider2D[] colliders = Physics2D.OverlapAreaAll(selectionBox.min, selectionBox.max);

        foreach (Collider2D collider in colliders)
        {
            // 선택된 유닛에 대한 추가 로직을 여기에 추가
            Debug.Log("Selected Unit: " + collider.gameObject.name);
        }
    }
}

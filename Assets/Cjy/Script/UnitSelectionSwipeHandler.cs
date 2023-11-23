using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitSelectionSwipeHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform unitSelectionRectTransform;
    private Vector2 startPosition;
    private bool isDragging = false;

    void Start()
    {
        // 유닛 선택창의 RectTransform 컴포넌트 가져오기
        unitSelectionRectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 다른 캔버스에서는 이벤트를 무시하도록 체크
        if (!IsPointerOverUIObject(eventData.position, eventData.pressEventCamera))
        {
            return;
        }

        // 드래그 시작 시 초기 위치 저장
        startPosition = unitSelectionRectTransform.anchoredPosition;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging)
        {
            return;
        }

        // 스와이프한 거리 계산
        Vector2 dragDelta = eventData.delta;

        // 유닛 선택창 이동
        unitSelectionRectTransform.anchoredPosition += dragDelta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 드래그 종료 시 초기 위치로 되돌리기
        unitSelectionRectTransform.anchoredPosition = startPosition;
        isDragging = false;
    }

    // 다른 캔버스에서 UI 이벤트를 무시하기 위한 메서드
    private bool IsPointerOverUIObject(Vector2 touchPosition, Camera eventCamera)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = touchPosition;

        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }

    // 다른 스크립트에서 현재 스와이프 중인지 확인하기 위한 메서드
    public bool IsDragging()
    {
        return isDragging;
    }
}

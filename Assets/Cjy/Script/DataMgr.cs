using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Line // 라인
{
    Line1, Line2, Line3
}
public class DataMgr : MonoBehaviour
{
    public static DataMgr instance;

    private void Awake()
    {
        //만약 'instance'가 아직 설정되어 있지 않았다면, 현재의 인스턴스를 'instance'에 할당
        if (instance == null) instance = this;

        //이미 'instance'가 설정되어 있다면, 중복 생성을 막기위해 메서드를 종료 
        else if (instance != null) return;

        //현재 게임 오브젝트를 씬 전환시에 파괴되 않도록 설정
        DontDestroyOnLoad(gameObject);
    }

    //현재 선택된 라인을 저장하는 변수
    public Line currentLine;
}

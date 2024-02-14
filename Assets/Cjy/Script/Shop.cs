using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //추가
using UnityEngine.SceneManagement; //추가

public class Shop : MonoBehaviour
{
    public float CoinInt; // 코인이 저장되는 변수
    public Text CoinText; //코인을 표시할 오브젝트
    public float Timer; //타이머
    private bool TimeSet; // 타이머 작동여부
    public float UnitCoin; //유닛별 코인 

    void Start()
    {
        TimeSet = true;
        UnitCoin = 0;
    }

    void Update()
    {
        CoinText.text = (int)CoinInt + " /2000";

        if (TimeSet == true) // TimeSet이 True면
        {
            Timer += Time.deltaTime; // 타이머가 작동
            if (Timer > 1.0f) // 1초가 지나면
            {
                Timer = 0;
                CoinInt += 100f;

                if (CoinInt >= 2000f)
                {
                    TimeSet = false;
                }
            }
        }
    }


    public void lostMoney() // 돈을 잃음
    {
        if (CoinInt >= UnitCoin) // CoinInt가 유닛코인 이상이라면
        {
            Debug.Log("차감" + UnitCoin);
            CoinInt -= UnitCoin; // CoinInt가 유닛 코인만큼 줌
            TimeSet = true;

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHp : MonoBehaviour
{
    private float maxHp = 10f;
    private float curHp = 1f;

    public float value;

    // Start is called before the first frame update
    void Start()
    {
        value = maxHp;

    }


    private void OnCollisionEnter2D(Collision2D collision) // 레이어로 충돌을 인식할려 했으나 istrigger를 쓰면 충돌감지 안됨
    {
        value -= curHp;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (value == 0f)
        {
            Destroy(gameObject);
        }
    }
}

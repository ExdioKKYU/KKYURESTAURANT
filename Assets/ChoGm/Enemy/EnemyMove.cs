using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float speed;
    private bool closeEnemy;
    private float rangeEnemy;   //유닛의 사거리에 따른 스크립트 받아오기

    private bool isEnemy;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;
        rangeEnemy = 5.0f;      //유닛의 사거리에 따른 스크립트 받아오기
        closeEnemy = true;
        isEnemy = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (closeEnemy == true)
            transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (closeEnemy == false)
            transform.Translate(0, 0, 0);
    }
}

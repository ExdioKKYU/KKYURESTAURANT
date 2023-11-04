using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability : MonoBehaviour
{
    public float HP;         // 체력
    public float ATK;        // 공격력
    public float DEF;        // 방어력
    public float AT_sp;      // 공격속도
    public float range;      // 사정 거리

    private float my_at_sp;
    
    public GameObject str_Prefab;
    public Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        my_at_sp = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        my_at_sp += Time.deltaTime;

        if (my_at_sp == AT_sp)
        {
            GameObject str_shot = Instantiate(str_Prefab, pos.position, transform.rotation);
            my_at_sp = 0.0f;
        }
    }
}

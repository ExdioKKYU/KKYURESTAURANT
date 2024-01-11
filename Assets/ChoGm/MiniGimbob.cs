using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGimbob : MonoBehaviour
{
    public GameObject obj_unit;

    // Start is called before the first frame update
    void Start()
    {
        obj_unit = GameObject.Find("Frying_flour");
        obj_unit.GetComponent<UnitMove>().moveSpeed = 10.0f;
        obj_unit.GetComponent<UnitMove>().rangeUnit = 0.0f;
        obj_unit.GetComponent<ability>().ATK = 0.0f;
        obj_unit.GetComponent<unit_long_atk>().AT_sp = 0.0f;
        obj_unit.GetComponent<unit_long_atk>().range = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ability_enemy abilityEnemy = collision.GetComponent<ability_enemy>();
        if (abilityEnemy != null)
        {
            // HP_e 값이 10 감소
            abilityEnemy.HP_e -= 10;
        }
    }

}

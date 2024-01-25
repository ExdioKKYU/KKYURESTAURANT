using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bass_Atk : MonoBehaviour
{
    public GameObject Background_battle_base;
    public float damage;

    public void HitDamage(float hit)
    {
        damage = hit;
        BaseHp baseHpScript = Background_battle_base.GetComponent<BaseHp>();
        baseHpScript.Damage(damage);
    }


    // Start is called before the first frame update
    void Start()
    {
        Background_battle_base = GameObject.Find("Background_battle_base");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

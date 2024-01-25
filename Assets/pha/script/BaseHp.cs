using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class BaseHp : MonoBehaviour
{
    protected float curHealth;
    public float maxHealth;
    //public Slider HpBarSlider;

    //public void CheckHp()
    //{
    //    if (HpBarSlider != null)
    //        HpBarSlider.value = curHealth / maxHealth;
    //}

    public void Damage(float damage)
    {
        if (maxHealth == 0 || curHealth <= 0)
            return;
        curHealth -= damage;
        //CheckHp();
        if(curHealth <= 0)
        {
            //체력 0일때
        }
    }


    // Start is called before the first frame update
    void Start()
    {

        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

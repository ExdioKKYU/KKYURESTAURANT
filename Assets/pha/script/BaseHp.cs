using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHp : MonoBehaviour
{
    public Slider BaseHPSlider;

    public float curHealth;
    public float maxHealth;
 

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHpSlider();
    }

    private void UpdateHpSlider()
    {
        BaseHPSlider.value = (float)curHealth / maxHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHp : MonoBehaviour
{
    private float maxHp = 10f;
    private float curHp = 1f;

    public float value;

    int playerLayer;


    void Start()
    {
        value = maxHp;

        playerLayer = LayerMask.NameToLayer("Player");
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        value -= curHp;
        Debug.Log("아군 기지 체력 감소");

    }

    
    void Update()
    {
        if (value == 0f)
        {
            Destroy(gameObject);
        }

        Physics2D.IgnoreLayerCollision(playerLayer, playerLayer, true);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHp : MonoBehaviour
{
    private float maxHp = 10f;
    private float curHp = 1f;

    public float Enemyvalue;

    int enemyLayer;

    void Start()
    {
        Enemyvalue = maxHp;

        enemyLayer = LayerMask.NameToLayer("Enemy");

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemyvalue -= curHp;

        Debug.Log("적군 기지 체력 감소");

    }

    void Update()
    {
        if (Enemyvalue == 0f)
        {
            Destroy(gameObject);
        }

        Physics2D.IgnoreLayerCollision(enemyLayer, enemyLayer, true);
    }
}

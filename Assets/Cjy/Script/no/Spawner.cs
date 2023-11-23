using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject playerbulletprefab;

    public float intervalMin = 3f;
    public float intervalMax = 5f;

    private float interval;
    private float timeAfterSpawn;

    void Start()
    {
        interval = Random.Range(intervalMin, intervalMax);
        timeAfterSpawn = 0f;
    }

    public void playerattack()
    {
        GameObject playerbullet
            = Instantiate(playerbulletprefab, transform.position, Quaternion.identity);
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn > interval)
        {
            playerattack();

            interval = Random.Range(intervalMin, intervalMax);
            timeAfterSpawn = 0f;
        }
    }
}

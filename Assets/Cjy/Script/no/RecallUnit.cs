using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecallUnit : MonoBehaviour
{

    public GameObject playerbulletprefab;

    public void playerrecall()
    {
        GameObject playerbullet
              = Instantiate(playerbulletprefab, transform.position, Quaternion.identity);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecallUnit : MonoBehaviour
{

    public GameObject playerbulletprefab;

    public void playerrecall()
    {
        GameObject playerbullet
            = Instantiate(playerbulletprefab, playerbulletprefab.transform.position = new Vector3(-8f, 3.1f), Quaternion.identity);

    }

}

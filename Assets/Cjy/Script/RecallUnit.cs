using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecallUnit : MonoBehaviour
{

    public GameObject playerbulletprefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playerrecall()
    {
        GameObject playerbullet
            = Instantiate(playerbulletprefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

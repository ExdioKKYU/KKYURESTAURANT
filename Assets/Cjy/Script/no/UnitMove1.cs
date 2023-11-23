using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove1 : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D playerRigidbody;

    public GameObject playerbulletprefab;

    int playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerRigidbody.velocity = new Vector2(-speed, 0);

        Destroy(gameObject, 20f);

        playerLayer = LayerMask.NameToLayer("player");

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerattack()
    {
        GameObject playerbullet
            = Instantiate(playerbulletprefab, transform.position, Quaternion.identity);
    }
}

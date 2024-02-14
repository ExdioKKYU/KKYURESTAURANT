using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BaseHp : MonoBehaviour
{
    public float curHealth;
    public float maxHealth;

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHpSlider();
        EndFight();
    }

    private void UpdateHpSlider()
    {
    }

    private void EndFight()
    {
        if (curHealth <= 0)
        {
            //다음 스크립트를 가진 오브젝트를 삭제
            Ability[] objectsWithAbilityScript = FindObjectsOfType<Ability>();
            foreach (Ability obj in objectsWithAbilityScript)
            {
                Destroy(obj.gameObject);
            }
            Ability_enemy[] objectsWithAbilityScript1 = FindObjectsOfType<Ability_enemy>();
            foreach (Ability_enemy obj in objectsWithAbilityScript1)
            {
                Destroy(obj.gameObject);
            }
            LineSelection[] objectsWithLineScript = FindObjectsOfType<LineSelection>();
            foreach (LineSelection obj in objectsWithLineScript)
            {
                Destroy(obj.gameObject);
            }

            //이름을 가진 단일 오브젝트를 찾아서 삭제
            GameObject objectWithNameG = GameObject.Find("GameManager");
            if (objectWithNameG != null)
            {
                Destroy(objectWithNameG);
            }
            GameObject objectWithNameS = GameObject.Find("Spawner");
            if (objectWithNameS != null)
            {
                Destroy(objectWithNameS);
            }
            GameObject objectWithNameC = GameObject.Find("UnitCanvas");
            if (objectWithNameC != null)
            {
                Destroy(objectWithNameC);
            }
            GameObject objectWithNameCC = GameObject.Find("CoinCanvas");
            if (objectWithNameCC != null)
            {
                Destroy(objectWithNameCC);
            }
            Camera MainCamera = Camera.main;
            if (MainCamera != null)
            {
                TestBack Script = MainCamera.GetComponent<TestBack>();
                if (Script != null)
                {
                    Destroy(Script);
                }
            }

            canvas.SetActive(true);

            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                // AudioSource 찾기
                AudioSource audioSource = mainCamera.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    // AudioSource 제거
                    Destroy(audioSource);
                }
            }
        }
    }
}


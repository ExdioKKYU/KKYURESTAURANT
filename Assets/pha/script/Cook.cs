using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : MonoBehaviour
{
    public GameObject KimbobPrefab;
    public GameObject Little_KimbobPrefab;
    //public GameObject Pork_cutletPrefab;
    //public GameObject Fried_sweet_potatoPrefab;
    //public GameObject TteokbokkiPrefab;
    //public GameObject SotteokPrefab;
    //public GameObject RabokkiPrefab;
    //public GameObject OmeletPrefab;
    //public GameObject RamenPrefab;

    private bool bBob;
    private bool bKim;
    //private bool bPork;
    //private bool bSweet_potato;
    private bool bSausage;
    private bool bCarrot;
    //private bool bRice_cake;
    //private bool bNoodle;
    //private bool bSecret_sauce;
    //private bool bEgg;
    //private bool bFish_cake;
    private bool bRice_roll;

    public float PosX;
    public float PosY;

    public int My_CookCount;
    public int CookCount;
    private bool Cooking = true;

    void OnTriggerStay2D(Collider2D other)
    {
        Vector3 COOKPosition = new Vector3(PosX, PosY, -1);

        CookingLine();
        if (Cooking)
        {
            if (bBob && bKim)
            {
                DestroyClosestObject("Bob");
                DestroyClosestObject("Kim");

                // kimbob 프리팹을 현재 위치에 소환
                Instantiate(Little_KimbobPrefab, COOKPosition, Quaternion.identity);
                bBob = false;
                bKim = false;
            }
            if (bRice_roll && bCarrot && bSausage)
            {
                Destroy(GameObject.FindGameObjectWithTag("Rice_roll"));
                Destroy(GameObject.FindGameObjectWithTag("Carrot"));
                Destroy(GameObject.FindGameObjectWithTag("Sausage"));

                // kimbob 프리팹을 현재 위치에 소환
                Instantiate(KimbobPrefab, COOKPosition, Quaternion.identity);
            }
        }

    }

    void DestroyClosestObject(string tag)
    {
        // 해당 태그를 가진 모든 오브젝트를 배열에 저장
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

        if (objectsWithTag.Length > 0)
        {
            // 가장 가까운 오브젝트를 찾아서 파괴
            Transform closestObject = FindClosestObject(objectsWithTag);
            if (closestObject != null)
            {
                Destroy(closestObject.gameObject);
            }
        }
    }

    Transform FindClosestObject(GameObject[] objects)
    {
        Transform closestObject = null;
        float closestDistance = float.MaxValue;

        // 배열에 저장된 모든 오브젝트와의 거리를 계산하여 가장 가까운 오브젝트를 찾음
        foreach (GameObject obj in objects)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj.transform;
            }
        }

        return closestObject;
    }

    void CookingLine()
    {
        float targetY = PosY;
        GameObject[] kimbobObjects = GameObject.FindGameObjectsWithTag("Kimbob"); 
        GameObject[] Rice_rollObjects = GameObject.FindGameObjectsWithTag("Rice_roll");

        int Kimbobs = 0;
        int Rice_rolls = 0;
        foreach (GameObject kimbobObject in kimbobObjects)
        {
            Vector3 objectPosition = kimbobObject.transform.position;

            // Y 축 값이 목표 값과 일치하는지 확인
            if (Mathf.Approximately(objectPosition.y, targetY))
            {
                // Y 축 값이 목표 값과 일치하면 개수 증가
                Kimbobs++;
            }
        }
        foreach (GameObject Rice_rollObject in Rice_rollObjects)
        {
            Vector3 objectPosition = Rice_rollObject.transform.position;

            // Y 축 값이 목표 값과 일치하는지 확인
            if (Mathf.Approximately(objectPosition.y, targetY))
            {
                // Y 축 값이 목표 값과 일치하면 개수 증가
                Rice_rolls++;
            }
        }

        My_CookCount = (Kimbobs * 20) + (Rice_rolls * 10);
        if(CookCount <= My_CookCount)
        {
            Cooking = false;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bob"))
        {
            bBob = true;
        }
        if (other.CompareTag("Kim"))
        {
            bKim = true;
        }
        //if (other.CompareTag("Pork"))
        //{
        //    bPork = true;
        //}
        //if (other.CompareTag("Sweet_potato"))
        //{
        //    bSweet_potato = true;
        //}
        if (other.CompareTag("Sausage"))
        {
            bSausage = true;
        }
        if (other.CompareTag("Carrot"))
        {
            bCarrot = true;
        }
        //if (other.CompareTag("Rice_cake"))
        //{
        //    bRice_cake = true;
        //}
        //if (other.CompareTag("Noodle"))
        //{
        //    bNoodle = true;
        //}
        //if (other.CompareTag("Secret_sauce"))
        //{
        //    bSecret_sauce = true;
        //}
        //if (other.CompareTag("Egg"))
        //{
        //    bEgg = true;
        //}
        //if (other.CompareTag("Fish_cake"))
        //{
        //    bFish_cake = true;
        //}
        //if (other.CompareTag("Rice_roll"))
        //{
        //    bRice_roll = true;
        //}

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bob"))
        {
            bBob = false;
        }
        if (other.CompareTag("Kim"))
        {
            bKim = false;
        }
        //if (other.CompareTag("Pork"))
        //{
        //    bPork = false;
        //}
        //if (other.CompareTag("Sweet_potato"))
        //{
        //    bSweet_potato = false;
        //}
        if (other.CompareTag("Sausage"))
        {
            bSausage = false;
        }
        if (other.CompareTag("Carrot"))
        {
            bCarrot = false;
        }
        //if (other.CompareTag("Rice_cake"))
        //{
        //    bRice_cake = false;
        //}
        //if (other.CompareTag("Noodle"))
        //{
        //    bNoodle = false;
        //}
        //if (other.CompareTag("Secret_sauce"))
        //{
        //    bSecret_sauce = false;
        //}
        //if (other.CompareTag("Egg"))
        //{
        //    bEgg = false;
        //}
        //if (other.CompareTag("Fish_cake"))
        //{
        //    bFish_cake = false;
        //}
        if (other.CompareTag("Rice_roll"))
        {
            bRice_roll = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        bBob = false;
        //bPork = false;
        //bSweet_potato = false;
        bSausage = false;
        bCarrot= false;
        //bRice_cake = false;
        //bNoodle = false;
        //bSecret_sauce = false;
        //bEgg = false;
        //bFish_cake = false;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}

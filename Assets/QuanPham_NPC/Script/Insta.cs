using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insta : MonoBehaviour
{
    public int ID;
    private static Insta instance;
    public static Insta Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Insta>();
            return instance;
        }
    }
    void Start()
    {
        StartCoroutine(x());
    }
    IEnumerator x()
    {
        yield return new WaitForSecondsRealtime(1);




        ID = 3;
        GameObject obj = ObjectPool.Instance.Weapon.GetPooledObject(Resources.Load<GameObject>("Weapon/Weapon"));
        obj.transform.position = transform.position + new Vector3(3,3,0);
        obj.SetActive(true);
        ID = 1;
        GameObject obj1 = ObjectPool.Instance.Weapon.GetPooledObject(Resources.Load<GameObject>("Weapon/Weapon"));
        obj1.transform.position = transform.position + new Vector3(-3, 3, 0);
        obj1.SetActive(true);
        ID = 2;
        GameObject obj2 = ObjectPool.Instance.Weapon.GetPooledObject(Resources.Load<GameObject>("Weapon/Weapon"));
        obj2.transform.position = transform.position + new Vector3(3, -3, 0);
        obj2.SetActive(true);


    }   
}





//            x/xx/xx/x  -->quai manh / kieu tan cong / kieu di chuyen /  kieu chi so//

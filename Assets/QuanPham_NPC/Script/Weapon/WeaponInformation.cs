using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInformation : WeaponScript
{
    public int IDBullet;
    public float t;
    public int countBullet;
    public GameObject pointShoot2;
    // Start is called before the first frame update

    public IEnumerator CDAttack()
    {
        isAttack = true;
        yield return new WaitForSeconds(SpeedATK);
        isAttack = false;
    }
    public IEnumerator AttackWeapon1()
    {

        yield return new WaitForSeconds(0);
        IDBullet = 0;
        SpawnBullet(ObjectPool.Instance.BulletPistal.GetPooledObject(Resources.Load<GameObject>("BulletPistal")),IDBullet);
        StartCoroutine(CDAttack());
    }
    public IEnumerator AttackWeapon2()
    {
        IDBullet = 0;
        SpawnBullet(ObjectPool.Instance.BulletPistal.GetPooledObject(Resources.Load<GameObject>("BulletPistal")), IDBullet);
        yield return new WaitForSeconds(0.1f);
        SpawnBullet(ObjectPool.Instance.BulletPistal.GetPooledObject(Resources.Load<GameObject>("BulletPistal")), IDBullet);
        StartCoroutine(CDAttack());


    }
    public IEnumerator AttackWeapon3()
    {
        int t = 0;
        if(transform.localScale.x==1)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(1, 1) * Mathf.Rad2Deg);
            IDBullet = 1;
            SpawnBullet(ObjectPool.Instance.BulletPistal.GetPooledObject(Resources.Load<GameObject>("BulletPistal")), IDBullet);
            while (transform.rotation.z >= Quaternion.Euler(0, 0, Mathf.Atan2(-2, 1) * Mathf.Rad2Deg).z)
            {
                yield return new WaitForSeconds(0.01f);
                transform.Rotate(0, 0, -10f);
            }
            Debug.LogError(t);
            IDBullet = 1;
            SpawnBullet(ObjectPool.Instance.BulletPistal.GetPooledObject(Resources.Load<GameObject>("BulletPistal")), IDBullet);
            while (transform.rotation.z <= Quaternion.Euler(0, 0, Mathf.Atan2(1, 1) * Mathf.Rad2Deg).z)
            {
                yield return new WaitForSeconds(0.01f);
                transform.Rotate(0, 0, 10f);
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-1, 1) * Mathf.Rad2Deg);
            IDBullet = 1;
            SpawnBullet(ObjectPool.Instance.BulletPistal.GetPooledObject(Resources.Load<GameObject>("BulletPistal")), IDBullet);
            while (transform.rotation.z <= Quaternion.Euler(0, 0, Mathf.Atan2(2, 1) * Mathf.Rad2Deg).z)
            {
                yield return new WaitForSeconds(0.01f);
                transform.Rotate(0, 0, 10f);
            }
            Debug.LogError(t);
            IDBullet = 1;
            SpawnBullet(ObjectPool.Instance.BulletPistal.GetPooledObject(Resources.Load<GameObject>("BulletPistal")), IDBullet);
            while (transform.rotation.z >= Quaternion.Euler(0, 0, Mathf.Atan2(-1, 1) * Mathf.Rad2Deg).z)
            {
                yield return new WaitForSeconds(0.01f);
                transform.Rotate(0, 0, -10f);
            }
        }
        
        
        StartCoroutine(CDAttack());


    }
    public IEnumerator AttackWeapon4()
    {
        yield return new WaitForSeconds(0);
        while(pointShoot2.transform.childCount>0)
        {
            pointShoot2.transform.GetChild(0).transform.SetParent(null);
        }
        
        countBullet = 0;
    }

    public void SpawnBullet2()
    {
        Vector3 dir = pointshoot.transform.position - transform.position;
        if (countBullet < 5)
        {

            IDBullet = 2;
            t += Time.deltaTime;
            if (t >= 1 )
            {
                t = 0;
                GameObject obj = SpawnBullet(ObjectPool.Instance.BulletPistal.GetPooledObject(Resources.Load<GameObject>("BulletPistal")), IDBullet);
                obj.transform.position = pointShoot2.transform.position;
                obj.transform.SetParent(pointShoot2.transform);
                if (countBullet == 0)
                {
                    obj.transform.rotation =  Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
                }
                if (countBullet == 1)
                {
                    obj.transform.rotation =  Quaternion.Euler(0, 0, Mathf.Atan2(0.3f + dir.y,-0.3f+ dir.x) * Mathf.Rad2Deg);
                }
                if (countBullet == 2)
                {
                    obj.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-0.3f + dir.y,0.3f+ dir.x) * Mathf.Rad2Deg);
                }
                if (countBullet == 3)
                {
                    obj.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(0.6f + dir.y,-0.6f+ dir.x) * Mathf.Rad2Deg);
                }
                if (countBullet == 4)
                {
                    obj.transform.rotation =  Quaternion.Euler(0, 0, Mathf.Atan2(-0.6f + dir.y,0.6f+ dir.x) * Mathf.Rad2Deg);
                }
                countBullet++;
            }
        }
    }

    public GameObject SpawnBullet(GameObject bullet, int id)
    {
        IDBullet = id;
        Vector3 dir = pointshoot.transform.position - transform.position;
        GameObject obj = bullet;
        obj.transform.position = pointshoot.transform.position;
        obj.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(Random.Range(-0.05f, .05f) + dir.y, dir.x) * Mathf.Rad2Deg);
        obj.SetActive(true);
        obj.GetComponent<BulletScript>().ATK = ATk;
        ObjectPool.Instance.BulletPistal.PooledObjects.Remove(obj);
        return obj;
    }
}

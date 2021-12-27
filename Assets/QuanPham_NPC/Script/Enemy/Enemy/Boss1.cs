using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 :EnemyInformation, Boss
{

    public int a;
    private int mode=3;

    public void BossAttack(Transform transformEnemy)
    {
        Vector3 dir = Player.transform.position - transformEnemy.position;

        Debug.DrawRay(transformEnemy.position, dir, Color.green, 0, true);

        if (Vector3.Distance(transformEnemy.position, Player.transform.position) <= Range )
        {
            if (!isAttack)
            {
                StartCoroutine(aniWeapon());
                isAttack = true;
                ModeAttack(transformEnemy);                
            }
        }
    }
    public void ModeAttack(Transform transformEnemy)
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                if (mode == 0)
                {
                    ModeAttack(transformEnemy);
                    return;
                }
                StartCoroutine(attack1());
                break;
            case 1:
                if (mode == 1)
                {
                    ModeAttack(transformEnemy);
                    return;
                }
                StartCoroutine(attack2());
                break;
            case 2:
                if (mode == 2)
                {
                    ModeAttack(transformEnemy);
                    return;
                }
                StartCoroutine(attack3());
                break;
        }
    }
    IEnumerator aniWeapon()
    {
        while (Weapon.transform.rotation.z >= Quaternion.Euler(0, 0, Mathf.Atan2(-2, 1) * Mathf.Rad2Deg).z)
        {
            yield return new WaitForSeconds(0.01f);
            Weapon.transform.Rotate(0, 0, -10f);
        }
        while (Weapon.transform.rotation.z <= Quaternion.Euler(0, 0, Mathf.Atan2(1, 1) * Mathf.Rad2Deg).z)
        {
            yield return new WaitForSeconds(0.01f);
            Weapon.transform.Rotate(0, 0, 10f);

        }
    }
    IEnumerator attack1()
    {
        mode = 0;
        Vector3 t = Player.transform.position;
        shootAttack1(t+new Vector3(1,1,0));
        shootAttack1(t+new Vector3(-1,1,0));
        shootAttack1(t+new Vector3(-1,-1,0));
        shootAttack1(t+new Vector3(1,-1,0));
        yield return new WaitForSeconds(0.5f);
        shootAttack1(t);
        yield return new WaitForSeconds(4.5f);
        isAttack = false;
    }
    IEnumerator attack2()
    {
        mode = 1;
        yield return new WaitForSeconds(0.2f);
        shootAttack2();
        yield return new WaitForSeconds(0.2f);
        shootAttack2();
        yield return new WaitForSeconds(0.2f);
        shootAttack2();
        yield return new WaitForSeconds(0.2f);
        shootAttack2();
        yield return new WaitForSeconds(0.2f);
        shootAttack2();
        yield return new WaitForSeconds(0.2f);
        shootAttack2();
        yield return new WaitForSeconds(0.2f);
        shootAttack2();
        yield return new WaitForSeconds(0.2f);
        shootAttack2();
        yield return new WaitForSeconds(0.2f);
        shootAttack2();
        yield return new WaitForSeconds(0.2f);
        shootAttack2();
        yield return new WaitForSeconds(3f);
        isAttack = false;
    }
    IEnumerator attack3()
    {
        mode =2;
        Vector3 t = Player.transform.position;
        shootAttack3();
        shootAttack3();
        shootAttack3();
        shootAttack3();
        yield return new WaitForSeconds(.5f);
        shootAttack3();
        shootAttack3();
        shootAttack3();
        shootAttack3();
        yield return new WaitForSeconds(4.5f);
        isAttack = false;
    }

    public void shootAttack1(Vector3 transform)
    {
        BulletEnemyScript.IDBullet = 4;
        Vector3 dir2 = Player.transform.position - PointShoot2.transform.position;
        GameObject obj = ObjectPool.Instance.BulletEnemy.GetPooledObject(Resources.Load<GameObject>("Enemy/BulletEnemy/BulletEnemy"));
        obj.transform.position = PointShoot2.transform.position;
        obj.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg);
        obj.SetActive(true);
    }
    public void shootAttack2()
    {
        BulletEnemyScript.IDBullet = 5;
        Vector3 dir2 = Player.transform.position - PointShoot2.transform.position;
        GameObject obj = ObjectPool.Instance.BulletEnemy.GetPooledObject(Resources.Load<GameObject>("Enemy/BulletEnemy/BulletEnemy"));
        switch(Random.Range(0,3))
        {
            case 0:
                obj.transform.position = PointShoot0.transform.position;
                break;
            case 1:
                obj.transform.position = PointShoot1.transform.position;
                break;
            case 2:
                obj.transform.position = PointShoot2.transform.position;
                break;
        }
        obj.transform.rotation  = Quaternion.Euler(0, 0, Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg);
        obj.SetActive(true);
    }
    public void shootAttack3()
    {
        BulletEnemyScript.IDBullet = 6;
        GameObject obj = ObjectPool.Instance.BulletEnemy.GetPooledObject(Resources.Load<GameObject>("Enemy/BulletEnemy/BulletEnemy"));
        obj.transform.position = new Vector3(transform.position.x + Random.Range(-50,60)/10, transform.position.y + Random.Range(-40, 50) / 10,0);
        Vector3 dir2 = Player.transform.position - obj.transform.position;
        obj.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg);
        obj.SetActive(true);
    }
    public void BossMove(Transform transformEnemy, int speedmoving)
    {
        Vector3 dir = Player.transform.position - transformEnemy.position;
        if(Health<MaxHealth/2&&timeRun<=4)
        {
            timeRun += Time.deltaTime;
            
            GetComponent<Rigidbody2D>().velocity = -new Vector2(dir.normalized.x * Time.deltaTime * 10 * SpeedMoving, dir.normalized.y * Time.deltaTime * 10 * SpeedMoving);
            return;
        }
        Debug.DrawRay(Weapon.transform.position,  Player.transform.position- transformEnemy.position , Color.green, 0, true);
 
        TimeMove += Time.deltaTime;
        if (TimeMove >= MaxTimeMove)
        {
            TimeMove = 0;
            PointMove = new Vector2(transform.position.x + Random.Range(-2, 3), transform.position.y + Random.Range(-2, 3));           
        }
        Vector3 dir2 = transform.position - new Vector3(PointMove.x, PointMove.y, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(dir2.normalized.x * Time.deltaTime * 10 * SpeedMoving, dir2.normalized.y * Time.deltaTime * 10 * SpeedMoving);
    }

    void Update()
    {
        if(isDeath)
        {
            return;
        }
        Weapon.GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100) + 1;
        BossMove(transform, SpeedMoving);
        BossAttack(transform);
        DirectionEnemy();

        if(Health<=0)
        {
            Death();
        }
    }

    private void OnEnable()
    {
        StartCoroutine(ani());
        isDeath = false;
    }

    private void Death()
    {
        StartCoroutine(timeDeath());        
    }

    IEnumerator timeDeath()
    {
        isDeath = true;
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall")
        {
            PointMove = new Vector2(transform.position.x + Random.Range(-2, 3), transform.position.y + Random.Range(-2, 3));
        }
        
    }

}

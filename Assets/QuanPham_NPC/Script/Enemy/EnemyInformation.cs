using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInformation : EnemyScript
{
    public float timeRun;
    public bool isAttack;
    public float TimeMove =2;
    public float TimeAttack;
    public int MaxTimeMove=2;
    public Vector2 PointMove;
    public Vector3 dir;

    public GameObject PointShoot, PointShoot1, PointShoot2,PointShoot0;

    public int ScaleY;
    public bool Shoot;

    public IEnumerator ani()
    {
        while (!isDeath)
        {
            while (AvtEnemy.transform.localScale.y > 0.9f)
            {
                yield return new WaitForSeconds(0.2f);
                AvtEnemy.transform.localScale -= new Vector3(0, 0.05f, 0);
            }
            while (AvtEnemy.transform.localScale.y < 1)
            {
                yield return new WaitForSeconds(0.2f);
                AvtEnemy.transform.localScale += new Vector3(0, 0.05f, 0);
            }
        }
    }
    public void Infor(string name, int speedATK, int range, int scale, Sprite spriteEnemy, Sprite spriteWeapon,bool weap)
    {
        Name = name;
        SpeedATK = speedATK;
        Range = range;
        Scale = scale;
        AvtEnemy.GetComponent<SpriteRenderer>().sprite = spriteEnemy;
        Weapon.GetComponent<SpriteRenderer>().sprite = spriteWeapon;
        Weapon.GetComponent<CapsuleCollider2D>().enabled = weap;
    }

    public void Index(int level, int maxHealth, int speedMoving, int atk)
    {
        Level = level;
        MaxHealth = maxHealth + (int)maxHealth * (level - 1);
        Health = maxHealth;
        SpeedMoving = speedMoving;
        ATK = atk + (int)1 * (level - 1) / 2;
    }

    public void MoveRandom(int speedmoving)
    {
        TimeMove += Time.deltaTime;
        if (TimeMove >= MaxTimeMove)
        {
            TimeMove = 0;
            PointMove = new Vector2(transform.position.x + Random.Range(-2, 3), transform.position.y + Random.Range(-2, 3));
        }
        Vector3 dir2 = transform.position - new Vector3(PointMove.x, PointMove.y, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(dir2.normalized.x * Time.deltaTime * 10 * speedmoving, dir2.normalized.y * Time.deltaTime * 10 * speedmoving);
    }

   IEnumerator CDAttack(int speedAttack)
    {
        yield return new WaitForSeconds(speedAttack);
        isAttack = false;
    }

    public void MeleeAttack1(Transform transformEnemy)
    {
        dir = Player.transform.position - transformEnemy.position;
        if (Vector3.Distance(Weapon.transform.position, Player.transform.position) <= 0.8f*Scale && !isAttack)
        {
            isAttack = true;
            StartCoroutine(meleeAttack1());
        }
    }
    public void MeleeMove1(Transform transformEnemy, int speedmoving)
    {
        dir = Player.transform.position - transformEnemy.position;
        if (Health < MaxHealth / 2 && timeRun <= 4)
        {
            timeRun += Time.deltaTime;
            GetComponent<Rigidbody2D>().velocity = -new Vector2(dir.normalized.x * Time.deltaTime * 10 * speedmoving, dir.normalized.y * Time.deltaTime * 10 * speedmoving);
            return;
        }
        if (Vector3.Distance(transformEnemy.position, Player.transform.position) <= Range && !isAttack && Physics2D.Raycast(transformEnemy.position, dir, 1 << Range, maskPlayer))
        {
            if (Physics2D.Raycast(transformEnemy.position, dir, 1 << Range, maskPlayer).collider.tag == "Player")
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(dir.normalized.x * Time.deltaTime * 10 * speedmoving, dir.normalized.y * Time.deltaTime * 10 * speedmoving);
                return;
            }
        }
        MoveRandom(speedmoving);
    }
    IEnumerator meleeAttack1()
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
        StartCoroutine(CDAttack(SpeedATK));
    }
    //------------------------------------------------------------------------
    public void RangedAttack1(Transform transformEnemy)
    {
        dir = Player.transform.position - transformEnemy.position;
        if (dir.x >= 0)
        {
            Weapon.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            Weapon.transform.localScale = new Vector3(-1, -1, 1); 
        }
        Weapon.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        if (Vector3.Distance(transformEnemy.position, Player.transform.position) <= Range && Physics2D.Raycast(transformEnemy.position, dir, 1 << Range, maskPlayer))
        {
            if (Physics2D.Raycast(transformEnemy.position, dir, 1 << Range, maskPlayer).collider.tag == "Player")
            {
                if (!isAttack)
                {
                    isAttack = true;
                    StartCoroutine(rangedAttack1());
                }
            }
        }
    }
    IEnumerator rangedAttack1()
    {
        shootRangedAttack1();
        yield return new WaitForSeconds(0.1f);
        shootRangedAttack1();
        yield return new WaitForSeconds(0.1f);
        shootRangedAttack1();
        StartCoroutine(CDAttack(SpeedATK));
    }
    public void shootRangedAttack1()
    {
        BulletEnemyScript.IDBullet = 1;
        GameObject obj = ObjectPool.Instance.BulletEnemy.GetPooledObject(Resources.Load<GameObject>("Enemy/BulletEnemy/BulletEnemy"));
        obj.transform.position = PointShoot.transform.position;
        obj.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(Random.Range(-.2f,.2f)+ dir.y, dir.x) * Mathf.Rad2Deg);
        obj.SetActive(true);
        obj.GetComponent<BulletEnemyScript>().ATKBullet = ATK;
    }
    public void RangedMove1(Transform transformEnemy, int speedmoving)
    {
        MoveRandom(speedmoving);
    }
    //------------------------------------------------------------------------
    public void MeleeAttack2(Transform transformEnemy)
    {
        dir = Player.transform.position - transformEnemy.position;
        if (dir.x >= 0)
        {
            Weapon.transform.localScale = new Vector3(1.3f, ScaleY, 1);
        }
        else
        {
            Weapon.transform.localScale = new Vector3(-1.3f, -ScaleY, 1); ;
        }
        Weapon.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        if (Vector3.Distance(Weapon.transform.position, Player.transform.position) <= 0.8f*Scale && !isAttack)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            isAttack = true;
            StartCoroutine(CDAttack(SpeedATK));
        }
        if (isAttack)
        {
            ScaleY = 0;
        }
    }
    public void MeleeMove2(Transform transformEnemy, int speedmoving)
    {
        dir = Player.transform.position - transformEnemy.position;
        Vector3 dir2 = transformEnemy.position - new Vector3(PointMove.x, PointMove.y, 0);
        if (Health < MaxHealth / 2 && timeRun <= 4)
        {
            timeRun += Time.deltaTime;
            GetComponent<Rigidbody2D>().velocity = -new Vector2(dir.normalized.x * Time.deltaTime * 10 * speedmoving, dir.normalized.y * Time.deltaTime * 10 * speedmoving) ;
            return;
        }        
        if (Vector3.Distance(transformEnemy.position, Player.transform.position) <= 5 && !isAttack && Physics2D.Raycast(transformEnemy.position, dir, 1 << 5, maskPlayer))
        {
            if (Physics2D.Raycast(transformEnemy.position, dir, 1 << 5, maskPlayer).collider.tag == "Player")
            {
                if (Vector3.Distance(transformEnemy.position, Player.transform.position) <= 3 && !isAttack)
                {
                    ScaleY = 1;
                    gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(dir.normalized.x * Time.deltaTime * 40 * speedmoving, dir.normalized.y * Time.deltaTime * 40 * speedmoving) ;
                    return;
                }
                GetComponent<Rigidbody2D>().velocity = new Vector2(dir.normalized.x * Time.deltaTime * 10 * speedmoving, dir.normalized.y * Time.deltaTime * 10 * speedmoving) ;
                return;
            }
        }
        MoveRandom(speedmoving);
    }
    //------------------------------------------------------------------------
    public void RangedAttack2(Transform transformEnemy)
    {
        dir = Player.transform.position - transformEnemy.position;
        if (dir.x >= 0)
        {
            Weapon.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            Weapon.transform.localScale = new Vector3(-1, -1, 1); ;
        }
        Weapon.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        if (Vector3.Distance(transformEnemy.position, Player.transform.position) <= Range && Physics2D.Raycast(transformEnemy.position, dir, 1 << Range, maskPlayer))
        {
            if (Physics2D.Raycast(transformEnemy.position, dir, 1 << Range, maskPlayer).collider.tag == "Player")
            {
                if (!isAttack)
                {
                    isAttack = true;
                    StartCoroutine(rangedAttack2());
                }
            }
        }
    }
    IEnumerator rangedAttack2()
    {
        Shoot = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
        shootRangedAttack2();
        yield return new WaitForSeconds(3);
        GetComponent<Rigidbody2D>().isKinematic = false;
        StartCoroutine(CDAttack(SpeedATK));
        Shoot = false;
    }
    public void shootRangedAttack2()
    {
        BulletEnemyScript.IDBullet = 2;
        GameObject obj = ObjectPool.Instance.BulletEnemy.GetPooledObject(Resources.Load<GameObject>("Enemy/BulletEnemy/BulletEnemy"));
        obj.transform.position = PointShoot0.transform.position;
        obj.transform.rotation = Weapon.transform.rotation;
        obj.SetActive(true);
        obj.transform.SetParent(Weapon.gameObject.transform);
        obj.transform.localScale = new Vector3(1, 1, 1);
        obj.GetComponent<BulletEnemyScript>().ATKBullet = ATK;
    }
    public void RangedMove2(Transform transformEnemy, int speedmoving)
    {
        if (Shoot)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }
        MoveRandom(speedmoving);
    }
    //------------------------------------------------------------------------
    public void RangedAttack3(Transform transformEnemy)
    {
        dir = Player.transform.position - transformEnemy.position;
        if (dir.x >= 0)
        {
            Weapon.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            Weapon.transform.localScale = new Vector3(-1, -1, 1); ;
        }
        Weapon.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        if (Vector3.Distance(transformEnemy.position, Player.transform.position) <= Range && Physics2D.Raycast(transformEnemy.position, dir, 1 << Range, maskPlayer))
        {
            if (Physics2D.Raycast(transformEnemy.position, dir, 1 << Range, maskPlayer).collider.tag == "Player")
            {
                if (!isAttack)
                {
                    isAttack = true;
                    StartCoroutine(rangedAttack3());
                }
            }
        }
    }
    IEnumerator rangedAttack3()
    {
        shootRangedAttack3();
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(CDAttack(SpeedATK));
    }
    public void shootRangedAttack3()
    {
        Vector3 d1 = PointShoot1.transform.position - PointShoot.transform.position;
        Vector3 d2 = PointShoot2.transform.position - PointShoot.transform.position;
        float t = Random.Range(-.2f, .2f);
        BulletShootRangedAttack3("Enemy/BulletEnemy/BulletEnemy", PointShoot.transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(  d1.y, d1.x) * Mathf.Rad2Deg), new Vector3(1, 1, 1));
         t = Random.Range(-.2f, .2f);
        BulletShootRangedAttack3("Enemy/BulletEnemy/BulletEnemy", PointShoot.transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(d2.y, d2.x) * Mathf.Rad2Deg), new Vector3(1, 1, 1));
         t = Random.Range(-.2f, .2f);
        BulletShootRangedAttack3("Enemy/BulletEnemy/BulletEnemy", PointShoot.transform.position, Quaternion.Euler(0, 0, Mathf.Atan2( dir.y,  dir.x) * Mathf.Rad2Deg),new Vector3(1, 1, 1));
    }
    private void BulletShootRangedAttack3(string NameBullet, Vector3 startPosition,Quaternion startRotatin, Vector3 startScale)
    {
        
        BulletEnemyScript.IDBullet = 3;
        GameObject obj = ObjectPool.Instance.BulletEnemy.GetPooledObject(Resources.Load<GameObject>(NameBullet));
        obj.transform.position = startPosition;
        obj.transform.rotation = startRotatin; 
        obj.SetActive(true);
        obj.transform.localScale = startScale;
        obj.GetComponent<BulletEnemyScript>().ATKBullet = ATK;

    }
    public void RangedMove3(Transform transformEnemy, int speedmoving)
    {
        MoveRandom(speedmoving);
    }
}

public interface type
{
    public void Move();
    public void Attack();
}







public interface Boss
{
    public void BossMove(Transform transformEnemy, int speedmoving);
    public void BossAttack(Transform transformEnemy);
}



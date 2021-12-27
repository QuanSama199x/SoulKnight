using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : EnemyInformation, Boss
{

    public int a;
    public bool attacking;
    private int mode = 0;

    public void BossAttack(Transform transformEnemy)
    {
        dir = Player.transform.position - transformEnemy.position;
        if (Vector3.Distance(transformEnemy.position, Player.transform.position) <= Range)
        {
            if (!isAttack)
            {
                attacking = true;
                isAttack = true;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                ModeAttack(transformEnemy);
            }
        }
    }
    public void ModeAttack(Transform transformEnemy)
    {
        if(mode >=3)
        {
            mode = 0;
            StartCoroutine(attack2());
            return;
        }
        mode++;
        StartCoroutine(attack1());        
    }
   
    IEnumerator attack1()
    {
        float time = 0;
        while (time<5)
        {
            dir = Player.transform.position - transform.position;
            yield return new WaitForSeconds(0.01f);
            Weapon.transform.Rotate(0, 0, -10f);
            time += 0.02f;
            GetComponent<Rigidbody2D>().velocity = new Vector2(dir.normalized.x * Time.deltaTime * 10 * SpeedMoving, dir.normalized.y * Time.deltaTime * 10 * SpeedMoving);
        }
        Weapon.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(2, 1) * Mathf.Rad2Deg);
        attacking = false;
        yield return new WaitForSeconds(5);
        isAttack = false;
    }
    IEnumerator attack2()
    {
        float t = 0;
        yield return new WaitForSeconds(1f);
        Vector3 x = Player.transform.position;
        Vector3 dir2 = x- transform.position;
        yield return new WaitForSeconds(.5f);
        while(Vector3.Distance(x,transform.position)>=2f|| t >=1)
        {
            yield return new WaitForSeconds(0.01f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(dir2.normalized.x * Time.deltaTime * 100 * SpeedMoving, dir2.normalized.y * Time.deltaTime * 100 * SpeedMoving);
            t += 0.02f;
        }
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
       attacking = false;
        yield return new WaitForSeconds(5);
        isAttack = false;
    }
 
    public void BossMove(Transform transformEnemy, int speedmoving)
    {
        if(attacking)
        {
                    return;   
        }
         dir = Player.transform.position - transformEnemy.position;
        if (Health < MaxHealth / 2 && timeRun <= 4)
        {
            timeRun += Time.deltaTime;
            GetComponent<Rigidbody2D>().velocity = -new Vector2(dir.normalized.x * Time.deltaTime * 10 * SpeedMoving, dir.normalized.y * Time.deltaTime * 10 * SpeedMoving);
            return;
        }
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
        if (isDeath)
        {
            return;
        }
        Weapon.GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100) + 1;
        BossMove(transform, SpeedMoving);
        BossAttack(transform);
        DirectionEnemy();
        if (Health <= 0)
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

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            PointMove = new Vector2(transform.position.x + Random.Range(-2, 3), transform.position.y + Random.Range(-2, 3));
        }
    }

}

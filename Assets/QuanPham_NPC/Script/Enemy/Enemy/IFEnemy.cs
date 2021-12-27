using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IFEnemy : EnemyInformation
{
    private static IFEnemy instance;
    public static IFEnemy Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<IFEnemy>();
            return instance;
        }
    }
    public bool isHavePlayer;
    public int a;
    public static string IDEnemy;
  
    void Update()
    {

        Weapon.GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100) + 1;
        if(!isHavePlayer)
        {
            return;
        }
        if (isDeath)
        {
            return;
        }              
        
        switch (ID.Substring(1, 2))
        {
            case "01":
                MeleeAttack1(transform);
                break;
            case "02":
                RangedAttack1(transform);
                break;
            case "03":
                MeleeAttack2(transform);
                break;
            case "04":
                RangedAttack2(transform);
                break;
            case "05":
                RangedAttack3(transform);
                break;
        }
        switch (ID.Substring(3,2))
        {
            case "01":
                MeleeMove1(transform, SpeedMoving);
                break;
            case "02":
                RangedMove1(transform, SpeedMoving);
                break;
            case "03":
                MeleeMove2(transform, SpeedMoving);
                break;
            case "04":
                RangedMove2(transform, SpeedMoving);
                break;
            case "05":
                RangedMove3(transform, SpeedMoving);
                break;           
        }        
        DirectionEnemy();
        if(Health<=0)
        {
            Death();
        }
    }
    
    private void OnEnable()
    {
        ID = IDEnemy;
        /*ID = Insta.Instance.IDEnemy;*/
        StartCoroutine(ani());
        isDeath = false;

        switch (ID.Substring(1,2))
        {
            case "01":
                Infor("Emoi", 5, 4,1, SpriteEnemy.Enemy[2], SpriteEnemy.Weapon[1],true);
                break;
            case "02":
                Infor("Laudaitinhaido", 3, 5,1, SpriteEnemy.Enemy[1], SpriteEnemy.Weapon[0],false);
                break;
            case "03":
                Infor("Chackhong", 5, 5,1, SpriteEnemy.Enemy[0], SpriteEnemy.Weapon[2],true);
                break;
            case "04":
                Infor("Cotren", 6, 7,1, SpriteEnemy.Enemy[2], SpriteEnemy.Weapon[0],false);
                break;
            case "05":
                Infor("Trangian", 3, 7,1, SpriteEnemy.Enemy[0], SpriteEnemy.Weapon[3],false);
                break;
        }
        Index(1,SpriteEnemy.Index[int.Parse(ID.Substring(5,1))].MaxHealth, SpriteEnemy.Index[int.Parse(ID.Substring(5, 1))].SpeedMoving, SpriteEnemy.Index[int.Parse(ID.Substring(5, 1))].ATK);
        if (ID.Substring(0, 1) == "1")
        {
            Scale *= 1.5f;
            ATK *= 2;
            MaxHealth *= 2;
            Health = MaxHealth;
        }
    }
    
    private void Death()
    {
        StartCoroutine(timeDeath());    
    }

    IEnumerator timeDeath()
    {

        isDeath = true;
        transform.SetParent(null);
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    public void OnDisable()
    {
        
        Level = 1;
        MaxHealth = 10;
        Health = MaxHealth;
        ATK = 2;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall"|| other.gameObject.tag == "Blocker")
        {
            int x, y;
            Vector3 t = transform.position - other.transform.position;
            if(t.x>0)
            {
                x = -30;
            }
            else
            {
                x = 30;
            }
            if (t.y > 0)
            {
                y = -30;
            }
            else
            {
                y = 30;
            }
            PointMove = new Vector2(transform.position.x+Random.Range(0,x)/10f,transform.position.y + Random.Range(0, y) / 10f);
        }
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "BulletPlayer")
        {
            Death();
        }
    }
}


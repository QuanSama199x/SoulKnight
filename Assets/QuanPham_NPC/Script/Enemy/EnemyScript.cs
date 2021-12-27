using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject Player;

    public string ID;
    public string Name;
    public int Level;
    public int MaxHealth;
    public int Health;
    public int SpeedMoving;
    public int ATK;
    public int SpeedATK;
    public int  Range ;
    public float Scale;
    public GameObject AvtEnemy;
    public GameObject Weapon;
    public SpriteEnemy SpriteEnemy;

    public bool isDeath;
    public LayerMask maskPlayer;

    void Start()
    {

        Player = GameObject.Find("Player");
    }

    public void DirectionEnemy()
    {
        AvtEnemy.GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100);
        Vector2 followEnemy = transform.position - PlayerScript.Instance.transform.position;
        if (followEnemy.x >= 0)
        {
            transform.localScale = new Vector3(-Scale, Scale, Scale);
        }
        else
        {
            transform.localScale = new Vector3(Scale, Scale, Scale);
        }
    }  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private static PlayerScript instance;
    public static PlayerScript Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PlayerScript>();
            return instance;
        }
    }
    public int Health;
    public int MaxHealth;
    public int Mana;
    public int MaxMana;
    public int Shield;
    public int MaxShield;


    public GameObject Weapon;
    public GameObject Character;
    public Vector3 x;
    public LayerMask maskPlayer;
    public int range  = 0 << 8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Character.GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y*100);


        if(EnemyManager.Instance.ListEnemy.Count>0)
        {
            DirectionPlayer();
        }


        if(Shield<0)
        {
            Health = Health + Shield;
            Shield = 0;
            EventScript.Instance.SHowHealth.Invoke();
            EventScript.Instance.ShowShield.Invoke();
        }
    }


   public void DirectionPlayer()
    {/*Physics2D.CircleCast*/
        
        Vector3 dir = EnemyManager.Instance.ListEnemy[EnemyManager.Instance.j].transform.position -transform.position;
        
        Debug.DrawRay(Weapon.transform.position, dir,Color.green,0,true);
        if (EnemyManager.Instance.ListEnemy.Count>0&& Vector3.Distance(transform.position,EnemyManager.Instance.ListEnemy[EnemyManager.Instance.j].transform.position)<=8 
            && Physics2D.Raycast(transform.position, dir, range, maskPlayer) && EnemyManager.Instance.ListEnemy[EnemyManager.Instance.j].activeInHierarchy)
        {
            
            if(Physics2D.Raycast(transform.position, dir,range, maskPlayer).collider.tag =="Enemy")
            {
                if (dir.x > 0)
                {
                    Character.transform.localScale = new Vector3(1, 1, 1);


                }
                else
                {
                    Character.transform.localScale = new Vector3(-1, 1, 1);


                }
                return;
            }
            
            
        }
            if(TestController.Instance.Swipe.x>0)
            {
                Character.transform.localScale = new Vector3(1, 1, 1);

            
            }
            else if(TestController.Instance.Swipe.x < 0)
            {
                Character.transform.localScale = new Vector3(-1, 1, 1);

            }

            
            
        
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Coin")
        {
            EventScript.Instance.GetCoin.Invoke();
        }
        if(other.tag == "Mana")
        {
            EventScript.Instance.GetMana.Invoke();
        }

    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (Shield > 0)
            {
                Shield--;
                EventScript.Instance.ShowShield.Invoke();
            }
            else
            {
                Health--;
                EventScript.Instance.SHowHealth.Invoke();
            }

        }
    }
}

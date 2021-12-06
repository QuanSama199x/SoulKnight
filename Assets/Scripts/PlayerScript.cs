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

    public GameObject Weapon;
    public GameObject Character;
    public Vector3 x;
    private RaycastHit2D vision;
    public int range  = 0 << 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Weapon.transform.forward = x;*/
        Character.GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y*100);
        Weapon.GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100-1);

        DirectionPlayer();
    }


   public void DirectionPlayer()
    {/*Physics2D.CircleCast*/
        Vector3 dir = EnemyManager.Instance.ListEnemy[FindEnemy.Instance.j].transform.position -transform.position;
        Debug.DrawRay(Weapon.transform.position, dir,Color.red);
        if (EnemyManager.Instance.ListEnemy.Count>0&& Vector3.Distance(transform.position,EnemyManager.Instance.ListEnemy[FindEnemy.Instance.j].transform.position)<=8 
            && Physics2D.Raycast(transform.position, dir, range, 1))
        {
            
            if(Physics2D.Raycast(transform.position, dir,range,1).collider.tag =="Enemy")
            {
                if (dir.x > 0)
                {
                    Character.transform.localScale = new Vector3(1, 1, 1);
                    Weapon.transform.localScale = new Vector3(1, 1, 1);

                }
                else
                {
                    Character.transform.localScale = new Vector3(-1, 1, 1);
                    Weapon.transform.localScale = new Vector3(1, -1, 1);

                }
                Weapon.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
                return;
            }
            
            
        }
            if(TestController.Instance.Swipe.x>0)
            {
                Character.transform.localScale = new Vector3(1, 1, 1);
                Weapon.transform.localScale = new Vector3(1, 1, 1);;
                Weapon.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(TestController.Instance.Swipe.y, TestController.Instance.Swipe.x) * Mathf.Rad2Deg);
            }
            else if(TestController.Instance.Swipe.x < 0)
            {
                Character.transform.localScale = new Vector3(-1, 1, 1);
                Weapon.transform.localScale = new Vector3(1, -1, 1);
                Weapon.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(TestController.Instance.Swipe.y, TestController.Instance.Swipe.x) * Mathf.Rad2Deg);
            }

            

        
    }
}

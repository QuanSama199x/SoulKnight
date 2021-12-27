using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    
    public GameObject pointshoot;
    public int IDWeapon;
    public string NameWeapon;
    public int ManaCost;
    public int ATk;
    public float SpeedATK;

    public bool isAttack;
    public DataWeapon Weapon;

    public int IDWeapon2;
    public GameObject iconWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DirectionWeaponFollowEnemy()
    {
        if (EnemyManager.Instance.ListEnemy.Count == 0)
        {
            return;
        }
        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100-30);
        Vector3 dir = EnemyManager.Instance.ListEnemy[EnemyManager.Instance.j].transform.position - transform.position;

        if (EnemyManager.Instance.ListEnemy.Count > 0 && Vector3.Distance(transform.position, EnemyManager.Instance.ListEnemy[EnemyManager.Instance.j].transform.position) <= 8
            && Physics2D.Raycast(transform.position, dir,PlayerScript.Instance.range,PlayerScript.Instance.maskPlayer) && EnemyManager.Instance.ListEnemy[EnemyManager.Instance.j].activeInHierarchy)
        {

            if (Physics2D.Raycast(transform.position, dir, PlayerScript.Instance.range, PlayerScript.Instance.maskPlayer).collider.tag == "Enemy")
            {
                if (dir.x > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);

                }
                else
                {

                    transform.localScale = new Vector3(1, -1, 1);

                }
                transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
                return;
            }


        }
        if (TestController.Instance.Swipe.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); ;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(TestController.Instance.Swipe.y, TestController.Instance.Swipe.x) * Mathf.Rad2Deg);

        }
        else if (TestController.Instance.Swipe.x < 0)
        {
            transform.localScale = new Vector3(1, -1, 1);
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(TestController.Instance.Swipe.y, TestController.Instance.Swipe.x) * Mathf.Rad2Deg);
        }
    }
    public void DirectionWeapon()
    {
        float d = transform.localScale.x;
        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100 - 30);
        
        if (TestController.Instance.Swipe.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); ;
        }
        else if (TestController.Instance.Swipe.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}

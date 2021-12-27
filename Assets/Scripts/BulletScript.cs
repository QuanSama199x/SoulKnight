using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int doben;
    public int min;
    public int ATK;
    public int IDBullet;
    public int SpeedMoving;
    public DataBullet SpriteBullet;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        switch(IDBullet)
        {
            case 0:
                transform.Translate(Vector3.right * SpeedMoving * Time.deltaTime);
                break;
            case 1:
                if (EnemyManager.Instance.ListEnemy.Count > 0)
                {

                    min = EnemyManager.Instance.findenemymin(transform.gameObject, min);
                    if (Vector3.Distance(transform.position, EnemyManager.Instance.ListEnemy[min].transform.position) <= 10)
                    {
                        Vector3 dir = EnemyManager.Instance.ListEnemy[min].transform.position - transform.position;
                        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
                    }

                }
                transform.Translate(Vector3.right * SpeedMoving * Time.deltaTime);
                break;
            case 2:
                if(transform.parent != null)
                {
                    transform.position = transform.parent.transform.position;
                    return;
                }
                Debug.LogError("nah");
                transform.Translate(Vector3.right * SpeedMoving * Time.deltaTime);
                break;

        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="Wall"|| other.gameObject.tag == "nonWall")
        {
            if(transform.parent!=null)
            {
                return;
            }
            Debug.LogError(other.gameObject.tag);
           /* if(doben==0)
            {*/
                gameObject.SetActive(false);
                ObjectPool.Instance.BulletPistal.PooledObjects.Add(gameObject);
            /*    return;
            }
            doben--;
            SpeedMoving = -SpeedMoving;*/

        }
        if (other.gameObject.tag == "Enemy" )
        {
            if(transform.parent!=null)
            {
                return;
            }
            if(IDBullet ==2)
            {
                transform.SetParent(other.transform);
                StartCoroutine(CDExplode());
                return;
            }
            Debug.LogError(other.gameObject.tag);
            gameObject.SetActive(false);
            ObjectPool.Instance.BulletPistal.PooledObjects.Add(gameObject);
        }
        if (other.gameObject.tag == "Blocker" && IDBullet != 2)
        {
            Debug.LogError(other.gameObject.tag);
            gameObject.SetActive(false);
            ObjectPool.Instance.BulletPistal.PooledObjects.Add(gameObject);
        }
    }
    private void OnEnable()
    {
        doben = 2;
        IDBullet = IFWeapon.Instance.IDBullet;

        switch(IDBullet)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = SpriteBullet.Bullet[0];
                SpeedMoving = 20;
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = SpriteBullet.Bullet[1];
                StartCoroutine(DelayBullet1());
                break;
            case 2:
                SpeedMoving = 10;
                GetComponent<SpriteRenderer>().sprite = SpriteBullet.Bullet[2];
                
                break;
        }
    }


    IEnumerator DelayBullet1()
    {
        SpeedMoving = 0;
        yield return new WaitForSeconds(1);
        SpeedMoving = 5;
    }
    IEnumerator CDExplode()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        ObjectPool.Instance.BulletPistal.PooledObjects.Add(gameObject);

    }

}

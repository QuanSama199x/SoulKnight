using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        /*dir = EnemyManager.Instance.ListEnemy[FindEnemy.Instance.j].transform.position - PlayerScript.Instance.transform.position;
        if (EnemyManager.Instance.ListEnemy.Count > 0 && Vector3.Distance(PlayerScript.Instance.transform.position, EnemyManager.Instance.ListEnemy[FindEnemy.Instance.j].transform.position) <= 8
            && Physics2D.Raycast(transform.position, dir, PlayerScript.Instance.range, 1))
        {

            if (Physics2D.Raycast(transform.position, dir, PlayerScript.Instance.range, 1).collider.tag == "Enemy")
            {
                GetComponent<Rigidbody2D>().velocity = dir;
                return;
            }


        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(TestController.Instance.Swipe.x, TestController.Instance.Swipe.y);*/
    }

    // Update is called once per frame
    void Update()
    {
        /*GetComponent<Rigidbody2D>().velocity = new Vector2(PlayerScript.Instance.Weapon.transform.rotation.x, PlayerScript.Instance.Weapon.transform.rotation.y);*/
        transform.Translate(Vector3.right * 20 * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="Wall"|| other.gameObject.tag == "nonWall")
        {
            Debug.LogError(other.gameObject.tag);
            gameObject.SetActive(false);
            ObjectPool.Instance.BulletPistal.PooledObjects.Add(gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            Debug.LogError(other.gameObject.tag);
            gameObject.SetActive(false);
            ObjectPool.Instance.BulletPistal.PooledObjects.Add(gameObject);
        }
        if (other.gameObject.tag == "Blocker")
        {
            Debug.LogError(other.gameObject.tag);
            gameObject.SetActive(false);
            ObjectPool.Instance.BulletPistal.PooledObjects.Add(gameObject);
        }
    }
}

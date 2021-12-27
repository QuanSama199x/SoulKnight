using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyScript : MonoBehaviour
{
    public static int IDBullet;
    private int ID;
    private float Speed = 20;
    private GameObject Player;

    public int ATKBullet;
        

    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100);
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
        switch(ID)
        {
            case 2:
                if (Speed == 0)
                {
                    transform.localScale += new Vector3(.004f, .004f, 0);
                }
                break;
            case 3:
                Vector3 followPlayer = Player.transform.position - transform.position;
                if (transform.rotation.z > Quaternion.Euler(0, 0, Mathf.Atan2(followPlayer.y, followPlayer.x) * Mathf.Rad2Deg).z)
                {
                    transform.Rotate(0, 0, -0.3f);
                }
                else
                {
                    transform.Rotate(0, 0, 0.3f);
                }
                break;
            case 6:
                Speed += 0.05f;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Wall" || other.tag == "Blocker")
        {
            gameObject.SetActive(false);
        }
        if (other.tag =="Player")
        {
            if(other.GetComponent<PlayerScript>().Shield >0)
            {
                other.GetComponent<PlayerScript>().Shield -= ATKBullet;
                EventScript.Instance.ShowShield.Invoke();
            }
            else
            {
                other.GetComponent<PlayerScript>().Health -= ATKBullet;
                EventScript.Instance.SHowHealth.Invoke();
            }
        }
    }

    private void OnEnable()
    {
        ID = IDBullet;
        transform.localScale = new Vector3(1, 1, 1);
        switch (ID)
        {
            case 1:
                Speed = 20;
                break;
            case 2:
                Speed = 13;
                StartCoroutine(delay());
                break;
            case 3:
                Speed = 3;
                break;
            case 4:
                Speed = 5;
                transform.localScale = new Vector3(1.3f, 1.3f, 1);
                float dir;
                if (Random.Range(0, 2) == 0)
                {
                    dir = 1;
                }
                else
                {
                    dir = -1;
                }
                StartCoroutine(Rotate4(dir));
                break;
            case 5:
                transform.localScale = new Vector3(1.3f, 1.3f, 1);
                Speed = 5;
                float dir2;
                if (Random.Range(0, 2) == 0)
                {
                    dir2 = 3;
                }
                else
                {
                    dir2 = -3;
                }
                StartCoroutine(StartRotate5(dir2));
                break;
            case 6:
                transform.localScale = new Vector3(1.3f, 1.3f, 1);
                Speed = 0;
                break;
        }
    }

    IEnumerator delay()
    {
        Speed = 0;
        GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(3);
        Speed = 13;
        GetComponent<CapsuleCollider2D>().enabled = true;
        gameObject.transform.SetParent(null);
    }
    IEnumerator Rotate4(float dir)
    {
        while (gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Rotate(0, 0, dir);
        }
    }
    IEnumerator StartRotate5(float dir2)
    {
        float time = 0;
        while (time < 5)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Rotate(0, 0, dir2);
            time += 0.2f;
        }
         time = 0;
        float x;
        while (gameObject.activeInHierarchy)
        {
            x = dir2;

            while (time < 10)
            {
                yield return new WaitForSeconds(0.01f);
                transform.Rotate(0, 0, -x);
                x += 0.01f;
                time += 0.2f;
            }
            time = 0;
            x = dir2;
            while (time < 10)
            {

                yield return new WaitForSeconds(0.01f);
                time += 0.2f;
                transform.Rotate(0, 0, x);
                x += 0.01f;
            }
            time = 0;
        }
    }
}

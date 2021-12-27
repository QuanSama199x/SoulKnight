using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1Boss1 : MonoBehaviour
{

    private float dir;



    void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100);
        transform.Translate(Vector3.right * 5f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Wall" || other.tag == "Blocker")
        {
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        if(Random.Range(0,2)==0)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        while (gameObject.activeInHierarchy)
        {
                yield return new WaitForSeconds(0.01f);
                transform.Rotate(0, 0, dir);     
        }
    }
}

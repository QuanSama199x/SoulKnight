using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Boss1 : MonoBehaviour
{
    public float dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        
        if (Random.Range(0, 2) == 0)
        {
            dir = 3;
        }
        else
        {
            dir = -3;
        }
        StartCoroutine(StartRotate());

    }

    IEnumerator StartRotate()
    {
        float time = 0;
        while (time < 5)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Rotate(0, 0, dir);
            time += 0.2f;
        }
        StartCoroutine(Rotate());
    }
    IEnumerator Rotate()
    {
        float time = 0;
        
        float x;
        while (gameObject.activeInHierarchy)
        {
            x = dir;

            while (time < 10)
            {
                yield return new WaitForSeconds(0.01f);
                transform.Rotate(0, 0, -x);
                x += 0.01f;
                time += 0.2f;
            }
            time = 0;
            x = dir;
            while (time < 10)
            {

                yield return new WaitForSeconds(0.01f);
                time += 0.2f;
                transform.Rotate(0, 0, x);
                x += 0.01f;
            }
            time = 0;
        }
        /*StartCoroutine(x2());*/
    }

}

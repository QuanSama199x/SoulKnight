using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy4Script : MonoBehaviour
{

    private int Speed =13;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator delay()
    {

/*        transform.localScale = new Vector3(1, 1, 1);*/
        Speed = 0;
        GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(3);
        Speed = 13;
        GetComponent<CapsuleCollider2D>().enabled = true;
        gameObject.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y+1 * 100);
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
        
        transform.localScale += new Vector3(.004f, .004f, 0);

        
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
        StartCoroutine(delay());
    }

}

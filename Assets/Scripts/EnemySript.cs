using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="BulletPlayer")
        {
            gameObject.transform.SetParent(null);
            gameObject.SetActive(false);
        }
    }
}

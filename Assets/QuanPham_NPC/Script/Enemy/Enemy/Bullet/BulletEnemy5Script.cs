using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy5Script : MonoBehaviour
{
    private GameObject Player;
    private Vector3 followPlayer;
    private int Speed =3;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer = Player.transform.position - transform.position;
        if(transform.rotation.z > Quaternion.Euler(0, 0, Mathf.Atan2(followPlayer.y, followPlayer.x) * Mathf.Rad2Deg).z)
        {
            transform.Rotate(0, 0, -0.3f);
        }
        else
        {
            transform.Rotate(0, 0, 0.3f);
        }

        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 100);
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player"|| other.tag == "Wall"|| other.tag == "Blocker")
        {
            gameObject.SetActive(false);
        }
        
        
    }
    
}

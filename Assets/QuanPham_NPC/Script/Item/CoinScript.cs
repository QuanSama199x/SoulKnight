using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private GameObject Player;
    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,Player.transform.position)<=3)
        {
            dir = Player.transform.position - transform.position;
            transform.position = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime*4);

        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player")
        {
            gameObject.SetActive(false);
        }
    }
}

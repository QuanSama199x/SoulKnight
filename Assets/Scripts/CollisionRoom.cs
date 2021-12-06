using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRoom : MonoBehaviour
{

    private static CollisionRoom instance;
    public static CollisionRoom Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<CollisionRoom>();
            return instance;
        }
    }

    public GameObject WallC1, WallC2, WallC3, WallC4;
    // Start is called before the first frame update
    void Start()
    { 
        WallC1.SetActive(false);
        WallC2.SetActive(false);
        WallC3.SetActive(false);
        WallC4.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if(transform.childCount==0)
        {
            WallC1.SetActive(false);
            WallC2.SetActive(false);
            WallC3.SetActive(false);
            WallC4.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"&& transform.childCount>0)
        {
            WallC1.SetActive(true);
            WallC2.SetActive(true);
            WallC3.SetActive(true);
            WallC4.SetActive(true);
        }
    }
}

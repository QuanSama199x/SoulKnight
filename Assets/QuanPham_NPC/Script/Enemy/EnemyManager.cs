using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager instance;
    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<EnemyManager>();
            return instance;
        }
    }
    public GameObject TargetEnemy;
    private GameObject Player;
    public int j = 0;

    public List<GameObject> ListEnemy;
    // Start is called before the first frame update
    void Start()
    {
        TargetEnemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Player!= null)
        {
            j= findenemymin(Player,j);
            if (EnemyManager.Instance.ListEnemy.Count > 0)
            {
                TargetEnemy.SetActive(true);
                TargetEnemy.transform.position = ListEnemy[j].transform.position;
                TargetEnemy.GetComponent<SpriteRenderer>().sortingOrder = -(int)(TargetEnemy.transform.position.y * 100 + 1);

            }
            else
            {
                TargetEnemy.SetActive(false);
            }
        }
        else
        {
            Player = GameObject.Find("Player");
        }
        
        
    }

    public int  findenemymin(GameObject g, int min)
    {
        
        

        for (int i = 0; i <ListEnemy.Count; i++)
        {

            if (ListEnemy.Count > 1)
            {
                if (!ListEnemy[min].activeInHierarchy)
                {
                    if (ListEnemy[i].activeInHierarchy)
                    {
                        min = i;
                    }
                    else
                    {
                        min = 0;
                    }

                }


                if (Vector3.Distance(g.transform.position, ListEnemy[min].transform.position) >
                    Vector3.Distance(g.transform.position, ListEnemy[i].transform.position) &&
                    ListEnemy[i].activeInHierarchy)

                {
                    min = i;
                }
                /*else if(SpawnEnemyLevel1.Instance.ListEnemy[i].activeInHierarchy)
                {
                    j = i;
                }*/

            }
            else if (ListEnemy[i].activeInHierarchy)
            {
                min = i;
            }



        }

        return min;
    }
    
}

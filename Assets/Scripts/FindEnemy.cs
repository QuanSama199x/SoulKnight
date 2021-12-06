using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemy : MonoBehaviour
{
    private static FindEnemy instance;
    public static FindEnemy Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<FindEnemy>();
            return instance;
        }
    }

    public RaycastHit2D[] ListEnemy;

    public GameObject TargetEnemy;

    public int j = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*ListEnemy = Physics2D.CircleCastAll(PlayerScript.Instance.transform.position,2,Vector2.zero,18,1);
        Debug.LogError(ListEnemy[0].collider.name);*/
        if(EnemyManager.Instance.ListEnemy.Count>0)
        {
            TargetEnemy.transform.position = new Vector3(EnemyManager.Instance.ListEnemy[j].transform.position.x, EnemyManager.Instance.ListEnemy[j].transform.position.y, EnemyManager.Instance.ListEnemy[j].transform.position.z);

        }
        TargetEnemy.GetComponent<SpriteRenderer>().sortingOrder = -(int)(TargetEnemy.transform.position.y * 100+1);
    }

    public void Findenemymin()
    {

        for (int i = 0; i < EnemyManager.Instance.ListEnemy.Count; i++)
        {

            if (EnemyManager.Instance.ListEnemy.Count > 1)
            {
                if (!EnemyManager.Instance.ListEnemy[j].activeInHierarchy)
                {
                    if (EnemyManager.Instance.ListEnemy[i].activeInHierarchy)
                    {
                        j = i;
                    }
                    else
                    {
                        j = 0;
                    }

                }


                if (Vector3.Distance(transform.position, EnemyManager.Instance.ListEnemy[j].transform.position) >
                    Vector3.Distance(transform.position, EnemyManager.Instance.ListEnemy[i].transform.position) &&
                    EnemyManager.Instance.ListEnemy[i].activeInHierarchy)

                {
                    j = i;
                }
                /*else if(SpawnEnemyLevel1.Instance.ListEnemy[i].activeInHierarchy)
                {
                    j = i;
                }*/

            }
            else if (EnemyManager.Instance.ListEnemy[i].activeInHierarchy)
            {
                j = i;
            }



        }


    }
}

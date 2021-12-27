using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private static CameraScript instance;
    public static CameraScript Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<CameraScript>();
            return instance;
        }
    }
    public float CameraSpeed =0.001f;


    private GameObject Player;
    private GameObject EnemyNearest;
    public Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -100);
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyManager.Instance.ListEnemy.Count>0)
        {
            EnemyNearest = EnemyManager.Instance.ListEnemy[EnemyManager.Instance.j];
        }
        else
        {
            EnemyNearest = null;
        }

        // DirCamera, check touch, Enemy Nearest
        if (Player != null)
        {
            PositionCamera(TestController.Instance.Swipe, TestController.Instance.tap, EnemyNearest);
        }
        else
        {
            Player = GameObject.Find("Player");
        }

    }

    public void PositionCamera( Vector2 dirController,bool tap, GameObject EnemyNearest)
    {
        if (Mathf.Abs(dirController.x) > Mathf.Abs(dirController.y))
        {
            if (dirController.x > 0)
            {
                dir = new Vector2(Player.transform.position.x + 1, Player.transform.position.y) ;
            }
            else
            {
                dir = new Vector2(Player.transform.position.x - 1, Player.transform.position.y) ;
            }
        }
        else
        {
            if (dirController.y > 0)
            {
                dir = new Vector2(Player.transform.position.x, Player.transform.position.y+2);
            }
            else
            {
                dir = new Vector2(Player.transform.position.x, Player.transform.position.y-2) ;
            }
        }

        
        CameraPosition(tap, EnemyNearest);
    }

    public void CameraPosition(bool tap, GameObject EnemyNearest)
    {
        /*dir = Player.transform.position;*/
        if (EnemyNearest != null)
        {


            if (Vector3.Distance(Player.transform.position, EnemyNearest.transform.position) < 3 && tap == true && EnemyNearest.activeInHierarchy)
            {
                dir = new Vector2(EnemyNearest.transform.position.x, EnemyNearest.transform.position.y) ;
                Camera.main.transform.SetParent(null);

            }
            else
            {
                Camera.main.transform.SetParent(Player.gameObject.transform);
            }
            
        }
        else
        {
            Camera.main.transform.SetParent(Player.gameObject.transform);
        }
        if (!tap)
        {
            dir = Player.transform.position ;
        }

        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(dir.x, dir.y, -100),  CameraSpeed);
            /*Camera.main.transform.position += new Vector3(dir.x * CameraSpeed * .1f, dir.y * CameraSpeed * .1f, 0);*/

    }
}

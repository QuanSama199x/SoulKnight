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


    public GameObject Player;
    public Vector2 dir;
    public Vector2 Camera2D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*dir = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z-20) - Camera.main.transform.position;
        Camera.main.transform.position += new Vector3(dir.normalized.x,0,dir.normalized.z);*/
        
    }

    public void PositionCamera(Vector2 dirController,bool tap)
    {
        if (Mathf.Abs(dirController.x) > Mathf.Abs(dirController.y))
        {
            if (dirController.x > 0)
            {
                dir = new Vector2(Player.transform.position.x + 1, Player.transform.position.y) - new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
            }
            else
            {
                dir = new Vector2(Player.transform.position.x - 1, Player.transform.position.y) - new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
            }
        }
        else
        {
            if (dirController.y > 0)
            {
                dir = new Vector2(Player.transform.position.x, Player.transform.position.y+2) - new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
            }
            else
            {
                dir = new Vector2(Player.transform.position.x, Player.transform.position.y-2) - new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
            }
        }

        FindEnemy.Instance.Findenemymin();
        CameraPosition(tap);
    }

    public void CameraPosition(bool tap)
    {
        
            if (Vector3.Distance(Player.transform.position, EnemyManager.Instance.ListEnemy[FindEnemy.Instance.j].transform.position) < 3 && tap == true&& EnemyManager.Instance.ListEnemy[FindEnemy.Instance.j].activeInHierarchy)
            {
                Camera.main.transform.SetParent(EnemyManager.Instance.ListEnemy[FindEnemy.Instance.j].transform);
                dir = new Vector2(EnemyManager.Instance.ListEnemy[FindEnemy.Instance.j].transform.position.x, EnemyManager.Instance.ListEnemy[FindEnemy.Instance.j].transform.position.y) - new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);

            }
            else
            {

                if (!tap)
                {
                    dir = Player.transform.position - new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
                }
                Camera.main.transform.SetParent(Player.gameObject.transform);


            }
            Camera.main.transform.position += new Vector3(dir.x * CameraSpeed * .1f, dir.y * CameraSpeed * .1f, 0);
        
        


    }
}

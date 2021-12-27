using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnemyScript : MonoBehaviour
{
    private static RoomEnemyScript instance;
    public static RoomEnemyScript Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<RoomEnemyScript>();
            return instance;
        }
    }


    public int IDRoom;

    public List<GameObject> EnemyRound1;
    public GameObject Floor;

    public Room Room;



    
    // Start is called before the first frame update
    void Start()
    {
        
        /*for (int i=0;i<4;i++)
        {
            GameObject obj = ObjectPool.Instance.Enemy.GetPooledObject(Resources.Load<GameObject>("Enemy"));
            obj.transform.position = new Vector3(transform.position.x + Random.Range(-5, 6), transform.position.y + Random.Range(-2, 3));
            obj.SetActive(true);
            obj.transform.SetParent(Floor.transform);
            EnemyManager.Instance.ListEnemy.Add(obj);
            EnemyRound1.Add(obj);
        }  */  
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnEnable()
    {
        Room.start("RoomEnemy1",transform.position,Floor);
    }
}

[System.Serializable]
public class Room
{
    public string IDEnemy;
    public int level;
    public int t;
    public void start(string KeyRoom, Vector3 transformRoom, GameObject floor)
    {
        switch(KeyRoom)
        {
            case "RoomEnemy1":
                startRoomEnemy1( transformRoom,  floor);
                break;
        }
    }

    void startRoomEnemy1(Vector3 transformRoom,GameObject floor)
    {
        for (int i = 1; i < 6; i++)
        {

            if (Random.Range(0, 20) == 0)
            {
                t = 1;
            }

            //            x/xx/xx/x  -->quai manh / kieu tan cong / kieu di chuyen /  kieu chi so
            IFEnemy.IDEnemy = t.ToString() + "0" + i.ToString() + "0" + i.ToString() + (Random.Range(0, 5)).ToString();
            level = 1;
            GameObject obj = ObjectPool.Instance.Enemy.GetPooledObject(Resources.Load<GameObject>("Enemy/Enemy"));
            obj.transform.position = new Vector3(transformRoom.x + Random.Range(-40, 40) / 10f, transformRoom.y + Random.Range(-30, 30) / 10f, 0);
            obj.SetActive(true);
            obj.transform.SetParent(floor.transform);
            EnemyManager.Instance.ListEnemy.Add(obj);
            
            t = 0;
        }
        for(int i=0;i<6;i++)
        {
            GameObject obj = ObjectPool.Instance.Blocker.GetPooledObject(Resources.Load<GameObject>("Blocker/Blocker"));
            obj.transform.position = new Vector3(transformRoom.x - 2 + i*0.6f, transformRoom.y, transformRoom.z);
            obj.SetActive(true);
        }
        for (int i = 0; i < 6; i++)
        {
            GameObject obj = ObjectPool.Instance.Coin.GetPooledObject(Resources.Load<GameObject>("Coin"));
            obj.transform.position = new Vector3(transformRoom.x - 2 + i * 0.6f, transformRoom.y-2, transformRoom.z);
            obj.SetActive(true);
        }
        for (int i = 0; i < 6; i++)
        {
            GameObject obj = ObjectPool.Instance.Mana.GetPooledObject(Resources.Load<GameObject>("Mana"));
            obj.transform.position = new Vector3(transformRoom.x - 2 + i * 0.6f, transformRoom.y - 3, transformRoom.z);
            obj.SetActive(true);
        }

        for (int i = 0; i < 3; i++)
        {
            GameObject obj = ObjectPool.Instance.BottleHealth.GetPooledObject(Resources.Load<GameObject>("BottleHealth"));
            obj.transform.position = new Vector3(transformRoom.x - 2 + i * 0.6f, transformRoom.y - 4, transformRoom.z);
            obj.SetActive(true);
        }

        for (int i = 0; i < 3; i++)
        {
            GameObject obj = ObjectPool.Instance.BottleMana.GetPooledObject(Resources.Load<GameObject>("BottleMana"));
            obj.transform.position = new Vector3(transformRoom.x - 2 + i * 0.6f, transformRoom.y - 5, transformRoom.z);
            obj.SetActive(true);
        }
    }
   
}

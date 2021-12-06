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
        for (int i = 0; i < 4; i++)
        {
            GameObject obj = ObjectPool.Instance.Enemy.GetPooledObject(Resources.Load<GameObject>("Enemy"));
            obj.transform.position = new Vector3(transformRoom.x + Random.Range(-5, 6), transformRoom.y + Random.Range(-2, 3));
            obj.SetActive(true);
            obj.transform.SetParent(floor.transform);
            EnemyManager.Instance.ListEnemy.Add(obj);
         
        }
    }

}

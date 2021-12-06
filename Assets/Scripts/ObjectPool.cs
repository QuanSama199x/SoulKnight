using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance;
    public static ObjectPool Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<ObjectPool>();
            return instance;
        }
    }

    public string ROOM_ENEMY = "RoomEnemy";
    public string BULLET_PISTAL = "BulletPistal";
    public string ENEMY = "Enemy";


    public PoolElement Room;
    public PoolElement BulletPistal;
    public PoolElement Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Room.start(Resources.Load<GameObject>(ROOM_ENEMY));
        BulletPistal.start(Resources.Load<GameObject>(BULLET_PISTAL));
        Enemy.start(Resources.Load<GameObject>(ENEMY));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class PoolElement
{
    public List<GameObject> PooledObjects;
    public int amountToPool;
    public void start(GameObject x)
    {
        for(int i=0;i<amountToPool; i++)
        {
            GameObject obj = GameObject.Instantiate(x);
            obj.SetActive(false);
            PooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject(GameObject x)
    {

        for (int i = 0; i < PooledObjects.Count; i++)
        {
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];

            }
        }
        GameObject obj =  GameObject.Instantiate(x);
        obj.SetActive(false);
        PooledObjects.Add(obj);
        return obj;
    }
}

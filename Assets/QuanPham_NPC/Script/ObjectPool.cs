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

    public string ENEMY = "Enemy/Enemy";

    public string WEAPON = "Weapon/Weapon";


    public string BOSS1 = "Enemy/Boss1";
    public string BOSS2 = "Enemy/Boss1";

    public string BULLET_ENEMY = "Enemy/BulletEnemy/BulletEnemy";
    public string BULLET_ENEMY4 = "Enemy/BulletEnemy/BulletEnemy4";
    public string BULLET_ENEMY5 = "Enemy/BulletEnemy/BulletEnemy5";

    public string BULLET1_BOSS1 = "Enemy/BulletEnemy/Bullet1Boss1";
    public string BULLET2_BOSS1 = "Enemy/BulletEnemy/Bullet2Boss1";

    public string ROOM_ENEMY = "RoomEnemy";
    public string ROOM_START = "RoomStart";
    public string ROOM_ITEM = "RoomItem";
    public string BULLET_PISTAL = "BulletPistal";
    public string COIN = "Coin";
    public string MANA = "Mana";

    public string BOTTLE_HEALTH = "BottleHealth";
    public string BOTTLE_MANA = "BottleMana";

    public string BLOCKER = "Blocker/Blocker";

    public PoolElement Enemy;

    public PoolElement Weapon;

    public PoolElement Boss1,Boss2;
    public PoolElement BulletEnemy,BulletEnemy4,BulletEnemy5;
    public PoolElement Bullet1Boss1,Bullet2Boss1;

    public PoolElement RoomEnemy, RoomStart, RoomItem;
    public PoolElement BulletPistal;
    public PoolElement Blocker;
    public PoolElement Coin;
    public PoolElement Mana;

    public PoolElement BottleHealth;
    public PoolElement BottleMana;

    void Start()
    {
        Enemy.start(Resources.Load<GameObject>(ENEMY));
 
        Boss1.start(Resources.Load<GameObject>(BOSS1));
        Boss2.start(Resources.Load<GameObject>(BOSS2));

        BulletEnemy.start(Resources.Load<GameObject>(BULLET_ENEMY));
        BulletEnemy4.start(Resources.Load<GameObject>(BULLET_ENEMY4));
        BulletEnemy5.start(Resources.Load<GameObject>(BULLET_ENEMY5));

        Bullet1Boss1.start(Resources.Load<GameObject>(BULLET1_BOSS1));
        Bullet2Boss1.start(Resources.Load<GameObject>(BULLET2_BOSS1));

        Weapon.start(Resources.Load<GameObject>(WEAPON));

        RoomEnemy.start(Resources.Load<GameObject>(ROOM_ENEMY));
        RoomStart.start(Resources.Load<GameObject>(ROOM_START));
        RoomItem.start(Resources.Load<GameObject>(ROOM_ITEM));
        BulletPistal.start(Resources.Load<GameObject>(BULLET_PISTAL));
        Blocker.start(Resources.Load<GameObject>(BLOCKER));
        Coin.start(Resources.Load<GameObject>(COIN));
        Mana.start(Resources.Load<GameObject>(MANA));

        BottleHealth.start(Resources.Load<GameObject>(BOTTLE_HEALTH));
        BottleMana.start(Resources.Load<GameObject>(BOTTLE_MANA));
    }

    void Update()
    {
        
    }
}

[System.Serializable]
public class PoolElement
{
    public List<GameObject> PooledObjects;
    public int amountToPool;

    public void start(GameObject ObjectToPool)
    {
        for(int i=0;i<amountToPool;i++)
        {
            GameObject obj = GameObject.Instantiate(ObjectToPool) ;
            obj.SetActive(false);
            PooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject(GameObject ObjectToPool)
    {
        for(int i=0;i<PooledObjects.Count;i++)
        {
            if(!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }
        GameObject obj = GameObject.Instantiate(ObjectToPool);
        obj.SetActive(false);
        PooledObjects.Add(obj);
        return obj;
    }


}

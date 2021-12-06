using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public bool[,] Boo = new bool[7, 7];
        
    public int a = 3, b = 3;
    public int RangeHorizontal = 10, RangeVertical=20;

    public Vector3 PointSpawnRoom = new Vector3(60, 36, 0);
    public List<GameObject> RoomInGame;
    // Start is called before the first frame update
    void Start()
    {
        Boo[a, b] =true;

        GameObject obj = ObjectPool.Instance.Room.GetPooledObject(Resources.Load<GameObject>("RoomEnemy"));
        obj.transform.position = PointSpawnRoom;
        obj.SetActive(true);
        RoomInGame.Add(obj);
        obj.transform.position = PointSpawnRoom;
        for (int i = 0; i < 6; i++)
        {

                switch (Random.Range(0, 5))
                {
                    case 0:
                        if (!Boo[a+1,b]&& a+1<6)
                        {
                            a++;
                            Boo[a, b] = true;
                            CreateRoom(new Vector3(RangeVertical, 0, 0),"RoomEnemy","n");
                            
                        }
                        else
                        {
                            i--;
                        }
                        break;
                    case 1:
                        if (!Boo[a,b+1] &&b+1<6)
                        {
                            b++;
                            Boo[a, b] = true;
                            CreateRoom(new Vector3(0, RangeHorizontal, 0), "RoomEnemy", "d");                        
                    }
                        else
                        {
                            i--;
                        }
                    break;
                    case 2:
                        if (!Boo[a-1,b] &&a-1>0)
                        {
                            a--;
                            Boo[a, b] = true;
                            CreateRoom(new Vector3(-RangeVertical,0, 0), "RoomEnemy", "n");
                        
                    }
                        else
                        {
                            i--;
                        }
                    break;
                    case 3:
                        if (!Boo[a,b-1] &&b-1>0)
                        {
                            b--;
                            Boo[a, b] = true;
                            CreateRoom(new Vector3(0, -RangeHorizontal, 0), "RoomEnemy", "d");
                        
                    }
                        else
                        {
                            i--;
                        }
                    break;
                    case 4:
                        if(RoomInGame.Count>=3)
                        {
                        Debug.LogError("vjp");
                            PointSpawnRoom = RoomInGame[RoomInGame.Count - 2].transform.position;
                        RoomInGame.Add(RoomInGame[RoomInGame.Count - 2]);
                        RoomInGame.Remove(RoomInGame[RoomInGame.Count - 3]);
                        a = (int)PointSpawnRoom.x / RangeVertical;
                        b = (int)PointSpawnRoom.y / RangeHorizontal;
                        }
                         i--;
                    break;
            }
        }
    }
    void Update()
    {
        
    }
    public void CreateRoom(Vector3 x, string RoomName, string CorridorName)
    {

            PointSpawnRoom += x;
            GameObject obj1 = ObjectPool.Instance.Room.GetPooledObject(Resources.Load<GameObject>(RoomName));
            obj1.transform.position = PointSpawnRoom;
            obj1.SetActive(true);
            RoomInGame.Add(obj1);
        Corridor(CorridorName, (RoomInGame[RoomInGame.Count - 1].transform.position + RoomInGame[RoomInGame.Count - 2].transform.position) / 2);

    }
    public void Corridor(string x, Vector3 transform)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>(x));
        obj.transform.position = transform;
    }
}

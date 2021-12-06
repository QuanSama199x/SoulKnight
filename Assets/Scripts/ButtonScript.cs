using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shooting()
    {
        GameObject obj = ObjectPool.Instance.Room.GetPooledObject(Resources.Load<GameObject>("BulletPistal"));
        obj.transform.position = PlayerScript.Instance.Weapon.transform.position;
        obj.transform.rotation = PlayerScript.Instance.Weapon.transform.rotation;
        obj.SetActive(true);
        ObjectPool.Instance.BulletPistal.PooledObjects.Remove(obj);
    }
 

}

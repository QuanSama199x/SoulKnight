using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponinRoom : MonoBehaviour
{
    private static WeaponinRoom instance;
    public static WeaponinRoom Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<WeaponinRoom>();
            return instance;
        }
    }

    public DataWeapon Weapon;
    public int IDWeapon,ID;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        IDWeapon = Insta.Instance.ID ;
        GetComponent<SpriteRenderer>().sprite = Weapon.Weapon[IDWeapon].SpriteWeapon;
    }
}

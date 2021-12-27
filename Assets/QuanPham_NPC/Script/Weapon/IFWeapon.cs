using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IFWeapon : WeaponInformation
{
    private static IFWeapon instance;
    public static IFWeapon Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<IFWeapon>();
            return instance;
        }
    }
    public int IDWeaponinRoom;
    // Start is called before the first frame update
    void Start()
    {
        IDWeapon = Weapon.Weapon[0].IDWeapon;
        NameWeapon = Weapon.Weapon[IDWeapon].Name;
        ManaCost = Weapon.Weapon[IDWeapon].ManaCost;
        ATk = Weapon.Weapon[IDWeapon].ATK;
        SpeedATK = Weapon.Weapon[IDWeapon].SpeedATK;
        iconWeapon.GetComponent<Image>().sprite = Weapon.Weapon[IDWeapon].SpriteWeapon;
        IDWeapon2 = -1;
        /*Weapon2.GetComponent<Image>().sprite = Weapon.Weapon[1].SpriteWeapon;*/
    }

    // Update is called once per frame
    void Update()
    {
        

            switch (IDWeapon)
            {
                case 0:
                    DirectionWeaponFollowEnemy();
                    break;
                case 1:
                    DirectionWeaponFollowEnemy();
                    break;
                case 2:
                    DirectionWeapon();
                    break;
                case 3:
                    DirectionWeaponFollowEnemy();
                    SpawnBullet2();
                

                    break;



        }
        
        
    }

    public void Attack()
    {
        if (isAttack)
        {
            return;
        }
        if (PlayerScript.Instance.Mana < ManaCost)
        {
            return;

        }
        PlayerScript.Instance.Mana -= ManaCost;
        EventScript.Instance.ShowMana.Invoke();
        switch (IDWeapon)
        {
            case 0:
                StartCoroutine(AttackWeapon1());
                break;
            case 1:
                StartCoroutine(AttackWeapon2());
                break;
            case 2:
                StartCoroutine(AttackWeapon3());
                break;
            case 3:
                StartCoroutine(AttackWeapon4());
                
                break;

        }
    }

    public void SwipeWeapon()
    {
        if (IDWeapon2 == -1)
        {
            return;
        }
        int id = IDWeapon;
        IDWeapon = IDWeapon2;
        IDWeapon2 = id;

        NameWeapon = Weapon.Weapon[IDWeapon].Name;
        GetComponent<SpriteRenderer>().sprite = Weapon.Weapon[IDWeapon].SpriteWeapon;
        if(IDWeapon==3)
        {
            GetComponent<SpriteRenderer>().sprite = null;
        }
        if (id == 3)
        {
            while(pointShoot2.transform.childCount>0)
            {
                pointShoot2.transform.GetChild(0).gameObject.SetActive(false);
                pointShoot2.transform.GetChild(0).transform.SetParent(null);


            }
            countBullet = 0;
        }
        ManaCost = Weapon.Weapon[IDWeapon].ManaCost;
        ATk = Weapon.Weapon[IDWeapon].ATK;
        SpeedATK = Weapon.Weapon[IDWeapon].SpeedATK;

        iconWeapon.GetComponent<Image>().sprite = Weapon.Weapon[IDWeapon].SpriteWeapon;
        EventScript.Instance.ShowManaWeapon.Invoke();
    }
    public void GetWeapon()
    {
        if (IDWeapon2 == -1)
        {
            IDWeapon2 = IDWeaponinRoom;
            Physics2D.CircleCast(FindWeapon.Instance.gameObject.transform.position, 1, Vector2.zero, 0 << 3, FindWeapon.Instance.MaskWeapon).collider.gameObject.SetActive(false);
            return;
        }

        int id = IDWeapon;

        IDWeapon = IDWeaponinRoom;
        Physics2D.CircleCast(FindWeapon.Instance.gameObject.transform.position, 1, Vector2.zero, 0 << 3, FindWeapon.Instance.MaskWeapon).collider.gameObject.GetComponent<WeaponinRoom>().IDWeapon = id;



        NameWeapon = Weapon.Weapon[IDWeapon].Name;
        GetComponent<SpriteRenderer>().sprite = Weapon.Weapon[IDWeapon].SpriteWeapon;
        if (IDWeapon == 3)
        {
            GetComponent<SpriteRenderer>().sprite = null;
        }
        if (id == 3)
        {
            while (pointShoot2.transform.childCount > 0)
            {
                pointShoot2.transform.GetChild(0).gameObject.SetActive(false);
                pointShoot2.transform.GetChild(0).transform.SetParent(null);
                

            }
            countBullet = 0;
        }
        ManaCost = Weapon.Weapon[IDWeapon].ManaCost;
        ATk = Weapon.Weapon[IDWeapon].ATK;
        SpeedATK =Weapon.Weapon[IDWeapon].SpeedATK;
        iconWeapon.GetComponent<Image>().sprite = Weapon.Weapon[IDWeapon].SpriteWeapon;

        Physics2D.CircleCast(FindWeapon.Instance.gameObject.transform.position, 1, Vector2.zero, 0 << 3, FindWeapon.Instance.MaskWeapon).collider.gameObject.GetComponent<SpriteRenderer>().sprite = Weapon.Weapon[id].SpriteWeapon;
        Physics2D.CircleCast(FindWeapon.Instance.gameObject.transform.position, 1, Vector2.zero, 0 << 3, FindWeapon.Instance.MaskWeapon).collider.gameObject.transform.position = transform.position;
        EventScript.Instance.ShowManaWeapon.Invoke();
    }
}

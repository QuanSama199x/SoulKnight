using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public static int IDWeaponinRoom;
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
        IFWeapon.Instance.Attack();
    }
    public void SwipeWeapon()
    {
        IFWeapon.Instance.SwipeWeapon();    
    }

    public void GetWeapon()
    {
        if (Physics2D.CircleCast(PlayerScript.Instance.transform.position, 1, Vector2.zero, 0 << 3, FindWeapon.Instance.MaskWeapon).collider.name == "BottleHealth(Clone)")
        {
            PlayerScript.Instance.Health += 3;
            if(PlayerScript.Instance.Health>PlayerScript.Instance.MaxHealth)
            {
                PlayerScript.Instance.Health = PlayerScript.Instance.MaxHealth;
            }
            EventScript.Instance.SHowHealth.Invoke();
            Physics2D.CircleCast(PlayerScript.Instance.transform.position, 1, Vector2.zero, 0 << 3, FindWeapon.Instance.MaskWeapon).collider.gameObject.SetActive(false);
            return;
        }
        if (Physics2D.CircleCast(PlayerScript.Instance.transform.position, 1, Vector2.zero, 0 << 3, FindWeapon.Instance.MaskWeapon).collider.name == "BottleMana(Clone)")
        {
            PlayerScript.Instance.Mana += 40;
            if (PlayerScript.Instance.Mana > PlayerScript.Instance.MaxMana)
            {
                PlayerScript.Instance.Mana = PlayerScript.Instance.MaxMana;
            }
            EventScript.Instance.ShowMana.Invoke();
            Physics2D.CircleCast(PlayerScript.Instance.transform.position, 1, Vector2.zero, 0 << 3, FindWeapon.Instance.MaskWeapon).collider.gameObject.SetActive(false);
            return;
        }
        IFWeapon.Instance.GetWeapon();
    }


 

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindWeapon : MonoBehaviour
{
    private static FindWeapon instance;
    public static FindWeapon Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<FindWeapon>();
            return instance;
        }
    }

    public GameObject ButtonGetWeapon;
    public LayerMask MaskWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Find();
        
    }

    public void Find()
    {
        if (Physics2D.CircleCast(transform.position, 1, Vector2.zero, 0 << 3, MaskWeapon))
        {
            if (Physics2D.CircleCast(transform.position, 1, Vector2.zero, 0 << 3, MaskWeapon).collider.name == "BottleHealth(Clone)")
            {
                ButtonGetWeapon.SetActive(true);
                return;
            }
            if (Physics2D.CircleCast(transform.position, 1, Vector2.zero, 0 << 3, MaskWeapon).collider.name == "BottleMana(Clone)")
            {
                ButtonGetWeapon.SetActive(true);
                return;
            }
            if (Physics2D.CircleCast(transform.position, 1, Vector2.zero, 0 << 3, MaskWeapon).collider.tag == "WeaponinRoom")
            {
                Debug.LogError(Physics2D.CircleCast(transform.position, 1, Vector2.zero, 0 << 1, MaskWeapon).collider.tag);
                IFWeapon.Instance.IDWeaponinRoom = Physics2D.CircleCast(transform.position, 1, Vector2.zero, 0 << 1, MaskWeapon).collider.gameObject.GetComponent<WeaponinRoom>().IDWeapon;
                ButtonGetWeapon.SetActive(true);
                return;
            }

            
        }

        ButtonGetWeapon.SetActive(false);
    }
}

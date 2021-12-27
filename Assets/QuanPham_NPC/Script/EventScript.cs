using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventScript : MonoBehaviour
{
    private static EventScript instance;
    public static EventScript Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<EventScript>();
            return instance;
        }
    }
    public UnityEvent GetCoin;
    public UnityEvent ShowManaWeapon;
    public UnityEvent SHowHealth;
    public UnityEvent ShowShield;
    public UnityEvent ShowMana;
    public UnityEvent GetMana;

    private void Awake()
    {
        GetCoin = new UnityEvent();
        ShowManaWeapon = new UnityEvent();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

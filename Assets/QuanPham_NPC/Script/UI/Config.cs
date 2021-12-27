using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    private static Config instance;
    public static Config Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Config>();
            return instance;
        }
    }
    public int Coin;
    
    // Start is called before the first frame update
    void Start()
    {
        EventScript.Instance.GetCoin.AddListener(AddCoin);
        EventScript.Instance.GetMana.AddListener(AddMana);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin()
    {
        Coin++;
    }
    public void AddMana()
    {
        PlayerScript.Instance.Mana += 5;
        if (PlayerScript.Instance.Mana > PlayerScript.Instance.MaxMana)
        {
            PlayerScript.Instance.Mana = PlayerScript.Instance.MaxMana;
        }
        EventScript.Instance.ShowMana.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text TextCoin;
    public Text TextManaWeapon;

    public Text TextHealth;
    public Text TextShield;
    public Text TextMana;

    public Image ImageHealth;
    public Image ImageShield;
    public Image ImageMana;
    // Start is called before the first frame update
    void Start()
    {
        EventScript.Instance.GetCoin.AddListener(ShowCoin);
        EventScript.Instance.ShowManaWeapon.AddListener(ShowManaWeapon);

        EventScript.Instance.SHowHealth.AddListener(ShowHealth);
        EventScript.Instance.ShowShield.AddListener(SHowShield);
        EventScript.Instance.ShowMana.AddListener(ShowMana);

        EventScript.Instance.SHowHealth.Invoke();
        EventScript.Instance.ShowShield.Invoke();
        EventScript.Instance.ShowMana.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCoin()
    {
        TextCoin.text = Config.Instance.Coin.ToString();
    }
    public void ShowManaWeapon()
    {
        TextManaWeapon.text = IFWeapon.Instance.ManaCost.ToString();
    }

    public void ShowHealth()
    {
        TextHealth.text = PlayerScript.Instance.Health.ToString() + "/" + PlayerScript.Instance.MaxHealth.ToString();
        ImageHealth.fillAmount = (float)PlayerScript.Instance.Health / PlayerScript.Instance.MaxHealth;
    }
    public void SHowShield()
    {
        TextShield.text = PlayerScript.Instance.Shield.ToString() + "/" + PlayerScript.Instance.MaxShield.ToString();
        ImageShield.fillAmount = (float)PlayerScript.Instance.Shield / PlayerScript.Instance.MaxShield;
    }
    public void ShowMana()
    {
        TextMana.text = PlayerScript.Instance.Mana.ToString() + "/" + PlayerScript.Instance.MaxMana.ToString();
        ImageMana.fillAmount = (float)PlayerScript.Instance.Mana / PlayerScript.Instance.MaxMana;
    }
}

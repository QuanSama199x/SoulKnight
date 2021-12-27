using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName ="DataWeapon")]
public class DataWeapon : ScriptableObject
{
    public List<Weapon> Weapon;

}
[System.Serializable]
public class Weapon
{
    public int IDWeapon;
    public string Name;
    public Sprite SpriteWeapon;
    public Image ImageWeapon;
    public int ManaCost;
    public int ATK;
    public float SpeedATK;


}

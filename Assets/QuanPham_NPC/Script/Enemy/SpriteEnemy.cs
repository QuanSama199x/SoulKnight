using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "SpriteEnemy")]
public class SpriteEnemy : ScriptableObject
{
    public List<Sprite> Enemy;
    public List<Sprite> Weapon;
    public List<Index> Index;

}
[System.Serializable]
public class Index
{
    public int MaxHealth;
    public int SpeedMoving;
    public int ATK;
}

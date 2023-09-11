using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Item")]
public class ItemData : ScriptableObject
{
  public string objectName;
  public Mesh mesh;
  public int quantity;
  public bool stackable;  //즉시사용아이템, 인벤토리 아이템
  public enum ItemType
    {
        Points,

        HEALTH,

        Skill


    }

    public ItemType itemType;


}

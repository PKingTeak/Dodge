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

        HEALTH

   /// 아이템 타입은 포인트와 힐팩 이렇게 두개만 생각하여 2가지의 종류를 미리 만들어 놓았습니다.

    }

    public ItemType itemType;

///<summary>
///아이템 데이터 각각의 아이템들이 가져야하는 기본속성을 설정하였습니다.
///
/// </summary>

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HitPoints")]
public class HitPoints : ScriptableObject
{
    public float value;
  
    ///<summary>
    ///자주 사용하는 변수이기 땜문에 상속을 생각하고 충돌을 감지해야 되는 오브젝트에 하나씩 추가하고 각각 다른 값으로 조정을 해야하기때문에 
    ///데이터를 저장해주는 ScriptableObject를 사용하였습니다. + 메모리를 줄이기 위해서 사용하였습니다.
    /// </summary>
}

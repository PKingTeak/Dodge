using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class M_MenuUI : MonoBehaviour
{
    public GameObject stage;

 
    public void ChangeSceneBtn()
    {
        switch(this.gameObject.name)
        {
        case "Stage1" :
        SceneManager.LoadScene("Dodge_C");
        break;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMode : MonoBehaviour
{
    
     Dropdown m_Dropdown;    

    void Start()
    {
        setEasy();
        //Fetch the Dropdown GameObject
        m_Dropdown = GetComponent<Dropdown>();
        //Add listener for when the value of the Dropdown changes, to take action
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });
        void DropdownValueChanged(Dropdown change)
    {  
       
       if(change.value == 0){
           setEasy();
       }
       if(change.value == 1){
           setMedium();
       }
       if(change.value == 2){
           setHard();
       }
    }
    }
    public void setEasy(){
       PlayerPrefs.SetInt("gameMode", 1);
    }
    public void setMedium(){
       PlayerPrefs.SetInt("gameMode", 2);
    }
    public void setHard(){
       PlayerPrefs.SetInt("gameMode",3);
    }
}

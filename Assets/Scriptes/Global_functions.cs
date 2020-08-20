using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class Global_functions : MonoBehaviour
{
    public GameObject player;
    public GameObject panel;
    public GameObject top;
    public GameObject bot;
    public int score;
 public void loadLevel(){
      Global_settings.gravityScale = 0f;
      SceneManager.LoadScene(2);
      Global_settings.state = false;
      Score.score = 0;
      Global_settings.score = 0;
      Global_settings.top = 4.9f;
      Global_settings.bot = -4.9f;
      panel.SetActive(false);
      Global_settings.countOfStart++;
    }
 public void Сontinue(){
   Score.score = Global_settings.score;
    Global_settings.gravityScale = 0f;
    Global_settings.state = false;
    SceneManager.LoadScene(2);
    Score.score = PlayerPrefs.GetInt("scoreCont");
    panel.SetActive(false);
    Global_settings.countOfStart++;
   if(Global_settings.countOfRestart==0){
    Global_settings.countOfRestart++;
    }else if (Global_settings.countOfRestart == 1|| Global_settings.countOfRestart != 0){
       Global_settings.countOfRestart = 0;
    }
   }
   public void mainMenu(){
      SceneManager.LoadScene(0);
      Global_settings.score = 0;
      Score.score = 0;
      PlayerPrefs.SetInt("scoreCont", 0);
   }
public void LoadLevelAsync (){
   SceneManager.LoadScene(3);
   Global_settings.state = false;
   Global_settings.countOfStart++;
   }
}

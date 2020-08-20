using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class Upper : MonoBehaviour
{
    public Text restart;
    public AudioSource DieOne;
    public AudioSource DieTwo;
    public AudioSource DieThree;   
    public AudioSource GameOver;
    public GameObject panel;
    public Text score; 
    public Text hightscore_tx;
    // Start is called before the first frame update
    void Start(){
        if(Advertisement.isSupported){
                Advertisement.Initialize("3588489",false);
        }
    }
   private void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player"))
        {
          // SceneManager.LoadScene(0);
           panel.SetActive(true);
             if(Score.score > PlayerPrefs.GetInt("HightScore")){
        PlayerPrefs.SetInt("HightScore", Score.score);
        hightscore_tx.text = Score.score.ToString();
        }
        PlayerPrefs.SetInt("scoreCont", Score.score);
          // Global_settings.state = false;
           score.text = Global_settings.score.ToString();
             int Soundrand = Random.Range(1,4);
             if(Global_settings.state == true){
        if(Soundrand == 1){
           DieOne.Play();
        }
        if(Soundrand == 2){
            DieTwo.Play();
        }else{
            DieThree.Play();
        }
        GameOver.Play();
        if(Global_settings.countOfStart%5 == 0){
            Advertisement.Show();
           
        }
         Debug.Log (Global_settings.countOfStart.ToString());
        Global_settings.state = false;
        }
        }
    }
}

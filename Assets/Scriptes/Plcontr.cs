using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class Plcontr : MonoBehaviour
{
    public AudioSource jumpSound;
    public AudioSource DieOne;
    public AudioSource DieTwo;
    public AudioSource DieThree;   
    public GameObject panel;
    public GameObject VertSosoulka;
    public GameObject Fire;
    public GameObject  btnContinue;
    public float force = 10f;
    public Text score;
    public AudioSource GameOver;
    private new Rigidbody2D rigidbody;
    public float jump = 1.5f;
    public GameObject heart;
    public Text timer;
    public int hightscore;
    public Text hightscore_tx;
    public int Gamemode;
    public float startTime = 3f;
    public bool startEd = false;
    void Start()
    {   
           if(Advertisement.isSupported){
                Advertisement.Initialize("3588489",false);
        }
        Gamemode = PlayerPrefs.GetInt("gameMode");
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = Global_settings.gravityScale;
        timer.text = "3";
        if(Global_settings.countOfRestart == 0){
           btnContinue.GetComponent<Button>().interactable = true;
            heart.SetActive(true);
        }else{
            heart.SetActive(false);
            Global_settings.countOfRestart = 0;
            btnContinue.GetComponent<Button>().interactable = false;
        }
        hightscore = PlayerPrefs.GetInt("HightScore");
        hightscore_tx.text = hightscore.ToString();
        // StartCoroutine(startGame(3f));
         InvokeRepeating ("SpawnVertical" , 2f ,2f);
    }
    void FixedUpdate(){
       
         if (Input.touchCount > 0 && Global_settings.state == true && panel.activeSelf == false) {
             Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began){
         jumpSound.Play();
         rigidbody.AddForce(Vector2.up * (force - rigidbody.velocity.y), ForceMode2D.Impulse);
         Fire.SetActive(true);
         StartCoroutine(fireOFF(0.5f));
        }
	}
    }
    void Update(){
            startTime -= Time.deltaTime;
            timer.text = Mathf.Round(startTime).ToString();
            if (startTime < 0 && Global_settings.state == false){
                         rigidbody.gravityScale=3f;
                         timer.gameObject.SetActive(false);
                         if(startEd == false){
                         startEd = true;
                         Global_settings.state = true;
                         }else {
                             Global_settings.state = false;
                         }
            }
        }
    void OnCollisionEnter2D(Collision2D col){
       if(col.gameObject.layer == LayerMask.NameToLayer("killer")){
        if(Score.score > PlayerPrefs.GetInt("HightScore")){
        PlayerPrefs.SetInt("HightScore", Score.score);
        hightscore_tx.text = hightscore.ToString();
        }
        PlayerPrefs.SetInt("scoreCont", Score.score);
        panel.SetActive(true);
        Global_settings.state = false; 
        score.text = Global_settings.score.ToString();
        int Soundrand = Random.Range(1,4);
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
       Debug.Log(Global_settings.countOfStart.ToString());
       }
    }
    void SpawnVertical (){
        if(Global_settings.state == true){
          if(Gamemode == 1){
              EasyMode();
          }
          if (Gamemode == 2){
              MediumMode();
          }
          if(Gamemode == 3){
              HardMode();
          }
        }
    }
    IEnumerator fireOFF (float time)
    {
       yield return new WaitForSeconds (time);
       Fire.SetActive(false);
    }
    IEnumerator startGame (float time){
        timer.text = time.ToString();
        yield return new WaitForSeconds(time);
         rigidbody.gravityScale=3f;
         Global_settings.state = true; 
    }
    public void EasyMode()
    {
        float y = Random.Range(-4.5f , 4.5f);
             Vector2 vect = new Vector2(3.4f, y);
             GameObject gm = Instantiate (VertSosoulka , vect , Quaternion.identity) as GameObject;
    }
    public void MediumMode(){
        int rand = Random.Range(1,3);
        if(rand == 1){
             float y = Random.Range(-4.5f , 4.5f);
             Vector2 vect = new Vector2(3.4f, y);
             GameObject gm = Instantiate (VertSosoulka , vect , Quaternion.identity) as GameObject;
            }else{
               for(int i = 0; i<2; i++){
            float y = Random.Range(-4.5f , 4.5f);
            Vector2 vect = new Vector2(3.4f, y);
            GameObject gm = Instantiate (VertSosoulka , vect , Quaternion.identity) as GameObject;
            }
        }
    }
    public void HardMode(){
        int rand = Random.Range(1,4);
        if (rand == 1){
            float y = Random.Range(-4.5f , 4.5f);
             Vector2 vect = new Vector2(3.4f, y);
             GameObject gm = Instantiate (VertSosoulka , vect , Quaternion.identity) as GameObject;
        }
        if (rand == 2){
             for(int i = 0; i<2; i++){
            float y = Random.Range(-4.5f , 4.5f);
            Vector2 vect = new Vector2(3.4f, y);
            GameObject gm = Instantiate (VertSosoulka , vect , Quaternion.identity) as GameObject;
        }
        }
        if(rand == 3){
             for(int i = 0; i<3; i++){
            float y = Random.Range(-4.5f , 4.5f);
            Vector2 vect = new Vector2(3.4f, y);
            GameObject gm = Instantiate (VertSosoulka , vect , Quaternion.identity) as GameObject;
        }
        
    }
    }
}


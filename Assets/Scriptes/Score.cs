using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float positionTopPlateY;
    public static float positionBotPlateY;
    public Text text;
    public GameObject top;
    public GameObject bot;
    public static int score = 0;
    public float step = 0.05f;
    
    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
    }
    void OnTriggerEnter2D(Collider2D collision){
       if(Global_settings.state==true) {
       score +=1;
       }
        if(score%5 == 0){
         transFormPlates();
         positionTopPlateY = top.transform.position.y;
         positionBotPlateY = bot.transform.position.y;
        }
        Global_settings.score = score;
        Destroy(collision.gameObject);    
}
public void transFormPlates(){
            Global_settings.bot = Global_settings.bot + step;
            Global_settings.top = Global_settings.top - step;
            top.transform.position = new Vector2 (0, Global_settings.top);
            bot.transform.position = new Vector2 (0, Global_settings.bot);

}
}

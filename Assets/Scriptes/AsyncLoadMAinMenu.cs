using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncLoadMAinMenu : MonoBehaviour
{
    public GameObject sosulka;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadMainMenu());
    }

    // Update is called once per frame
    IEnumerator loadMainMenu(){
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        yield return null;
    }
}

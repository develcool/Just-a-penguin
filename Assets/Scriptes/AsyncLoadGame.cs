using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AsyncLoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AsyncLoadGameScene());
    }
IEnumerator AsyncLoadGameScene(){
    AsyncOperation operation = SceneManager.LoadSceneAsync(2);
    yield return null;
}
}

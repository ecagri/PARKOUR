using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] string SceneName;
    public void play(){
        SceneManager.LoadScene(SceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void backToMenu(){
        SceneManager.LoadScene("New Game");
    }
}

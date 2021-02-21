using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagament : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Resume, _laser;
    public AudioSource audio;
    public Transform player;

    void Start(){
        audio = GetComponent<AudioSource>();
    }
    
    public void RestartGame(){
        SceneManager.LoadScene(1);
    }


    public void StartGame(){
        Time.timeScale = 1f;
        Text1.SetActive(true);
        Text2.SetActive(true);
        Destroy(Text1, 3f);
        Destroy(Text2, 3f);
    }

    public void Level2(){
        SceneManager.LoadScene(2);
    }

    public void Level3(){
        SceneManager.LoadScene(3);
    }

    public void Level4(){
        SceneManager.LoadScene(4);
    }

    public void PressButton(){
        Time.timeScale = 1f;
    } 

    public void Level5(){
        SceneManager.LoadScene(5);
        Time.timeScale = 1f;
    }   

    public void Level6(){
        SceneManager.LoadScene(6);
        Time.timeScale = 1f;
    }

    public void Level7(){
        SceneManager.LoadScene(7);
        Time.timeScale = 1f;
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void End(){
        SceneManager.LoadScene(8);
    }
    public void Pause(){
        Resume.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Quit(){
        Application.Quit();
    }

    public void Attack(){
        Instantiate(_laser, player.position, Quaternion.identity);
    }

}

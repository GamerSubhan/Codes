using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public GameObject Music;

    public void SoundON(){
        Music.SetActive(true);

    }

    public void SoundOFF(){
        Music.SetActive(false);
    }
}

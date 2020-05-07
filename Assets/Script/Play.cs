using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//untuk meload scene

public class Play : MonoBehaviour
{
    public void Mulai(){ //dibuat public agar bisa diakses dari luar
        SceneManager.LoadScene("Game");//
    }
}

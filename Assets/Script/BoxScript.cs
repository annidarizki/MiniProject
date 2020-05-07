using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//agar scene manager bisa digunakan

public class BoxScript : MonoBehaviour
{
    public GameObject Pemain;
        void OnCollisionEnter2D(Collision2D kena){
    	    if (kena.gameObject.tag.Equals ("Player")){
    		Destroy(gameObject); //Ketika box diambil akan hilang
			SceneManager.LoadScene("Finish"); //ketika player mendapatkan box maka akan menang
            }
    	}
 }

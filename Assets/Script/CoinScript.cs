using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject Pemain;
        void OnCollisionEnter2D(Collision2D kena){
    	    if (kena.gameObject.tag.Equals ("Player")){
    		print("coin diambil");
            Pemain.GetComponent<Player>().UpdatePosisi(this.transform.position);
    		Destroy(gameObject); //Ketika koin diambil, maka koin akan hancur dan hilang
			CoinScore.hitungCoin += 10; //jika player menumbur koin maka akan mendapat poin 10
            }
    	}
 }

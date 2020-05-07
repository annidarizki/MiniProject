using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
    public static int hitungCoin; //digunakan static agar variabel dapat di panggil script lain

    Text hitungCoinText;
    // Start is called before the first frame update
    void Start()
    {
        hitungCoin = 0; //saat memulai game score koinnya dimulai dari 0
        hitungCoinText = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        hitungCoinText.text = hitungCoin.ToString(); //agar hitung coin yang diambil dapat muncul di text

    }
}

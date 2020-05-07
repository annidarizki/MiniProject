using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCamera : MonoBehaviour
{
   public GameObject Player;
   public float moveX; 

   float Nilaiperubahan;
   float Xawal;
   bool Gerak = true;

   void Start()
   {
       Xawal = transform.position.x; //diisikan di awal dijalankan sesuai posisi awal kamera
   }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Gerak){
        float PosX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref Nilaiperubahan, moveX);
        //menggunakan ref maka perubahan akan mengikuti perubahan fungsi dan tiap perubahan akan disimpan di Nilaiperubahan
        //menggunakan SmoothDamp agar saat perpindahan titik ke titik ada jarak jenjangnya
        transform.position = new Vector3(PosX, transform.position.y, transform.position.z);
        }

        if(transform.position.x < Xawal){
            Nilaiperubahan = Xawal;
            Gerak = false; //jika posisi kamera kurang dari posisi awal maka tidak bergerak
        }

        if(Player.transform.position.x >= Xawal){
            Gerak = true; //jika player berjalan ke kanan dan lebih besar dari posisi awal maka dapat bergerak lagi
        }
    }
}

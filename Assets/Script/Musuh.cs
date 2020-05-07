﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musuh : MonoBehaviour {

    public GameObject Pemain;

    public float BatasKiri;
    public float BatasKanan;
    public float Move;
    public bool HadapKanan; //untuk berpaling hadap kanan atau kiri

    float NilaiPerubahan;

    float Tujuan;

    void FixedUpdate() {
        if (HadapKanan) {
            Tujuan = BatasKanan + 2;
        }
        else {
            Tujuan = BatasKiri - 2;
        }

        
        float PosX = Mathf.SmoothDamp(transform.position.x, Tujuan, ref NilaiPerubahan, Move);
        //manipulasi posisi
        transform.position = new Vector2(PosX, transform.position.y);

        if (transform.position.x >= BatasKanan && HadapKanan) {
            Berpaling();
        }
        else if (transform.position.x <= BatasKiri && !HadapKanan) {
            Berpaling();
        }
    }

    void Berpaling() {
        HadapKanan = !HadapKanan;

        Vector3 Skala = transform.localScale;
        Skala.x *= -1;
        transform.localScale = Skala;
    }

    private void OnCollisionEnter2D(Collision2D Kena) {
        if (Kena.gameObject.name == Pemain.name) {
            Pemain.GetComponent<Player>().PemainMati();
        }
    }
}

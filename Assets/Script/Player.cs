using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    public Collider2D Sensor, lantai;

    public float speed, jump;

    bool hadapKanan = true;
    bool mendarat = true;

    Vector3 pAwal;

    public void UpdatePosisi(Vector3 Posisi){
        pAwal = Posisi;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pAwal = transform.position; //menyimpan posisi awal pemain
    }

    void Update()
    {
        mendarat = Physics2D.IsTouching(Sensor, lantai); //dikatakan mendarat jika sendor dan lantai bersentuhan

        if(Input.GetKeyDown(KeyCode.UpArrow) && mendarat == true){
            //rb.velocity = new Vector2(0f, jump);
            rb.velocity = Vector2.up * jump;
           
        }
    }

    // Update is called once per frame
    void FixedUpdate() // ketika ada perubahan lebih banyak di update dari pda menggunakan update saja
    {
        float move = Input.GetAxis("Horizontal");
        //Input.GetAxis untuk membuat percepatan, ktka berhenti jalan ada jeda menurunkan kecepatan
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if(move > 0 && hadapKanan == false){ //jika kita menghadap kanan dan kita sedang hadap kiri maka akan berpaling
            berpaling();
        }
        else if(move < 0 && hadapKanan == true){ 
            berpaling();
        }
    }

    void berpaling(){
        hadapKanan = !hadapKanan; //untuk mengetahui true or false
        Vector3 Skala = transform.localScale; //memberikan skala
        Skala.x *= -1; //dibuat minus karena akan dibuat berbalik(Skala.x * -1)
        transform.localScale = Skala; //mengembalikan nilai x
    }

    public void PemainMati(){
        transform.position = pAwal;
        rb.velocity = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D kena){
        if(kena.gameObject.name == "SensorLubang"){
            SceneManager.LoadScene("GameOver");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PLAYER_MOVEMENT : MonoBehaviour
{
    public float vel; // Velocidad de movimiento
    public float jumpForce; // Fuerza de salto
    int _jumpCount;
    Rigidbody2D _rb;
    public GameObject vaultmenu;
    public Slider minimap;
    public float playerPos;
    public TextMeshProUGUI locationText;
    public GameObject playerWeapon;
    public ENEMY_CONTROLLER ENEMY_CONTROLLER;
    //int _coins;
    //int _totalCoins;

    // Start is called before the first frame update
    void Start()
    {
        vaultmenu.SetActive(false);
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = this.gameObject.transform.position.x;
        minimap.value = playerPos;
        locationText.text = playerPos.ToString("F0");

        // Direcci�n de movimiento horizontal
        float direction = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(vel * direction, _rb.velocity.y);

        // Cambiar la orientaci�n del sprite cuando el jugador cambia de direcci�n
        if (direction != 0) // Solo cambia la orientaci�n si se mueve
        {
            FlipSprite(direction);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount <= 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _jumpCount++;
        }
    }

    // M�todo para cambiar la orientaci�n del sprite
    void FlipSprite(float direction)
    {
        // Si el jugador se mueve hacia la izquierda (direcci�n negativa)
        if (direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Invertir el sprite horizontalmente
        }
        // Si el jugador se mueve hacia la derecha (direcci�n positiva)
        else if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Restaurar la orientaci�n original
        }
    }

    // M�todos de colisi�n
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "SUELO")
        {
            _jumpCount = 0;
        }
        if (collision.collider.tag == "ENEMYBASE")
        {
            SceneManager.LoadScene(0);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "YOURBASE")
        {
            vaultmenu.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "YOURBASE")
        {
            vaultmenu.SetActive(false);
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "ENEMY" && Input.GetMouseButton(0))
        {
            print("BONK");
            other.gameObject.GetComponent<ENEMY_CONTROLLER>().GetDamage();
        }
    }
}

//public void OnCollisionEnter2D(Collision2D collision)
//{

//if (collision.collider.tag == "SPIKE")
//{
//    SceneManager.LoadScene(0);
//}
//if (collision.collider.tag == "MUELTE")
//{
//    SceneManager.LoadScene(0);
//}

//}
//public void OnTriggerEnter2D(Collider2D collision)
//{
//    if (collision.tag == "COIN")
//    {
//        _coins++;
//        Destroy(collision.gameObject);
//    }
//    if (collision.tag == "FLAG")
//    {
//        print("GANASTE NEN@");
//        SceneManager.LoadScene(0);
//        Ganar.SetActive(true);
//    }
//}


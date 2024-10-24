using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 movement; 
    public float speed;
    private bool itemInHand;
    public Transform item; 
    public Rigidbody2D bulletPrefab;
    public Transform bulletSpawn;
    private float bulletSpeed = 7;
    private int shots = 5;
    public TextMeshProUGUI text; 
    private Vector2 directionShot;
    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // updating the shots counter
        text.gameObject.SetActive(itemInHand);
        text.gameObject.GetComponent<TextMeshProUGUI>().text = "Shots = " + shots;
        item.gameObject.SetActive(!itemInHand);

        //transform.position = new Vector3(transform.position.x + movement.x, transform.position.y + movement.y, 0f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + movement.x, transform.position.y + movement.y, 0f), speed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space) && !itemInHand) gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        if(Input.GetKeyUp(KeyCode.Space) && !itemInHand) gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        if(shots > 0 && itemInHand){
            Shoot();
        }

        if(item.position.x - 0.5f < gameObject.transform.position.x && item.position.x + 0.5f > gameObject.transform.position.x &&
        item.position.y - 0.5f < gameObject.transform.position.y && item.position.y + 0.5f > gameObject.transform.position.y &&
        Input.GetKeyDown(KeyCode.Space) && item.gameObject.activeSelf){
            itemInHand = true;
            shots = 5;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if(shots == 0) itemInHand = false;
        
    }
    
    void OnMove(InputValue val){
        movement = val.Get<Vector2>();
        if(movement != Vector2.zero)directionShot = movement;
    }

        private void Shoot(){
        if(Input.GetKeyDown(KeyCode.Space)){

            Rigidbody2D bull = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

            Vector2 Vel = rb.velocity;
            Vector2 Dir = transform.up;

            float forwardSpeed = Vector2.Dot(Vel, Dir);

            if(forwardSpeed < 0){
                forwardSpeed = 0;
            }
            bull.velocity = Dir * forwardSpeed;
            bull.AddForce(bulletSpeed * directionShot, ForceMode2D.Impulse);
            shots--;
        }
    }

    public bool GetItemInHand(){
        return itemInHand;
    }
}

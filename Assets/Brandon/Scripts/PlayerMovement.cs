using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 movement; 
    public float speed;
    private bool itemInHand;
    public Transform item; 
    public Rigidbody2D bulletPrefab;
    public Transform bulletSpawn;
    private float bulletSpeed = 6;
    private int shots = 5;
    public TextMeshProUGUI text; 
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

        //transform.position = new Vector3(transform.position.x + movement.x, transform.position.y + movement.y, 0f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + movement.x, transform.position.y + movement.y, 0f), speed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space) && !itemInHand) gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        if(Input.GetKeyUp(KeyCode.Space) && !itemInHand) gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        if(shots > 0 && itemInHand){
            Shoot();
        }

        if(item.position.x - 0.5f < gameObject.transform.position.x && item.position.x + 0.5f > gameObject.transform.position.x &&
        item.position.y - 0.5f < gameObject.transform.position.y && item.position.y + 0.5f > gameObject.transform.position.y &&
        Input.GetKeyDown(KeyCode.Space)){
            itemInHand = true;
            shots = 5;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if(shots == 0) itemInHand = false;
        
    }
    
    void OnMove(InputValue val){
        movement = val.Get<Vector2>();
    }

        private void Shoot(){
        if(Input.GetKeyDown(KeyCode.Space)){

            Rigidbody2D bull = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

            Vector2 Vel = rb.velocity;
            Vector2 Dir;
            if(Input.GetKeyDown(KeyCode.S)) Dir = -transform.up;
            if(Input.GetKeyDown(KeyCode.A)) Dir = -transform.right;
            if(Input.GetKeyDown(KeyCode.D)) Dir = transform.right;
            else Dir = transform.forward;

            float forwardSpeed = Vector2.Dot(Vel, Dir);

            if(forwardSpeed < 0){
                forwardSpeed= 0;
            }
            bull.velocity = Dir * forwardSpeed;
            bull.AddForce(bulletSpeed * transform.up, ForceMode2D.Impulse);
            shots--;
        }
    }

    public bool GetItemInHand(){
        return itemInHand;
    }
}

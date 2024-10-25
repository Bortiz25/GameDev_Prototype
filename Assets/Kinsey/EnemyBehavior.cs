using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject player;
    private bool playerVisible = false;
    private float speed = 3;
    private void Update() {
        if(playerVisible){
            Debug.Log("Passed player visible to enemyParent");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
            transform.up = player.transform.position - new Vector3(transform.position.x, transform.position.y,0f);
        }
    }

    public void togglePlayerVisibility(){
        playerVisible = !playerVisible;
    }

    private void FollowPlayer(){
        
    }
}

// Questions this is bringing up
// What do we want field of view to look like?
// When a player is seen, what happens? Which option is more fun or not.

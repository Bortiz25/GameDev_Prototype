using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
   public GameObject enemyParent;
   private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Inside OnTriggerEnter2D");
        this.GetComponent<SpriteRenderer>().color = Color.red;
        enemyParent.GetComponent<EnemyBehavior>().togglePlayerVisibility();
   }
   private void OnTriggerExit2D(Collider2D other) {
        this.GetComponent<SpriteRenderer>().color = Color.white;
        enemyParent.GetComponent<EnemyBehavior>().togglePlayerVisibility();
   }
}

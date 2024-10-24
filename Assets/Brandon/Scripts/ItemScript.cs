using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public PlayerMovement playerScript;
    
    void Update()
    {
        gameObject.SetActive(!playerScript.GetItemInHand());
    }
}

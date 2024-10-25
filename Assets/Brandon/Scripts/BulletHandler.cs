using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;
    void Start(){
        Despawn();
    }

    private void Despawn(){
        Destroy(gameObject, lifetime);
    }
}

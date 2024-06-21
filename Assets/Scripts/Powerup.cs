using Player;
using powerup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    BoosterSpawn spawner;
    //public PlayerController Collision; 

    private void Start()
    {
        spawner = transform.parent.GetComponent<BoosterSpawn>();
    }
    public void OnTriggerEnter(Collider collision) //para boosters y killzone
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colisionó");
            if (spawner.BoosterSpawned == true)
            {
                //Boosters.JumpBoost();
                collision.gameObject.GetComponent<PlayerController>().JumpBoost();
                //spawner.StartCoroutine(Despawn());
                //StartCoroutine(spawner.Despawn(this.gameObject));
                spawner.ActivarCorrutina(this.gameObject);
            }
        }
    }
}

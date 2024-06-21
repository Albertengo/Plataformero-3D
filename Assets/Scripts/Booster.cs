using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace powerup
{
    public class Booster : MonoBehaviour
    {
        public GameObject prefab;
        public Vector3 posicionSpawn;
        public bool BoosterSpawned =false;

        void FixedUpdate()
        {
            if (BoosterSpawned == false)
            {
                Spawn();
                Debug.Log("Boost Spawneado");
            }
            
        }

        void Spawn()
        {
            Instantiate(prefab, posicionSpawn, prefab.transform.rotation);
            BoosterSpawned = true;
            StartCoroutine(Chequeo());
        }

        IEnumerator Chequeo()
        {
            //while (BoosterSpawned == true) 
            //{ 

            //}
            if (BoosterSpawned == true)
            {
                //
                //BoosterSpawned = false;
                yield return new WaitForSeconds(3f);
                Debug.Log("Ya esperé 3 segundos:P");
                
            }
        }
    }
}

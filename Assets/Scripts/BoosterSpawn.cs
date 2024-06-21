using Player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class BoosterSpawn : MonoBehaviour
{
    #region Variables
    public GameObject Prefab;
    //public Vector3 posicionSpawn;
    public bool BoosterSpawned = true;
    public PlayerController Boosters;
    #endregion

    void Start()
    {
        //Instantiate(Prefab, posicionSpawn, Prefab.transform.rotation);
        Instantiate(Prefab, this.transform);
        //StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator Despawn(GameObject boost)
    {
        BoosterSpawned = false; //booster se consumió

        if (boost.gameObject.CompareTag("JumpBoost")) //si el booster consumido tiene de tag "jumpboost", invocar su método
            Boosters.Invoke("EndBoostJump", Boosters.BoostTime);
        else if (boost.gameObject.CompareTag("SpeedBoost")) //si el booster consumido tiene de tag "speedboost", invocar su método
            Boosters.Invoke("EndBoostSpeed", Boosters.BoostTime);

        boost.SetActive(false); //se desactiva el boost para q parezca q se consumió

        yield return new WaitForSeconds(5); //espera 5 segundos

        Debug.Log("pasaron 5 segundos"); //chequeador
        //transform.GetChild(transform.childCount - 1).gameObject.SetActive(true);
        boost.SetActive(true); //y vuelve a activar el boost para q parezca que respawneó
        BoosterSpawned = true; //se ha vuelto a spawnear un booster
    }

    public void ActivarCorrutina(GameObject boost)
    {
        StartCoroutine(Despawn(boost));
    }
}


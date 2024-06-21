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
        BoosterSpawned = false;

        if (boost.gameObject.CompareTag("JumpBoost"))
            Boosters.Invoke("EndBoostJump", Boosters.BoostTime);
        else if (boost.gameObject.CompareTag("SpeedBoost"))
            Boosters.Invoke("EndBoostSpeed", Boosters.BoostTime);

        boost.SetActive(false);

        yield return new WaitForSeconds(5);

        Debug.Log("hola");
        //transform.GetChild(transform.childCount - 1).gameObject.SetActive(true);
        boost.SetActive(true);
        BoosterSpawned = true;
    }

    public void ActivarCorrutina(GameObject boost)
    {
        StartCoroutine(Despawn(boost));
    }
}


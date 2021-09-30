using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Aparece : MonoBehaviour
{
    public GameObject enemigo;
    public Transform tran_enemigo;
    void Start()
    {
        Invoke("CrearEnemigo",(Random.Range(3,15)));
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void CrearEnemigo()
    {
        Instantiate(enemigo, tran_enemigo.position, tran_enemigo.transform.rotation);
        float delay = Random.Range(5, 20);
        Invoke("CrearEnemigo", delay);
    }
}

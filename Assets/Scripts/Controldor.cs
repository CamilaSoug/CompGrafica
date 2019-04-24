using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controldor : MonoBehaviour
{

    public Transform jogador;
    public Transform jogadorCam;
    public float forca = 400f;
    public float reescala = 0.025f;
    bool temJogador = false;
    bool beingCarried = false;
    private bool tocado = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, jogador.position);
        if (dist <= 2.5f)
        {
            temJogador = true;
        }
        else
        {
            temJogador = false;
        }

        if (temJogador && Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = jogadorCam;
            beingCarried = true;

        }
        if (beingCarried && Input.GetMouseButtonUp(0))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
            beingCarried = false;
        }


        if (beingCarried)
        {
            if (tocado)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                tocado = false;
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(jogadorCam.forward * forca);
            }
            else if (Input.GetMouseButtonDown(2))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                transform.localScale += new Vector3(reescala, reescala, reescala);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                transform.localScale -= new Vector3(reescala, reescala, reescala);
            }
        }
    }
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            tocado = true;
        }
    }
}

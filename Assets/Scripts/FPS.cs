using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{

    private Rigidbody rbd;
    public float velocidade = 10f;
    public float velocidadeRot = 50f;
    public float pulo = 100f;
    private float rotY = 0;
    private float rotX = 0;
    public Text mira;
    
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        mira.text = "(+)";
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        rotY += Input.GetAxis("Mouse X") * velocidadeRot * Time.deltaTime;
        rotX -= Input.GetAxis("Mouse Y") * velocidadeRot * Time.deltaTime;
        rbd.velocity = transform.TransformDirection(new Vector3(x * velocidade, rbd.velocity.y, z * velocidade));
        if (Input.GetKeyDown(KeyCode.Space))
            rbd.AddForce(0, pulo, 0);
        transform.localEulerAngles = new Vector3(0, rotY, 0);
        Camera.main.transform.localEulerAngles = new Vector3(Mathf.Clamp(rotX, -70, 70), 0, 0);
    }
}

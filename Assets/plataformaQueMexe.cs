using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaQueMexe : MonoBehaviour
{
    bool irParaAFrente = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= 92.5)
        {
            irParaAFrente = true;   
        }
        if(transform.position.x >= 105)
        {
            irParaAFrente = false;
        }
        if(irParaAFrente == true)
        {
            transform.position += new Vector3(Time.deltaTime * 2, 0, 0);
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * -2, 0, 0);
        }
    }
}

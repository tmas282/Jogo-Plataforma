using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPedra : MonoBehaviour
{
    void Matar()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().IsTouching(gameObject.GetComponent<Collider2D>()))
        {
            SceneManager.LoadSceneAsync("derrota");
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("estaTocar", false);
        }
    }
}

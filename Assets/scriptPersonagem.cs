using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scriptPersonagem : MonoBehaviour
{
    float input = 0;
    Rigidbody2D rb;
    public Collider2D chao;
    public SpriteRenderer personagemSprite;
    public Animator personagemAnimator;
    public Collider2D pedraCollider;
    public Collider2D bolaEspinhosCollider;
    public Collider2D serraCollider;
    public GameObject plataformaQueCai;
    private bool jaExiste = false;
    public Collider2D trampolimCollider;
    public Collider2D plataformaQueMexeCollider;
    public Collider2D areaVentoinhaCollider;
    public int pontuacao;
    void VerificarVitoria()
    {
        if(pontuacao == 8)
        {
            SceneManager.LoadScene("vitoria");
        }
    }
    void VerificarMorte()
    {
        if(transform.position.y <= -10)
        {
            PlayerPrefs.SetString("nivelEmQueMorreu", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("derrota");
        }
        if (SceneManager.GetActiveScene().name == "nivel3")
        {
            if (rb.IsTouching(pedraCollider))
            {
                GameObject.Find("pedra").GetComponent<Animator>().SetBool("estaTocar", true);
            }
            if (rb.IsTouching(bolaEspinhosCollider))
            {
                PlayerPrefs.SetString("nivelEmQueMorreu", "nivel3");
                SceneManager.LoadSceneAsync("derrota");
            }
            if (rb.IsTouching(serraCollider))
            {
                PlayerPrefs.SetString("nivelEmQueMorreu", "nivel3");
                SceneManager.LoadSceneAsync("derrota");
            }
            if (rb.IsTouching(plataformaQueCai.GetComponent<Collider2D>()))
            {
                if (jaExiste == false)
                {
                    plataformaQueCai.AddComponent<Rigidbody2D>();
                }
                jaExiste = true;
                plataformaQueCai.GetComponent<Animator>().SetBool("estaCair", true);
            }
            if (rb.IsTouching(areaVentoinhaCollider))
            {
                transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
            }
        }
    }
    void PersonagemMover()
    {
        input = Input.GetAxis("Horizontal");
        transform.Translate(10 * Time.deltaTime * new Vector3(input, 0, 0));
        if(input < 0)
        {
            personagemSprite.flipX = true;
            personagemAnimator.SetBool("correr", true);

        }
        if (input > 0)
        {
            personagemSprite.flipX = false;
            personagemAnimator.SetBool("correr", true);
        }
        if(input == 0)
        {
            personagemAnimator.SetBool("correr", false);
        }
    }
    void Saltar()
    {
        if (rb.IsTouching(chao) || (SceneManager.GetActiveScene().name == "nivel3" && (rb.IsTouching(pedraCollider) || rb.IsTouching(plataformaQueCai.GetComponent<Collider2D>()) || rb.IsTouching(trampolimCollider) || rb.IsTouching(plataformaQueMexeCollider))))
        {
            personagemAnimator.SetBool("cair", false);
            if ((PlayerPrefs.GetString("inverter") == "False" && Input.GetKeyDown(KeyCode.Space)) || (PlayerPrefs.GetString("inverter") == "True" && Input.GetKeyDown(KeyCode.RightShift)))
            {
                if (SceneManager.GetActiveScene().name == "nivel3" && rb.IsTouching(trampolimCollider))
                {
                    rb.AddForce(new Vector2(0, 40f), ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(new Vector2(0, 20f), ForceMode2D.Impulse);
                }
                personagemAnimator.SetBool("saltar", true);
            }
        }
        else
        {
            if (rb.velocity.y < 0)
            {
                personagemAnimator.SetBool("cair", true);
                personagemAnimator.SetBool("saltar", false);
            }
        }
    }

    void Atacar()
    {
        if ((PlayerPrefs.GetString("inverter") == "False" && Input.GetKeyDown(KeyCode.RightShift)) || (PlayerPrefs.GetString("inverter") == "True" && Input.GetKeyDown(KeyCode.Space)))
        {
            if(SceneManager.GetActiveScene().name == "nivel1")
            {
                if (rb.IsTouching(GameObject.Find("maca").GetComponent<Collider2D>()))
                {
                    SceneManager.LoadScene("nivel2");
                    GameObject.FindGameObjectWithTag("pontuacao").GetComponent<TextMeshProUGUI>().text = string.Format("{0}/8", pontuacao);
                }
            }
            if(SceneManager.GetActiveScene().name == "nivel2")
            {
                if (rb.IsTouching(GameObject.Find("laranja").GetComponent<Collider2D>()))
                {
                    SceneManager.LoadScene("nivel3");
                    GameObject.FindGameObjectWithTag("pontuacao").GetComponent<TextMeshProUGUI>().text = string.Format("{0}/8", pontuacao);
                }
            }
            if (SceneManager.GetActiveScene().name == "nivel3")
            {
                foreach (GameObject fruta in GameObject.FindGameObjectsWithTag("fruta"))
                {
                    if (rb.IsTouching(fruta.GetComponent<Collider2D>()))
                    {
                        fruta.SetActive(false);
                        pontuacao++;
                        GameObject.FindGameObjectWithTag("pontuacao").GetComponent<TextMeshProUGUI>().text = string.Format("{0}/8", pontuacao);
                    }
                }
            }
        }
    }
    void Start()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicaVol");
        rb = gameObject.GetComponent<Rigidbody2D>();
        chao = GameObject.FindGameObjectWithTag("chao").GetComponent<Collider2D>();
        personagemSprite = gameObject.GetComponent<SpriteRenderer>();
        personagemAnimator = gameObject.GetComponent<Animator>();
        if(SceneManager.GetActiveScene().name == "nivel3")
        {
            pedraCollider = GameObject.Find("pedra").GetComponent<Collider2D>();
            bolaEspinhosCollider = GameObject.Find("bola de espinhos").GetComponent<Collider2D>();
            serraCollider = GameObject.Find("serra").GetComponent<Collider2D>();
            plataformaQueCai = GameObject.Find("plataforma que cai");
            trampolimCollider = GameObject.Find("trampolim").GetComponent<Collider2D>();
            plataformaQueMexeCollider = GameObject.Find("plataforma que mexe").GetComponent<Collider2D>();
            areaVentoinhaCollider = GameObject.Find("areaVentoinha").GetComponent<Collider2D>();
        }
        if(SceneManager.GetActiveScene().name == "nivel1")
        {
            pontuacao = 0;
        }
        if (SceneManager.GetActiveScene().name == "nivel2")
        {
            pontuacao = 1;
        }
        if (SceneManager.GetActiveScene().name == "nivel3")
        {
            pontuacao = 2;
        }
        GameObject.FindGameObjectWithTag("pontuacao").GetComponent<TextMeshProUGUI>().text = string.Format("{0}/8", pontuacao);
    }
    void Update()
    {
        PersonagemMover();
        Saltar();
        Atacar();
        VerificarMorte();
        VerificarVitoria();
    }
}
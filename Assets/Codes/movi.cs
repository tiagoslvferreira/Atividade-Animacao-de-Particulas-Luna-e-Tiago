using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movi : MonoBehaviour
{
    public float speed = 5f;
    public float jumpforce = 10f;
    public bool liberarpulo = false;
    private float direcao;
    private Rigidbody2D persona;
    private Transform plataformaAtual;
    private bool definirPaiAdiado = false; // Variável para controle de SetParent adiado

    // Start is called before the first frame update
    void Start()
    {
        persona = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Pulo();
        Movimentopersona();
        Girar();
    }

    void Movimentopersona()
    {
        direcao = Input.GetAxisRaw("Horizontal");
        persona.velocity = new Vector2(direcao * speed, persona.velocity.y);
    }

    void Girar()
    {
        if (direcao < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (direcao > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao") || collision.gameObject.CompareTag("Plataforma"))
        {
            liberarpulo = true;
            if (collision.gameObject.CompareTag("Plataforma"))
            {
                // Adia a definição do pai para evitar o erro de ativação/desativação
                definirPaiAdiado = true;
                plataformaAtual = collision.gameObject.transform;
            }
        }
        if (collision.gameObject.CompareTag("inimigo"))
        {
            SceneManager.LoadScene("Game over");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao") || collision.gameObject.CompareTag("Plataforma"))
        {
            liberarpulo = false;
            if (collision.gameObject.CompareTag("Plataforma"))
            {
                // Remover a relação de pai-filho quando sair da plataforma
                transform.SetParent(null);
                plataformaAtual = null;
            }
        }
    }

    void Pulo()
    {
        if (liberarpulo && Input.GetKeyDown(KeyCode.Space))
        {
            persona.velocity = new Vector2(persona.velocity.x, jumpforce);
            if (plataformaAtual != null)
            {
                // Remover a relação de pai-filho quando pular da plataforma
                transform.SetParent(null);
                plataformaAtual = null;
            }
        }
    }

    void LateUpdate()
    {
        if (definirPaiAdiado && plataformaAtual != null)
        {
            // Define o pai após a atualização do frame
            transform.SetParent(plataformaAtual);
            definirPaiAdiado = false; // Redefine a variável
        }
    }
}

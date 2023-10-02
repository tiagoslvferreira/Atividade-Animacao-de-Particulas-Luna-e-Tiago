using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particulashehe : MonoBehaviour
{
    public GameObject igor;
    public GameObject particulas;
    private GameObject playerObject; // Variável para rastrear o jogador
    private bool destruirPlayer = false; // Variável de controle para destruir o jogador

    // Start is called before the first frame update
    void Start()
    {
        particulas.SetActive(false);
        igor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se o jogador deve ser destruído
        if (destruirPlayer)
        {
            Destroy(playerObject); // Destruir o jogador
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fofura"))
        {
            particulas.SetActive(true);
            igor.SetActive(true);

            // Flipar o objeto com a tag "fofura" (flipX no componente SpriteRenderer)
            SpriteRenderer fofuraRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            if (fofuraRenderer != null)
            {
                fofuraRenderer.flipX = true;
            }

            // Rastreia o objeto do jogador
            if (collision.gameObject.CompareTag("player"))
            {
                playerObject = collision.gameObject;
                destruirPlayer = true; // Define a variável de controle para destruir o jogador após 3 segundos
                StartCoroutine(DelayedDestroyPlayer(3f)); // Chama a função de atraso para destruir o jogador após 3 segundos
            }
        }
    }

    // Função para destruir o jogador após um atraso
    private IEnumerator DelayedDestroyPlayer(float delay)
    {
        yield return new WaitForSeconds(delay);
        destruirPlayer = false; // Resetar a variável de controle
    }
}
